using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class AuthorIds
{
    [JsonPropertyName("openalex")]
    public string OpenAlex { get; set; }

    [JsonPropertyName("orcid")]
    public string OrcId { get; set; }

    [JsonPropertyName("mag")]
    public string Mag { get; set; }

    [JsonPropertyName("scopus")]
    public string Scopus { get; set; }

    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("wikipedia")]
    public string Wikipedia { get; set; }
}

