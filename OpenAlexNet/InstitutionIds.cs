using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class InstitutionIds
{
    [JsonPropertyName("openalex")]
    public string Openalex { get; set; }

    [JsonPropertyName("ror")]
    public string Ror { get; set; }

    [JsonPropertyName("mag")]
    public string Mag { get; set; }

    [JsonPropertyName("grid")]
    public string Grid { get; set; }

    [JsonPropertyName("wikipedia")]
    public string Wikipedia { get; set; }

    [JsonPropertyName("wikidata")]
    public string Wikidata { get; set; }
}
