using System.Drawing;

namespace OpenAlexNet;

public class WorksFilter
{
    private readonly List<(string, string)> filterValues = new();

    public WorksFilter ByAuthorId(string value)
    {
        return FilterBy("author.id", value);
    }

    public WorksFilter ByOrcId(string value)
    {
        return FilterBy("author.orcid", value);
    }

    public WorksFilter ByCountryCode(string value)
    {
        return FilterBy("institutions.country_code", value);
    }

    public WorksFilter ByInstitutionsId(string value)
    {
        return FilterBy("institutions.id", value);
    }

    public WorksFilter ByInstitutionsRor(string value)
    {
        return FilterBy("institutions.ror", value);
    }

    public WorksFilter ByInstitutionsType(string value)
    {
        return FilterBy("institutions.type", value);
    }

    public WorksFilter IsCorresponding(bool value)
    {
        return FilterBy("is_corresponding", value);
    }

    public WorksFilter ByApcPaymentPrice(int value)
    {
        return FilterBy("apc_payment.price", value);
    }

    public WorksFilter ByApcPaymentPrice(FilterOperator filterOperator, int value)
    {
        return FilterBy("apc_payment.price", filterOperator, value);
    }

    public WorksFilter ByApcPaymentCurrency(string value)
    {
        return FilterBy("apc_payment.currency", value);
    }

    public WorksFilter ByApcPaymentProvenance(string value)
    {
        return FilterBy("apc_payment.provenance", value);
    }

    public WorksFilter ByApcPaymentPriceUse(int value)
    {
        return FilterBy("apc_payment.price_usd", value);
    }

    public WorksFilter ByApcPaymentPriceUse(FilterOperator filterOperator, int value)
    {
        return FilterBy("apc_payment.price_usd", filterOperator, value);
    }

    public WorksFilter ByBestOpenAccessLocationIsOpenAccess(bool value)
    {
        return FilterBy("best_oa_location.is_oa", value);
    }

    public WorksFilter ByBestOpenAccessLocationLicense(string value)
    {
        return FilterBy("best_oa_location.license", value);
    }

    public WorksFilter ByBestOpenAccessLocationSourceId(string value)
    {
        return FilterBy("best_oa_location.source.id", value);
    }

    public WorksFilter ByBestOpenAccessLocationSourceIssn(string value)
    {
        return FilterBy("best_oa_location.source.issn", value);
    }

    public WorksFilter ByBestOpenAccessLocationSourceHostOrganization(string value)
    {
        return FilterBy("best_oa_location.source.host_organization", value);
    }

    public WorksFilter ByBestOpenAccessLocationSourceType(string value)
    {
        return FilterBy("best_oa_location.source.type", value);
    }

    public WorksFilter ByBestOpenAccessLocationVersion(string value)
    {
        return FilterBy("best_oa_location.version", value);
    }

    public WorksFilter ByCitedByCount(int value)
    {
        return FilterBy("cited_by_count", value);
    }

    public WorksFilter ByCitedByCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("cited_by_count", filterOperator, value);
    }

    public WorksFilter ByConceptsId(string value)
    {
        return FilterBy("concepts.id", value);
    }

    public WorksFilter ByConceptsWikidata(string value)
    {
        return FilterBy("concepts.wikidata", value);
    }

    public WorksFilter ByCorrespondingAuthorIds(string value)
    {
        return FilterBy("corresponding_author_ids", value);
    }

    public WorksFilter ByCorrespondingInstitutionIds(string value)
    {
        return FilterBy("corresponding_institution_ids", value);
    }

    public WorksFilter SearchAbstract(string value)
    {
        return FilterBy("abstract.search", value);
    }

    public WorksFilter ByInstitutionContinent(string value)
    {
        return FilterBy("authorships.institutions.continent", value);
    }

    public WorksFilter IsInstitutionGlobalSouth(bool value)
    {
        return FilterBy("authorships.institutions.is_global_south", value);
    }

    public WorksFilter ByAuthorsCount(int count)
    {
        return ByAuthorsCount(FilterOperator.Equals, count);
    }

    public WorksFilter ByAuthorsCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("authors_count", filterOperator, value);
    }

    public WorksFilter ByBestOpenVersion(string value)
    {
        return FilterBy("best_open_version", value);
    }

    public WorksFilter CitedBy(string value)
    {
        return FilterBy("cited_by", value);
    }

    public WorksFilter Cites(string value)
    {
        return FilterBy("cities", value);
    }

    public WorksFilter ConceptsCount(int value)
    {
        return FilterBy("concepts_count", value);
    }

    public WorksFilter ConceptsCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("concepts_count", filterOperator, value);
    }

    public WorksFilter DefaultSearch(string value)
    {
        return FilterBy("default.search", value);
    }

    public WorksFilter DisplayNameSearch(string value)
    {
        return FilterBy("display_name.search", value);
    }

    public WorksFilter FromCreatedDate(string value)
    {
        return FilterBy("from_created_date", value);
    }

#if NET6_0_OR_GREATER
    public WorksFilter FromCreatedDate(DateOnly value)
    {
        return FilterBy("from_created_date", value);
    }
#endif

    public WorksFilter FromPublicationDate(string value)
    {
        return FilterBy("from_publication_date", value);
    }

#if NET6_0_OR_GREATER
    public WorksFilter FromPublicationDate(DateOnly value)
    {
        return FilterBy("from_publication_date", value);
    }
#endif

    public WorksFilter FromUpdatedDate(string value)
    {
        return FilterBy("from_updated_date", value);
    }

    public WorksFilter FromUpdatedDate(DateTime value)
    {
        return FilterBy("from_updated_date", value);
    }

    public WorksFilter FullTextSearch(string value)
    {
        return FilterBy("fulltext.search", value);
    }

    public WorksFilter HasDoi(bool value)
    {
        return FilterBy("has_doi", value);
    }

    public WorksFilter HasOpenAccessAcceptedOrPublishedVersion(bool value)
    {
        return FilterBy("has_oa_accepted_or_published_version", value);
    }

    public WorksFilter HasOpenAccessSubmittedVersion(bool value)
    {
        return FilterBy("has_oa_submitted_version", value);
    }

    public WorksFilter HasOrcId(bool value)
    {
        return FilterBy("has_orcid", value);
    }

    public WorksFilter HasPmcId(bool value)
    {
        return FilterBy("has_pmcid", value);
    }

    public WorksFilter HasPmId(bool value)
    {
        return FilterBy("has_pmid", value);
    }

    public WorksFilter HasNgrams(bool value)
    {
        return FilterBy("has_ngrams", value);
    }

    public WorksFilter HasReferences(bool value)
    {
        return FilterBy("has_references", value);
    }

    public WorksFilter Journal(string value)
    {
        return FilterBy("journal", value);
    }

    public WorksFilter HostInstitutionLineage(string value)
    {
        return FilterBy("locations.source.host_institution_lineage", value);
    }

    public WorksFilter PublisherLineage(string value)
    {
        return FilterBy("locations.source.publisher_lineage", value);
    }

    public WorksFilter HasIssn(bool value)
    {
        return FilterBy("primary_location.source.has_issn", value);
    }

    public WorksFilter SearchRawAffiliationString(string value)
    {
        return FilterBy("raw_affiliation_string.search", value);
    }

    public WorksFilter RelatedTo(string value)
    {
        return FilterBy("related_to", value);
    }

    public WorksFilter Repository(string value)
    {
        return FilterBy("repository", value);
    }

    public WorksFilter ToPublicationDate(string value)
    {
        return FilterBy("to_publication_date", value);
    }

#if NET6_0_OR_GREATER
    public WorksFilter ToPublicationDate(DateOnly value)
    {
        return FilterBy("to_publication_date", value);
    }
#endif

    public WorksFilter Version(string value)
    {
        return FilterBy("version", value);
    }

    public WorksFilter FilterBy(string key, string value)
    {
        filterValues.Add((key, value));
        return this;
    }

    public WorksFilter FilterBy(string key, bool value)
    {
        filterValues.Add((key, value ? "true" : "false"));
        return this;
    }

    public WorksFilter FilterBy(string key, int value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public WorksFilter FilterBy(string key, FilterOperator filterOperator, int value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public WorksFilter FilterBy(string key, DateTime value)
    {
        filterValues.Add((key, value.ToString("yyyy-MM-dd")));
        return this;
    }

#if NET6_0_OR_GREATER

    public WorksFilter FilterBy(string key, DateOnly value)
    {
        filterValues.Add((key, value.ToString("yyyy-MM-dd")));
        return this;
    }
#endif

    private string GetFilterOperatorPrefix(FilterOperator filterOperator) => filterOperator switch
    {
        FilterOperator.Greater => ">",
        FilterOperator.Less => "<",
        FilterOperator.Equals => "",
        FilterOperator.NotEquals => "!",
        _ => throw new ArgumentOutOfRangeException(nameof(filterOperator)),
    };

    public override string ToString()
    {
        return string.Join(",", filterValues.Select(_ => $"{_.Item1}:{_.Item2}"));
    }
}
