using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class ApcPayment
{
    [JsonPropertyName("price")]
    public int? Price { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("provenance")]
    public string Provenance { get; set; }

    [JsonPropertyName("price_usd")]
    public int? PriceUsd { get; set; }
}
