using System.Text.Json.Serialization;

namespace OpenAlexNet;

/// <summary>
/// Citation metrics for this author or institution.
/// </summary>
public class SummaryStats
{
    /// <summary>
    /// Gets or sets the 2-year mean citedness for this author or institution. Also known as impact factor.
    /// </summary>
    [JsonPropertyName("2yr_mean_citedness")]
    public double? _2yrMeanCitedness { get; set; }

    /// <summary>
    /// Gets or sets the h-index for this author or institution.
    /// </summary>
    [JsonPropertyName("h_index")]
    public int? HIndex { get; set; }

    /// <summary>
    /// Gets or sets The i-10 index for this author or institution.
    /// </summary>
    [JsonPropertyName("i10_index")]
    public int? I10Index { get; set; }
}
