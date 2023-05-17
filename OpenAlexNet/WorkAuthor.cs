using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class WorkAuthor
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("orcid")]
    public string Orcid { get; set; }
}
