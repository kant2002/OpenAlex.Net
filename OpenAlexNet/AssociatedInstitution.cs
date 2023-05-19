using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class AssociatedInstitution : DehydratedInstitution
{
    [JsonPropertyName("relationship")]
    public string Relationship { get; set; }
}
