﻿using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Web;

var httpClient = new HttpClient();
var api = new OpenAlexApi(httpClient);
var root = await api.SearchAuthorsAsync(args[0]);
Console.WriteLine("Hello, World!");

class OpenAlexApi
{
    private readonly HttpClient httpClient;
    private readonly Uri BaseAddress = new Uri("https://api.openalex.org");

    public OpenAlexApi(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        //this.httpClient.BaseAddress = new Uri("https://api.openalex.org");
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("OpenAlexApi", "0.0.1"));
    }

    internal async Task<Root?> SearchAuthorsAsync(string author)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/authors"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = author;
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var message = new HttpRequestMessage(HttpMethod.Get, url);
        var response = await httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Root>();
    }
}

public class CountsByYear
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }
}

public class Ids
{
    [JsonPropertyName("openalex")]
    public string Openalex { get; set; }

    [JsonPropertyName("orcid")]
    public string Orcid { get; set; }

    [JsonPropertyName("mag")]
    public string Mag { get; set; }

    [JsonPropertyName("scopus")]
    public string Scopus { get; set; }
}

public class LastKnownInstitution
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("ror")]
    public string Ror { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class Meta
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("db_response_time_ms")]
    public int? DbResponseTimeMs { get; set; }

    [JsonPropertyName("page")]
    public object Page { get; set; }

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("next_cursor")]
    public string NextCursor { get; set; }
}

public class Result
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("orcid")]
    public string Orcid { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("display_name_alternatives")]
    public List<object> DisplayNameAlternatives { get; set; }

    [JsonPropertyName("relevance_score")]
    public double? RelevanceScore { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("summary_stats")]
    public SummaryStats SummaryStats { get; set; }

    [JsonPropertyName("ids")]
    public Ids Ids { get; set; }

    [JsonPropertyName("last_known_institution")]
    public LastKnownInstitution LastKnownInstitution { get; set; }

    [JsonPropertyName("x_concepts")]
    public List<XConcept> XConcepts { get; set; }

    [JsonPropertyName("counts_by_year")]
    public List<CountsByYear> CountsByYear { get; set; }

    [JsonPropertyName("works_api_url")]
    public string WorksApiUrl { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}

public class Root
{
    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("results")]
    public List<Result> Results { get; set; }

    [JsonPropertyName("group_by")]
    public List<object> GroupBy { get; set; }
}

public class SummaryStats
{
    [JsonPropertyName("2yr_mean_citedness")]
    public double? _2yrMeanCitedness { get; set; }

    [JsonPropertyName("h_index")]
    public int? HIndex { get; set; }

    [JsonPropertyName("i10_index")]
    public int? I10Index { get; set; }
}

public class XConcept
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("wikidata")]
    public string Wikidata { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("level")]
    public int? Level { get; set; }

    [JsonPropertyName("score")]
    public double? Score { get; set; }
}

