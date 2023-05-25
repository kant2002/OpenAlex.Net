using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Funder
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("alternate_titles")]
    public List<string> AlternateTitles { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("homepage_url")]
    public string HomePageUrl { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("image_thumbnail_url")]
    public string? ImageThumbnailUrl { get; set; }

    [JsonPropertyName("grants_count")]
    public int? GrantsCount { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("summary_stats")]
    public SummaryStats SummaryStats { get; set; }

    [JsonPropertyName("ids")]
    public FunderIds Ids { get; set; }

    [JsonPropertyName("counts_by_year")]
    public List<WorksAndCitationsCountsByYear> CountsByYear { get; set; }

    [JsonPropertyName("roles")]
    public List<InstitutionRole> Roles { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}
