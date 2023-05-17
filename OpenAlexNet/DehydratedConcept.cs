using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class DehydratedConcept
{
    /// <summary>
    /// Gets or sets The OpenAlex ID for this concept.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets The Wikidata ID for this concept. This is the Canonical External ID for concepts.
    /// </summary>
    [JsonPropertyName("wikidata")]
    public string Wikidata { get; set; }

    /// <summary>
    /// Gets or sets The English-language label of the concept.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    /// <summary>
    /// The level in the concept tree where this concept lives. 
    /// </summary>
    /// <remarks>
    /// Lower-level concepts are more general, and higher-level concepts are more specific.
    /// Computer Science has a level of 0; Java Bytecode has a level of 5.
    /// Level 0 concepts have no ancestors and level 5 concepts have no descendants.
    /// </remarks>
    [JsonPropertyName("level")]
    public int? Level { get; set; }
}
