using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers.Classic;
using Microsoft.Data.Analysis;
using System.Text;
using System.CommandLine;

var rorOption = new Option<string>
    ("--ror", "Path to CSV file from ROR data dump. See https://github.com/ror-community/ror-data.");
var sourceOption = new Option<string>
    ("--source", "Path to CSV file which match with ROR data.");
var outputOption = new Option<string>
    ("--output", "Path to CSV file where to save matched data.");
var goldOption = new Option<string>
    ("--gold", "Gold CSV with matched ROR data.");
var updateIndexOption = new Option<bool>
    ("--update-index", "Update Lucene index if needed.");
var searchColumnOption = new Option<string>
    ("--match-column", "Name of the search column.");
var separatorOption = new Option<string>
    ("--countries", "Countries from which perform match.");

var rootCommand = new RootCommand();
rootCommand.AddOption(rorOption);
rootCommand.AddOption(sourceOption);
rootCommand.AddOption(outputOption);
rootCommand.AddOption(goldOption);
rootCommand.AddOption(searchColumnOption);
rootCommand.AddOption(updateIndexOption);
rootCommand.AddOption(separatorOption);
rootCommand.SetHandler(MatchRor, rorOption, sourceOption, outputOption, goldOption, searchColumnOption, separatorOption, updateIndexOption);
return await rootCommand.InvokeAsync(args);

static void MatchRor(string rorDataDumpFile, string unprocessedFilePath, string processedFilePath, string goldFilePath, string searchColumnName, string searchCountries, bool updateIndex)
{
    if (!File.Exists(rorDataDumpFile))
    {
        Console.WriteLine($"Please download v1.25-2023-05-11-ror-data.csv file from https://github.com/ror-community/ror-data/blob/main/v1.25-2023-05-11-ror-data.zip and place in current directory.");
        return;
    }

    if (!File.Exists(unprocessedFilePath))
    {
        Console.WriteLine($"You did not specify source file.");
        return;
    }

    // Ensures index backward compatibility
    const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

    using var writer = OpenLuceneIndex(AppLuceneVersion);

    if (updateIndex)
    {
        PopulateLuceneIndex(rorDataDumpFile, searchCountries.Split(','), writer);
    }

    DataFrame? goldData = null;
    if (File.Exists(goldFilePath))
    {
        goldData = DataFrame.LoadCsv(goldFilePath);
    }

    FindRorCandidates(AppLuceneVersion, writer, unprocessedFilePath, processedFilePath, searchColumnName, goldData);
    Console.WriteLine("Done.");
}

static IndexWriter OpenLuceneIndex(LuceneVersion AppLuceneVersion)
{
    // Construct a machine-independent path for the index
    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    var indexPath = Path.Combine(basePath, "ror-matcher");

    var dir = FSDirectory.Open(indexPath);

    // Create an analyzer to process the text
    var analyzer = new StandardAnalyzer(AppLuceneVersion);

    // Create an index writer
    var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
    return new IndexWriter(dir, indexConfig);
}

static void FindRorCandidates(LuceneVersion AppLuceneVersion, IndexWriter writer, string unprocessedFilePath, string processedFilePath, string searchColumnName, DataFrame? goldData)
{
    Console.WriteLine("Find ROR candidates by searching Lucene.");
    using var reader = writer.GetReader(applyAllDeletes: true);
    var searcher = new IndexSearcher(reader);

    // Load unprocessed file to query Lucene index for candidates
    var unprocesedFrame = DataFrame.LoadCsv(unprocessedFilePath, guessRows: 1000, encoding: Encoding.UTF8);

    // Append columns for ROR candidates
    var candidatesCount = 3;
    for (var i = 1; i <= 3; i++)
    {
        unprocesedFrame.Columns.Insert(2 + 3 * (i - 1), DataFrameColumn.Create($"candidate{i}", new string[unprocesedFrame.Rows.Count]));
        unprocesedFrame.Columns.Insert(3 + 3 * (i - 1), DataFrameColumn.Create($"ror{i}", new string[unprocesedFrame.Rows.Count]));
        unprocesedFrame.Columns.Insert(4 + 3 * (i - 1), DataFrameColumn.Create($"score{i}", new float?[unprocesedFrame.Rows.Count]));
    }

    unprocesedFrame.Columns.Insert(2, DataFrameColumn.Create($"ror_name", new string[unprocesedFrame.Rows.Count]));
    unprocesedFrame.Columns.Insert(3, DataFrameColumn.Create($"ror", new string[unprocesedFrame.Rows.Count]));

    var searchColumn = unprocesedFrame[searchColumnName];
    QueryParser parser = new QueryParser(AppLuceneVersion, "name", writer.Analyzer);
    for (var i = 0; i < unprocesedFrame.Rows.Count; i++)
    {
        var organization = searchColumn[i].ToString();
        if (organization is null) continue;

        Query query = parser.Parse(organization.Replace("?", "").Replace("\"", "").Replace("(", "").Replace(")", ""));
        var hits = searcher.Search(query, candidatesCount).ScoreDocs;
        for (var h = 0; h < hits.Length; h++)
        {
            var hit = hits[h];
            var foundDoc = searcher.Doc(hit.Doc);
            var candidateColumn = unprocesedFrame[$"candidate{(h + 1)}"];
            candidateColumn[i] = foundDoc.Get("name");
            var rorColumn = unprocesedFrame[$"ror{(h + 1)}"];
            rorColumn[i] = foundDoc.Get("id");
            var scoreColumn = unprocesedFrame[$"score{(h + 1)}"];
            scoreColumn[i] = hit.Score;
        }

        if (goldData is not null)
        {
            var goldSearchColumn = goldData[searchColumnName];
            for (var j = 0; j < goldData.Rows.Count; j++)
            {
                if (goldSearchColumn[j].ToString()?.Trim() == organization.Trim())
                {
                    unprocesedFrame[$"ror_name"][i] = goldData["ror_name"][j];
                    unprocesedFrame[$"ror"][i] = goldData["ror"][j];
                }
            }
        }
    }

    DataFrame.SaveCsv(unprocesedFrame, processedFilePath, encoding: Encoding.UTF8);
}

static void PopulateLuceneIndex(string rorFile, string[] searchCountries, IndexWriter writer)
{
    Console.WriteLine("Building Lucene index from ROR data.");
    var sourceDataFrame = DataFrame.LoadCsv(rorFile);
    var idColumn = sourceDataFrame["id"];
    var nameColumn = sourceDataFrame["name"];
    var aliasesColumn = sourceDataFrame["aliases"];
    var labelsColumn = sourceDataFrame["labels"];
    var acronymsColumn = sourceDataFrame["acronyms"];
    var countryCodeColumn = sourceDataFrame["country.country_code"];
    for (var i = 0; i < sourceDataFrame.Rows.Count; i++)
    {
        var countryCode = countryCodeColumn[i].ToString();
        if (searchCountries.Length > 0
            && !string.IsNullOrEmpty(countryCode)
            && searchCountries.Any(c => !string.Equals(countryCode, c, StringComparison.InvariantCultureIgnoreCase)))
        {
            continue;
        }

        var id = idColumn[i].ToString();
        var doc = new Document
        {
            // StringField indexes but doesn't tokenize
            new StringField("id",
                id,
                Field.Store.YES),
            new TextField("name",
                nameColumn[i].ToString(),
                Field.Store.YES),
            new TextField("aliases",
                aliasesColumn[i].ToString(),
                Field.Store.YES),
            new TextField("acronyms",
                acronymsColumn[i].ToString(),
                Field.Store.YES),
        };

        writer.UpdateDocument(new Term("id", id), doc);
    }

    writer.Flush(triggerMerge: false, applyAllDeletes: false);
}