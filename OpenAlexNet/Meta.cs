using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Meta
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("db_response_time_ms")]
    public int? DbResponseTimeMs { get; set; }

    [JsonPropertyName("page")]
    public int? Page { get; set; }

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
}

