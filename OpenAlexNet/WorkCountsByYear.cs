using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class WorkCountsByYear
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }
}