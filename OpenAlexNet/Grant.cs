using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Grant
{
    [JsonPropertyName("funder")]
    public string Funder { get; set; }

    [JsonPropertyName("funder_display_name")]
    public string FunderDisplayName { get; set; }

    [JsonPropertyName("award_id")]
    public string? AwardId { get; set; }
}
