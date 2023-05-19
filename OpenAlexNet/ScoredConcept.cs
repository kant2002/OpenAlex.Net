using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class ScoredConcept: DehydratedConcept
{
    /// <summary>
    /// Gets or sets The strength of association between this author and the listed concept, from 0-100.
    /// </summary>
    [JsonPropertyName("score")]
    public double? Score { get; set; }
}
