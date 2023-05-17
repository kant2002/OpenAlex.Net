using OpenAlexNet;
using System.Diagnostics;

var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
//var testAuthor = await api.GetAuthorAsync("A4328046938");
//PrintAuthor(testAuthor);

var authorName = args.ElementAtOrDefault(0);
var root = await api.SearchAuthorsAsync(authorName);
HashSet<string> affiliations = new();
HashSet<string> othersAffiliations = new();
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