using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Location
{
    /// <summary>
    /// Gets or sets a value indicating whether this work is Open Access (OA).
    /// </summary>
    [JsonPropertyName("is_oa")]
    public bool? IsOa { get; set; }

    /// <summary>
    /// Gets or sets the landing page URL for this location.
    /// </summary>
    [JsonPropertyName("landing_page_url")]
    public string LandingPageUrl { get; set; }

    /// <summary>
    /// Gets or sets a URL where you can find this location as a PDF.
    /// </summary>
    [JsonPropertyName("pdf_url")]
    public string PdfUrl { get; set; }

    /// <summary>
    /// Gets or sets information about the source of this location, as a <see cref="DehydratedSource"/> object.
    /// </summary>
    /// <remarks>
    /// The concept of a source is meant to capture a certain social relationship between the host organization and a version of a work. When an organization puts the work on the internet, there is an understanding that they have, at some level, endorsed the work. This level varies, and can be very different depending on the source!
    /// </remarks>
    [JsonPropertyName("source")]
    public DehydratedSource Source { get; set; }

    /// <summary>
    /// Gets or sets the location's publishing license. 
    /// </summary>
    [JsonPropertyName("license")]
    public string License { get; set; }

    /// <summary>
    /// Gets or sets the version of the work, based on the DRIVER Guidelines versioning scheme. 
    /// </summary>
    /// <seealso cref="https://wiki.surfnet.nl/display/DRIVERguidelines/DRIVER-VERSION+Mappings"/>
    [JsonPropertyName("version")]
    public string Version { get; set; }
}
