using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class InstitutionGeo
{
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("geonames_city_id")]
    public string GeonamesCityId { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
}
