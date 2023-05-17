using OpenAlexNet;

var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
var testAuthor = await api.GetAuthorAsync("A4328046938");
PrintAuthor(testAuthor);
var root = await api.SearchAuthorsAsync(args.ElementAtOrDefault(0));
foreach (Author author in root.Results)
{
    PrintAuthor(author);
}

static void PrintAuthor(Author author)
{
    Console.WriteLine($"{author.DisplayName} - {author.Id} - {author.Orcid} {author.WorksApiUrl}({author.WorksCount})");
}