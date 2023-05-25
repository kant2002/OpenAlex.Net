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

    public async Task<ResposeInformation<Author>?> SearchAuthorsAsync(string searchString, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/authors"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = searchString;
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Author>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Author>?> FindAuthorsAsync(AuthorsFilter filter, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/authors"));
        var query = HttpUtility.ParseQueryString("");
        query["filter"] = filter.ToString();
        ApplyDefaultPaginationParameters(query, page, perPage);
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

    public async Task<ResposeInformation<Work>?> SearchWorksAsync(string searchString, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/works"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = searchString;
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Work>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<Work?> GetWorkAsync(string workId)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/works/" + workId));
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<Work>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Work>?> FindWorksAsync(WorksFilter filter, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/works"));
        var query = HttpUtility.ParseQueryString("");
        query["filter"] = filter.ToString();
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Work>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Work>?> FindWorksByAuthorAsync(string author, int page = 1, int perPage = 0)
    {
        var filter = new WorksFilter().ByAuthorId(author);
        return await FindWorksAsync(filter, page, perPage);
    }

    public async Task<ResposeInformation<Work>?> FindWorksByAffiliationAsync(string affiliation, int page = 1, int perPage = 0)
    {
        var filter = new WorksFilter().SearchRawAffiliationString(affiliation);
        return await FindWorksAsync(filter, page, perPage);
    }

    public async Task<Institution?> GetInstitutionAsync(string workId)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/institutions/" + workId));
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<Institution>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Institution>?> SearchInstitutionsAsync(string searchString, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/institutions"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = searchString;
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Institution>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Institution>?> FindInstitutionsAsync(InstitutionsFilter filter, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/institutions"));
        var query = HttpUtility.ParseQueryString("");
        query["filter"] = filter.ToString();
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Institution>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<Funder?> GetFunderAsync(string funderId)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/funders/" + funderId));
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<Funder>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Funder>?> SearchFundersAsync(string searchString, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/funders"));
        var query = HttpUtility.ParseQueryString("");
        query["search"] = searchString;
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Funder>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    public async Task<ResposeInformation<Funder>?> FindFundersAsync(FundersFilter filter, int page = 1, int perPage = 0)
    {
        var builder = new UriBuilder(new Uri(BaseAddress, "/funders"));
        var query = HttpUtility.ParseQueryString("");
        query["filter"] = filter.ToString();
        ApplyDefaultPaginationParameters(query, page, perPage);
        builder.Query = query.ToString();
        string url = builder.ToString();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
        var response = JsonSerializer.Deserialize<ResposeInformation<Funder>>(await responseMessage.Content.ReadAsStreamAsync());
        return response;
    }

    private static void ApplyDefaultPaginationParameters(System.Collections.Specialized.NameValueCollection query, int page, int perPage)
    {
        if (page > 1)
        {
            query["page"] = page.ToString();
        }

        if (perPage > 0)
        {
            query["per-page"] = perPage.ToString();
        }
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

public class Repository
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("host_organization")]
    public string HostOrganization { get; set; }

    [JsonPropertyName("host_organization_name")]
    public string HostOrganizationName { get; set; }

    [JsonPropertyName("host_organization_lineage")]
    public List<string> HostOrganizationLineage { get; set; }
}

public class InstitutionRole
{
    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }
}

public class Institution
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

    [JsonPropertyName("homepage_url")]
    public string HomepageUrl { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("image_thumbnail_url")]
    public string ImageThumbnailUrl { get; set; }

    [JsonPropertyName("display_name_acronyms")]
    public List<string> DisplayNameAcronyms { get; set; }

    [JsonPropertyName("display_name_alternatives")]
    public List<string> DisplayNameAlternatives { get; set; }

    [JsonPropertyName("repositories")]
    public List<Repository> Repositories { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("summary_stats")]
    public SummaryStats SummaryStats { get; set; }

    [JsonPropertyName("ids")]
    public InstitutionIds Ids { get; set; }

    [JsonPropertyName("geo")]
    public InstitutionGeo Geo { get; set; }

    [JsonPropertyName("international")]
    public International International { get; set; }

    [JsonPropertyName("associated_institutions")]
    public List<AssociatedInstitution> AssociatedInstitutions { get; set; }

    [JsonPropertyName("counts_by_year")]
    public List<WorksAndCitationsCountsByYear> CountsByYear { get; set; }

    [JsonPropertyName("roles")]
    public List<InstitutionRole> Roles { get; set; }

    [JsonPropertyName("x_concepts")]
    public List<ScoredConcept> XConcepts { get; set; }

    [JsonPropertyName("works_api_url")]
    public string WorksApiUrl { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}
