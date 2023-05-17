﻿using System.Text.Json.Serialization;

namespace OpenAlexNet;

public class Author
{
    /// <summary>
    /// Gets or sets The OpenAlex ID for this author.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("orcid")]
    public string Orcid { get; set; }

    /// <summary>
    /// Gets or sets the name of the author as a single string.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets other ways that we've found this author's name displayed.
    /// </summary>
    [JsonPropertyName("display_name_alternatives")]
    public List<object> DisplayNameAlternatives { get; set; }

    [JsonPropertyName("relevance_score")]
    public double? RelevanceScore { get; set; }

    [JsonPropertyName("works_count")]
    public int? WorksCount { get; set; }

    /// <summary>
    /// Gets or sets the total number of Works that cite a work this author has created.
    /// </summary>
    [JsonPropertyName("cited_by_count")]
    public int? CitedByCount { get; set; }

    [JsonPropertyName("summary_stats")]
    public SummaryStats SummaryStats { get; set; }

    /// <summary>
    /// Gets or sets all the external identifiers that we know about for this author. IDs are expressed as URIs whenever possible
    /// </summary>
    [JsonPropertyName("ids")]
    public AuthorIds Ids { get; set; }

    /// <summary>
    /// Gets or sets this author's last known institutional affiliation.
    /// </summary>
    /// <remarks>
    /// In this context "last known" means that we took all the Works where this author has an institutional affiliation, sorted them by publication date, and selected the most recent one.
    /// </remarks>
    [JsonPropertyName("last_known_institution")]
    public DehydratedInstitution LastKnownInstitution { get; set; }

    [JsonPropertyName("x_concepts")]
    public List<AuthorConcept> XConcepts { get; set; }

    /// <summary>
    /// Gets or sets <see cref="Author.works_count"/> and <see cref="Author.cited_by_count"/> for each of the last ten years, binned by year.
    /// </summary>
    /// <remarks>
    /// <para>To put it another way: each year, you can see how many works this author published, and how many times they got cited.</para>
    /// <para>Any works or citations older than ten years old aren't included. Years with zero works and zero citations have been removed so you will need to add those in if you need them.</para>
    /// </remarks>
    [JsonPropertyName("counts_by_year")]
    public List<AuthorWorkCountsByYear> CountsByYear { get; set; }

    [JsonPropertyName("works_api_url")]
    public string WorksApiUrl { get; set; }

    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date this <see cref="Author"/> object was created in the OpenAlex dataset, expressed as an ISO 8601 date string.
    /// </summary>
    [JsonPropertyName("created_date")]
    public string CreatedDate { get; set; }
}