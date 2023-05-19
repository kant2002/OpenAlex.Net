using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class CitationsCountsByYear
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }
}