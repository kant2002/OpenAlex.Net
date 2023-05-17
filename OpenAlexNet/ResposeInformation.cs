using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class ResposeInformation<T>
{
    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; set; }

    [JsonPropertyName("group_by")]
    public List<object> GroupBy { get; set; }
}

