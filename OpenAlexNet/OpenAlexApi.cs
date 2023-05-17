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


// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class AbstractInvertedIndex
{
    [JsonPropertyName("Varvara")]
    public List<int?> Varvara { get; set; }

    [JsonPropertyName("Logacheva,")]
    public List<int?> Logacheva { get; set; }

    [JsonPropertyName("Daryna")]
    public List<int?> Daryna { get; set; }

    [JsonPropertyName("Dementieva,")]
    public List<int?> Dementieva { get; set; }

    [JsonPropertyName("Irina")]
    public List<int?> Irina { get; set; }

    [JsonPropertyName("Krotova,")]
    public List<int?> Krotova { get; set; }

    [JsonPropertyName("Alena")]
    public List<int?> Alena { get; set; }

    [JsonPropertyName("Fenogenova,")]
    public List<int?> Fenogenova { get; set; }

    [JsonPropertyName("Nikishina,")]
    public List<int?> Nikishina { get; set; }

    [JsonPropertyName("Tatiana")]
    public List<int?> Tatiana { get; set; }

    [JsonPropertyName("Shavrina,")]
    public List<int?> Shavrina { get; set; }

    [JsonPropertyName("Alexander")]
    public List<int?> Alexander { get; set; }

    [JsonPropertyName("Panchenko.")]
    public List<int?> Panchenko { get; set; }

    [JsonPropertyName("Proceedings")]
    public List<int?> Proceedings { get; set; }

    [JsonPropertyName("of")]
    public List<int?> Of { get; set; }

    [JsonPropertyName("the")]
    public List<int?> The { get; set; }

    [JsonPropertyName("2nd")]
    public List<int?> _2nd { get; set; }

    [JsonPropertyName("Workshop")]
    public List<int?> Workshop { get; set; }

    [JsonPropertyName("on")]
    public List<int?> On { get; set; }

    [JsonPropertyName("Human")]
    public List<int?> Human { get; set; }

    [JsonPropertyName("Evaluation")]
    public List<int?> Evaluation { get; set; }

    [JsonPropertyName("NLP")]
    public List<int?> NLP { get; set; }

    [JsonPropertyName("Systems")]
    public List<int?> Systems { get; set; }

    [JsonPropertyName("(HumEval).")]
    public List<int?> HumEval { get; set; }

    [JsonPropertyName("2022.")]
    public List<int?> _2022 { get; set; }
}

public class WorkAuthor
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("orcid")]
    public object Orcid { get; set; }
}

public class Authorship
{
    [JsonPropertyName("author_position")]
    public string AuthorPosition { get; set; }

    [JsonPropertyName("author")]
    public WorkAuthor Author { get; set; }

    [JsonPropertyName("institutions")]
    public List<DehydratedInstitution> Institutions { get; set; }

    [JsonPropertyName("is_corresponding")]
    public bool? IsCorresponding { get; set; }

    [JsonPropertyName("raw_affiliation_string")]
    public string RawAffiliationString { get; set; }

    [JsonPropertyName("raw_affiliation_strings")]
    public List<string> RawAffiliationStrings { get; set; }
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

public class Location
{
    /// <summary>
    /// Gets or sets a value indicating whether this work is Open Access (OA).
    /// </summary>
    [JsonPropertyName("is_oa")]
    public bool? IsOa { get; set; }

    /// <summary>
    /// Gets or sets the landing page URL for this location.
    /// </summary>
    [JsonPropertyName("landing_page_url")]
    public string LandingPageUrl { get; set; }

    /// <summary>
    /// Gets or sets a URL where you can find this location as a PDF.
    /// </summary>
    [JsonPropertyName("pdf_url")]
    public object PdfUrl { get; set; }

    /// <summary>
    /// Gets or sets information about the source of this location, as a <see cref="DehydratedSource"/> object.
    /// </summary>
    /// <remarks>
    /// The concept of a source is meant to capture a certain social relationship between the host organization and a version of a work. When an organization puts the work on the internet, there is an understanding that they have, at some level, endorsed the work. This level varies, and can be very different depending on the source!
    /// </remarks>
    [JsonPropertyName("source")]
    public DehydratedSource Source { get; set; }

    /// <summary>
    /// Gets or sets the location's publishing license. 
    /// </summary>
    [JsonPropertyName("license")]
    public string License { get; set; }

    /// <summary>
    /// Gets or sets the version of the work, based on the DRIVER Guidelines versioning scheme. 
    /// </summary>
    /// <seealso cref="https://wiki.surfnet.nl/display/DRIVERguidelines/DRIVER-VERSION+Mappings"/>
    [JsonPropertyName("version")]
    public string Version { get; set; }
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

public class Work
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("doi")]
    public string Doi { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("publication_year")]
    public int? PublicationYear { get; set; }

    [JsonPropertyName("publication_date")]
    public string PublicationDate { get; set; }

    [JsonPropertyName("ids")]
    public WorkIds Ids { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("primary_location")]
    public Location PrimaryLocation { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("open_access")]
    public OpenAccess OpenAccess { get; set; }

    [JsonPropertyName("authorships")]
    public List<Authorship> Authorships { get; set; }

    [JsonPropertyName("corresponding_author_ids")]
    public List<string> CorrespondingAuthorIds { get; set; }

    [JsonPropertyName("corresponding_institution_ids")]
    public List<string> CorrespondingInstitutionIds { get; set; }

    [JsonPropertyName("apc_payment")]
    public object ApcPayment { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("biblio")]
    public Biblio Biblio { get; set; }

    [JsonPropertyName("is_retracted")]
    public bool? IsRetracted { get; set; }

    [JsonPropertyName("is_paratext")]
    public bool? IsParatext { get; set; }

    [JsonPropertyName("concepts")]
    public List<Concept> Concepts { get; set; }

    [JsonPropertyName("mesh")]
    public List<object> Mesh { get; set; }

    [JsonPropertyName("locations_count")]
    public int? LocationsCount { get; set; }

    [JsonPropertyName("locations")]
    public List<Location> Locations { get; set; }

    [JsonPropertyName("best_oa_location")]
    public Location BestOaLocation { get; set; }

    [JsonPropertyName("grants")]
    public List<object> Grants { get; set; }

    [JsonPropertyName("referenced_works")]
    public List<object> ReferencedWorks { get; set; }

    [JsonPropertyName("related_works")]
    public List<string> RelatedWorks { get; set; }

    [JsonPropertyName("ngrams_url")]
    public string NgramsUrl { get; set; }

    [JsonPropertyName("abstract_inverted_index")]
    public AbstractInvertedIndex AbstractInvertedIndex { get; set; }

    [JsonPropertyName("cited_by_api_url")]
    public string CitedByApiUrl { get; set; }

    [JsonPropertyName("counts_by_year")]
    public List<object> CountsByYear { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}
