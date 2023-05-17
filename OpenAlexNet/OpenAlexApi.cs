using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace OpenAlexNet;

public class OpenAlexApi
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

    public async Task<ResposeInformation<Author>?> SearchAuthorsAsync(string author)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/authors"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = author;
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Author>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<Author?> GetAuthorAsync(string authorId)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/authors/" + authorId));
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<Author>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Work>?> FindWorksByAuthorAsync(string author)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/works"));
        var query = HttpUtility.ParseQueryString("");
        query["filter"] = $"author.id:{author}";
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Work>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }
}

public class Biblio
{
    [JsonPropertyName("volume")]
    public object Volume { get; set; }

    [JsonPropertyName("issue")]
    public object Issue { get; set; }

    [JsonPropertyName("first_page")]
    public object FirstPage { get; set; }

    [JsonPropertyName("last_page")]
    public object LastPage { get; set; }
}

public class Concept
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

public class WorkIds
{
    [JsonPropertyName("openalex")]
    public string Openalex { get; set; }

    [JsonPropertyName("doi")]
    public string Doi { get; set; }
}

public class DehydratedSource
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("issn_l")]
    public object IssnL { get; set; }

    [JsonPropertyName("issn")]
    public object Issn { get; set; }

    [JsonPropertyName("host_organization")]
    public string HostOrganization { get; set; }

    [JsonPropertyName("host_organization_name")]
    public string HostOrganizationName { get; set; }

    [JsonPropertyName("host_organization_lineage")]
    public List<string> HostOrganizationLineage { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class OpenAccess
{
    [JsonPropertyName("is_oa")]
    public bool? IsOa { get; set; }

    [JsonPropertyName("oa_status")]
    public string OaStatus { get; set; }

    [JsonPropertyName("oa_url")]
    public string OaUrl { get; set; }

    [JsonPropertyName("any_repository_has_fulltext")]
    public bool? AnyRepositoryHasFulltext { get; set; }
}
