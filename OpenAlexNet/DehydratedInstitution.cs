using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class DehydratedInstitution
{
    /// <summary>
    /// Gets or sets The OpenAlex ID for this institution.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the ROR ID for this institution. This is the Canonical External ID for institutions.
    /// </summary>
    /// <remarks>
    /// The ROR (Research Organization Registry) identifier is a globally unique ID for research organization. ROR is the successor to GRiD, which is no longer being updated.
    /// </remarks>
    /// <seealso cref="https://ror.org/"/>
    /// <seealso cref="https://www.digital-science.com/news/grid-passes-torch-to-ror/"/>
    [JsonPropertyName("ror")]
    public string Ror { get; set; }

    /// <summary>
    /// Gets or sets the primary name of the institution.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the country where this institution is located, represented as an ISO two-letter country code.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the institution's primary type, using the ROR "type" controlled vocabulary.
    /// </summary>
    /// <remarks>Possible values are: Education, Healthcare, Company, Archive, Nonprofit, Government, Facility, and Other.</remarks>
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
