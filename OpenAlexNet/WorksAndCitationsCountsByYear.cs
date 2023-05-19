using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class WorksAndCitationsCountsByYear
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }
}
