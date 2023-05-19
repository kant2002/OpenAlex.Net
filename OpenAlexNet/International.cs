using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class International
{
    [JsonPropertyName("display_name")]
    public Dictionary<string, string> DisplayName { get; set; }
}
