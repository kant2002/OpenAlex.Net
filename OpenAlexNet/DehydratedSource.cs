using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class DehydratedSource
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    [JsonPropertyName("issn_l")]
    public string IssnL { get; set; }

    [JsonPropertyName("issn")]
    public List<string> Issn { get; set; }

    [JsonPropertyName("host_organization")]
    public string HostOrganization { get; set; }

    [JsonPropertyName("host_organization_name")]
    public string HostOrganizationName { get; set; }

    [JsonPropertyName("host_organization_lineage")]
    public List<string> HostOrganizationLineage { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
