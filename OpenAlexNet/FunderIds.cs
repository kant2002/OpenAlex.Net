using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class FunderIds
{
    [JsonPropertyName("openalex")]
    public string OpenAlex { get; set; }

    [JsonPropertyName("ror")]
    public string Ror { get; set; }

    [JsonPropertyName("wikidata")]
    public string Wikidata { get; set; }
}
