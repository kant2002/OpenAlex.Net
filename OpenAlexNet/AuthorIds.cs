using System.Text.Json.Serialization;

namespace OpenAlexNet;

/// <summary>
/// All the external identifiers that we know about for this author. IDs are expressed as URIs whenever possible
/// </summary>
public class AuthorIds
{
    /// <summary>
    /// Gets or sets this author's OpenAlex ID. Same as <see cref="Author.Id"/>.
    /// </summary>
    [JsonPropertyName("openalex")]
    public string? OpenAlex { get; set; }

    /// <summary>
    /// Gets or sets this author's ORCID ID. Same as <see cref="Author.Orcid"/>.
    /// </summary>
    /// <seealso cref="https://orcid.org/"/>
    [JsonPropertyName("orcid")]
    public string? OrcId { get; set; }

    /// <summary>
    /// Gets or sets this author's Microsoft Academic Graph ID
    /// </summary>
    /// <seealso cref="https://www.microsoft.com/en-us/research/project/microsoft-academic-graph/"/>
    [JsonPropertyName("mag")]
    public string? Mag { get; set; }

    /// <summary>
    /// Gets or sets this author's Scopus author ID.
    /// </summary>
    /// <seealso cref="https://utas.libguides.com/ManageID/Scopus"/>
    [JsonPropertyName("scopus")]
    public string? Scopus { get; set; }

    /// <summary>
    /// Gets or sets this author's Twitter handle
    /// </summary>
    [JsonPropertyName("twitter")]
    public string? Twitter { get; set; }

    /// <summary>
    /// Gets or sets this author's Wikipedia page
    /// </summary>
    [JsonPropertyName("wikipedia")]
    public string? Wikipedia { get; set; }
}

