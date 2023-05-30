using OpenAlexNet;
using System.CommandLine;
using System.Diagnostics;
using System.Text.Json;

var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
HashSet<string> affiliations = new();
HashSet<string> othersAffiliations = new();

var searchArgument = new Argument<string>
    ("search", "An author or institution name to search for.");
var worksOption = new Argument<FileInfo>
    ("works", "JSON file with works saved. You can create it on https://kant2002.github.io/OpenAlexBrowser/works");

var printAuthorCommand = new Command("print-author", "Print author by name.");
printAuthorCommand.AddArgument(searchArgument);
printAuthorCommand.SetHandler(async (search) =>
{
    var testAuthor = await api.GetAuthorAsync(search);
    PrintAuthor(testAuthor);
}, searchArgument);

var findAuthorWorksCommand = new Command("author-works", "Find works of given author.");
findAuthorWorksCommand.AddArgument(searchArgument);
findAuthorWorksCommand.SetHandler(FindAuthorWorks, searchArgument);

var findAffiliationWorksCommand = new Command("affiliation-works", "Find works of given institution by affiliation string.");
findAffiliationWorksCommand.AddArgument(searchArgument);
findAffiliationWorksCommand.SetHandler(SearchWorksByAffiliations, searchArgument);

var findInstitutionWorksCommand = new Command("institution-works", "Find works of given institution.");
findInstitutionWorksCommand.AddArgument(searchArgument);
findInstitutionWorksCommand.SetHandler(MultipleInstitutionsWork, searchArgument);

var findAwardsCommand = new Command("find-awards", "Find awards for given subset of works.");
findAwardsCommand.AddArgument(worksOption);
findAwardsCommand.SetHandler(async (works) => { await FindAwards(works.FullName); }, worksOption);

var findGrantsCommand = new Command("find-grants", "Find grants for given subset of works.");
findGrantsCommand.AddArgument(worksOption);
findGrantsCommand.SetHandler(async (works) => { await FindGrants(works.FullName); }, worksOption);

var rootCommand = new RootCommand();
rootCommand.AddCommand(printAuthorCommand);
rootCommand.AddCommand(findAuthorWorksCommand);
rootCommand.AddCommand(findAffiliationWorksCommand);
rootCommand.AddCommand(findInstitutionWorksCommand);
rootCommand.AddCommand(findAwardsCommand);
rootCommand.AddCommand(findGrantsCommand);
return await rootCommand.InvokeAsync(args);

async Task FindGrants(string institutionsFile)
{
    var works = JsonSerializer.Deserialize<List<Work>>(File.OpenRead(institutionsFile));
    var institutions = works.SelectMany(_ => _.Authorships.SelectMany(a => a.Institutions)).DistinctBy(_ => _.Id).ToList();

    // PrintInstitutions(institutions);

    Console.WriteLine($"==== by countries ==== ");
    foreach (var country in institutions.GroupBy(i => i.CountryCode).OrderByDescending(_ => _.Count()))
    {
        Console.WriteLine($"{country.Key} - {country.Count()}");
    }

    var authorships = works.SelectMany(_ => _.Authorships).DistinctBy(_ => _.Author.DisplayName).ToList();

    Console.WriteLine($"==== by types ==== ");
    foreach (var country in institutions.GroupBy(i => i.Type).OrderByDescending(_ => _.Count()))
    {
        Console.WriteLine($"{country.Key} - {country.Count()}");
    }

    var worksWithGrands = works.Where(_ => _.Grants is not null && _.Grants.Count > 0).ToList();
    var grants = works.SelectMany(_ => _.Grants ?? new()).DistinctBy(_ => _.Funder).ToList();
    Console.WriteLine($"Funders count: {grants.Count}");
    foreach (var grant in grants)
    {
        var funder = await api.GetFunderAsync(grant.Funder.Replace("https://openalex.org/", ""));
        Console.WriteLine($"{funder.Id} - {funder.CountryCode} - {funder.HomePageUrl} - {funder.DisplayName}");
    }

    var awards = works.SelectMany(_ => _.Grants ?? new()).DistinctBy(_ => _.AwardId + _.Funder).ToList();
    Console.WriteLine($"Awards count: {awards.Count}");
}

async Task FindAwards(string institutionsFile)
{
    var works = JsonSerializer.Deserialize<List<Work>>(File.OpenRead(institutionsFile));
    var institutions = works.SelectMany(_ => _.Authorships.SelectMany(a => a.Institutions)).DistinctBy(_ => _.Id).ToList();

    var awards = works.SelectMany(_ => _.Grants ?? new()).Where(_ => !string.IsNullOrEmpty(_.AwardId)).DistinctBy(_ => _.AwardId + _.Funder).ToList();
    Dictionary<string, Funder> fundersCache = new();
    Console.WriteLine($"Id,Doi,PublicationDate,Title,AuthorshipsCount,FunderId,AwardId,FunderCountryCode,FunderHomePageUrl,FunderDisplayName");
    foreach (var work in works)
    {
        if (work.Grants is null) continue;
        foreach (var grant in work.Grants)
        {
            var funderId = grant.Funder.Replace("https://openalex.org/", "");
            if (!fundersCache.TryGetValue(funderId, out var funder))
            {
                funder = await api.GetFunderAsync(funderId);
                if (funder is null) continue;
                fundersCache.Add(funderId, funder);
            }

            if (grant.AwardId is null) continue;

            Console.WriteLine($"{work.Id},{work.Doi},{work.PublicationDate},{EscapeCsv(work.Title)},{work.Authorships.Count},{funder.Id},{EscapeCsv(grant.AwardId)},{funder.CountryCode},{funder.HomePageUrl},{EscapeCsv(funder.DisplayName)}");
        }
    }
}

static string EscapeCsv(string text)
{
    if (text.Contains('"') || text.Contains(',') || text.Contains('\n') || text.Contains('\r'))
    {
        return '"' + text.Replace("\"", "\"\"") + '"';
    }

    return text;
}

static void PrintInstitutions(List<DehydratedInstitution> institutions)
{
    foreach (var institution in institutions)
    {
        Console.WriteLine($"{institution.Ror} - {institution.CountryCode} - {institution.Type} - {institution.DisplayName}");
    }
}

async Task MultipleInstitutionsWork(string institutionName)
{
    var institutions = await api.SearchInstitutionsAsync(institutionName);
    foreach (var institution in institutions.Results)
    {
        Console.WriteLine($"{institution.DisplayName}");
    }

    if (institutions.Results.Count == 0)
    {
        Console.WriteLine($"There no institutions found by name {institutionName}");
        return;
    }

    var workFilter = new WorksFilter();
    workFilter.ByInstitutionsId(institutions.Results.Select(_ => _.Id.Replace("https://openalex.org/", "")));
    var works = await api.FindWorksAsync(workFilter);
    PrintWorks(works.Results);
}

async Task SearchWorksByAffiliations(string institutionName)
{
    int page = 1;
    var works = await api.FindWorksByAffiliationAsync(institutionName, page);
    while (works.Meta.PerPage * works.Meta.Page < works.Meta.Count)
    {
        PrintWorks(works.Results);
        page++;
        works = await api.FindWorksByAffiliationAsync(institutionName, page);
    }

    PrintWorks(works.Results);
}

static void PrintWorks(List<Work> works)
{
    foreach (Work work in works)
    {
        PrintWork(work);
    }
}

async Task FindAuthorWorks(string authorName)
{
    var root = await api.SearchAuthorsAsync(authorName);
    foreach (Author author in root.Results)
    {
        PrintAuthor(author);
        await PrintAuthorWorksAsync(author);
    }

    Console.WriteLine("========= affiliations ===============");
    foreach (var author in affiliations)
    {
        Console.WriteLine(author);
    }

    Console.WriteLine("========= othersAffiliations ===============");
    foreach (var author in othersAffiliations)
    {
        Console.WriteLine(author);
    }
}

async Task PrintAuthorWorksAsync(Author author)
{
    var authorWorks = await api.FindWorksByAuthorAsync(author.Id);
    foreach (Work work in authorWorks.Results)
    {
        PrintWork(work);
        foreach (var a in work.Authorships)
        {
            if (a.Author.Id == author.Id)
            {
                affiliations.Add(a.RawAffiliationString);
                foreach (var i in a.Institutions)
                {
                    affiliations.Add(i.DisplayName);
                }
                foreach (var aff in a.RawAffiliationStrings)
                {
                    affiliations.Add(aff);
                }
            }
            else
            {
                othersAffiliations.Add(a.RawAffiliationString);
                foreach (var i in a.Institutions)
                {
                    othersAffiliations.Add(i.DisplayName);
                }
                foreach (var aff in a.RawAffiliationStrings)
                {
                    othersAffiliations.Add(aff);
                }
            }
        }
    }
}

static void PrintAuthor(Author author)
{
    Console.WriteLine($"{author.DisplayName} - {author.Id} - {author.Orcid} {author.LastKnownInstitution?.DisplayName}({author.LastKnownInstitution?.Id}) {author.WorksApiUrl}({author.WorksCount})");
}

static void PrintWork(Work work)
{
    if (work.CorrespondingInstitutionIds.Contains("https://openalex.org/I2800895607"))
    {
        Debugger.Break();
    }

    Console.WriteLine($"{work.DisplayName} - {work.Id} - {work.Doi} {string.Join(", ", work.Authorships.Select(_ => $"{_.Author.DisplayName} ({_.RawAffiliationString})"))}");
}