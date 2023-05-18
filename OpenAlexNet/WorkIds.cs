using System.Text.Json.Serialization;

namespace OpenAlexNet;

/// <summary>
/// All the external identifiers that we know about for this work. IDs are expressed as URIs whenever possible.
/// </summary>
public class WorkIds
{
    /// <summary>
    /// Gets or sets this works's OpenAlex ID. Same as <see cref="Work.Id"/>.
    /// </summary>
    [JsonPropertyName("openalex")]
    public string OpenAlex { get; set; }

    /// <summary>
    /// Gets or sets this works's DOI. Same as <see cref="Work.Doi"/>.
    /// </summary>
    /// <seealso cref="https://en.wikipedia.org/wiki/Digital_object_identifier"/>
    [JsonPropertyName("doi")]
    public string Doi { get; set; }

    /// <summary>
    /// Gets or sets this works's Microsoft Academic Graph ID
    /// </summary>
    /// <seealso cref="https://www.microsoft.com/en-us/research/project/microsoft-academic-graph/"/>
    [JsonPropertyName("mag")]
    public string? Mag { get; set; }

    /// <summary>
    /// Gets or sets the Pubmed Identifier
    /// </summary>
    /// <seealso cref="https://en.wikipedia.org/wiki/PubMed#PubMed_identifier"/>
    [JsonPropertyName("pmid")]
    public string? PmId { get; set; }

    /// <summary>
    /// Gets or sets the Pubmed Central Identifier
    /// </summary>
    /// <seealso cref="https://www.ncbi.nlm.nih.gov/pmc/about/public-access-info/"/>
    [JsonPropertyName("pmcid")]
    public string? PmcId { get; set; }
}
