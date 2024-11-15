# OpenAlex.Net

C# API for accessing [OpenAlex data](https://openalex.org).

# Get started

Just add package to your project
```
dotnet add package OpenAlexNet --prerelease
```

Then you can create client to OpenAlex API using following commands
```
var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
```

# How to search for an author

```csharp
var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
var searchResponse = await api.SearchAuthorsAsync(authorName);
foreach (Author author in searchResponse.Results)
{
    PrintAuthor(author);
}

static void PrintAuthor(Author author)
{
    Console.WriteLine($"{author.Id} - {author.DisplayName} - ORCID: {author.Orcid} Last worket at: {author.LastKnownInstitution?.DisplayName} Works: {author.WorksCount}");
}
```

# Supported entities

| Entity | Status |
| ------ | ------ |
| Works | :white_check_mark: |
| Authors | :white_check_mark: |
| Sources | :white_large_square: |
| Institutions | :white_check_mark: |
| Concepts | :white_large_square: |
| Publishers | :white_large_square: |
| Funders | :white_check_mark: |
