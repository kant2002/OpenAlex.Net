using System.Text.Json.Serialization;

namespace OpenAlexNet;

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
    public ApcPayment ApcPayment { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("biblio")]
    public Biblio Biblio { get; set; }

    [JsonPropertyName("is_retracted")]
    public bool? IsRetracted { get; set; }

    [JsonPropertyName("is_paratext")]
    public bool? IsParatext { get; set; }

    [JsonPropertyName("concepts")]
    public List<DehydratedConcept> Concepts { get; set; }

    [JsonPropertyName("mesh")]
    public List<object> Mesh { get; set; }

    [JsonPropertyName("locations_count")]
    public int? LocationsCount { get; set; }

    [JsonPropertyName("locations")]
    public List<Location> Locations { get; set; }

    [JsonPropertyName("best_oa_location")]
    public Location BestOaLocation { get; set; }

    [JsonPropertyName("grants")]
    public List<Grant> Grants { get; set; }

    [JsonPropertyName("referenced_works")]
    public List<string> ReferencedWorks { get; set; }

    [JsonPropertyName("related_works")]
    public List<string> RelatedWorks { get; set; }

    [JsonPropertyName("ngrams_url")]
    public string NgramsUrl { get; set; }

    [JsonPropertyName("abstract_inverted_index")]
    public object AbstractInvertedIndex { get; set; }

    [JsonPropertyName("cited_by_api_url")]
    public string CitedByApiUrl { get; set; }

    [JsonPropertyName("counts_by_year")]
    public List<CitationsCountsByYear> CountsByYear { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}
