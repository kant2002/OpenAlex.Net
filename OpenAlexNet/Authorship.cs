using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Authorship
{
    [JsonPropertyName("author_position")]
    public string AuthorPosition { get; set; }

    [JsonPropertyName("author")]
    public WorkAuthor Author { get; set; }

    [JsonPropertyName("institutions")]
    public List<DehydratedInstitution> Institutions { get; set; }

    [JsonPropertyName("is_corresponding")]
    public bool? IsCorresponding { get; set; }

    [JsonPropertyName("raw_affiliation_string")]
    public string RawAffiliationString { get; set; }

    [JsonPropertyName("raw_affiliation_strings")]
    public List<string> RawAffiliationStrings { get; set; }
}
