namespace OpenAlexNet;

using System.Web;
using FilterClass = WorksFilter;

public class WorksFilter
{
    private readonly List<(string, string)> filterValues = new();

    public FilterClass ByAuthorId(string value)
    {
        return FilterBy("author.id", value);
    }

    public FilterClass ByOrcId(string value)
    {
        return FilterBy("author.orcid", value);
    }

    public FilterClass ByCountryCode(string value)
    {
        return FilterBy("institutions.country_code", value);
    }

    public FilterClass ByInstitutionsId(string value)
    {
        return FilterBy("institutions.id", value);
    }

    public FilterClass ByInstitutionsId(IEnumerable<string> value)
    {
        return FilterBy("institutions.id", value);
    }

    public FilterClass ByInstitutionsRor(string value)
    {
        return FilterBy("institutions.ror", value);
    }

    public FilterClass ByInstitutionsType(string value)
    {
        return FilterBy("institutions.type", value);
    }

    public FilterClass IsCorresponding(bool value)
    {
        return FilterBy("is_corresponding", value);
    }

    public FilterClass ByApcPaymentPrice(int value)
    {
        return FilterBy("apc_payment.price", value);
    }

    public FilterClass ByApcPaymentPrice(FilterOperator filterOperator, int value)
    {
        return FilterBy("apc_payment.price", filterOperator, value);
    }

    public FilterClass ByApcPaymentCurrency(string value)
    {
        return FilterBy("apc_payment.currency", value);
    }

    public FilterClass ByApcPaymentProvenance(string value)
    {
        return FilterBy("apc_payment.provenance", value);
    }

    public FilterClass ByApcPaymentPriceUse(int value)
    {
        return FilterBy("apc_payment.price_usd", value);
    }

    public FilterClass ByApcPaymentPriceUse(FilterOperator filterOperator, int value)
    {
        return FilterBy("apc_payment.price_usd", filterOperator, value);
    }

    public FilterClass ByBestOpenAccessLocationIsOpenAccess(bool value)
    {
        return FilterBy("best_oa_location.is_oa", value);
    }

    public FilterClass ByBestOpenAccessLocationLicense(string value)
    {
        return FilterBy("best_oa_location.license", value);
    }

    public FilterClass ByBestOpenAccessLocationSourceId(string value)
    {
        return FilterBy("best_oa_location.source.id", value);
    }

    public FilterClass ByBestOpenAccessLocationSourceIssn(string value)
    {
        return FilterBy("best_oa_location.source.issn", value);
    }

    public FilterClass ByBestOpenAccessLocationSourceHostOrganization(string value)
    {
        return FilterBy("best_oa_location.source.host_organization", value);
    }

    public FilterClass ByBestOpenAccessLocationSourceType(string value)
    {
        return FilterBy("best_oa_location.source.type", value);
    }

    public FilterClass ByBestOpenAccessLocationVersion(string value)
    {
        return FilterBy("best_oa_location.version", value);
    }

    public FilterClass ByCitedByCount(int value)
    {
        return FilterBy("cited_by_count", value);
    }

    public FilterClass ByCitedByCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("cited_by_count", filterOperator, value);
    }

    public FilterClass ByConceptsId(string value)
    {
        return FilterBy("concepts.id", value);
    }

    public FilterClass ByConceptsWikidata(string value)
    {
        return FilterBy("concepts.wikidata", value);
    }

    public FilterClass ByCorrespondingAuthorIds(string value)
    {
        return FilterBy("corresponding_author_ids", value);
    }

    public FilterClass ByCorrespondingInstitutionIds(string value)
    {
        return FilterBy("corresponding_institution_ids", value);
    }

    public FilterClass SearchAbstract(string value)
    {
        return FilterBy("abstract.search", value);
    }

    public FilterClass ByInstitutionContinent(string value)
    {
        return FilterBy("authorships.institutions.continent", value);
    }

    public FilterClass IsInstitutionGlobalSouth(bool value)
    {
        return FilterBy("authorships.institutions.is_global_south", value);
    }

    public FilterClass ByAuthorsCount(int count)
    {
        return ByAuthorsCount(FilterOperator.Equals, count);
    }

    public FilterClass ByAuthorsCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("authors_count", filterOperator, value);
    }

    public FilterClass ByBestOpenVersion(string value)
    {
        return FilterBy("best_open_version", value);
    }

    public FilterClass CitedBy(string value)
    {
        return FilterBy("cited_by", value);
    }

    public FilterClass Cites(string value)
    {
        return FilterBy("cities", value);
    }

    public FilterClass ConceptsCount(int value)
    {
        return FilterBy("concepts_count", value);
    }

    public FilterClass ConceptsCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("concepts_count", filterOperator, value);
    }

    public FilterClass DefaultSearch(string value)
    {
        return FilterBy("default.search", value);
    }

    public FilterClass DisplayNameSearch(string value)
    {
        return FilterBy("display_name.search", value);
    }

    public FilterClass FromCreatedDate(string value)
    {
        return FilterBy("from_created_date", value);
    }

#if NET6_0_OR_GREATER
    public FilterClass FromCreatedDate(DateOnly value)
    {
        return FilterBy("from_created_date", value);
    }
#endif

    public FilterClass FromPublicationDate(string value)
    {
        return FilterBy("from_publication_date", value);
    }

#if NET6_0_OR_GREATER
    public FilterClass FromPublicationDate(DateOnly value)
    {
        return FilterBy("from_publication_date", value);
    }
#endif

    public FilterClass FromUpdatedDate(string value)
    {
        return FilterBy("from_updated_date", value);
    }

    public FilterClass FromUpdatedDate(DateTime value)
    {
        return FilterBy("from_updated_date", value);
    }

    public FilterClass FullTextSearch(string value)
    {
        return FilterBy("fulltext.search", value);
    }

    public FilterClass HasDoi(bool value)
    {
        return FilterBy("has_doi", value);
    }

    public FilterClass HasOpenAccessAcceptedOrPublishedVersion(bool value)
    {
        return FilterBy("has_oa_accepted_or_published_version", value);
    }

    public FilterClass HasOpenAccessSubmittedVersion(bool value)
    {
        return FilterBy("has_oa_submitted_version", value);
    }

    public FilterClass HasOrcId(bool value)
    {
        return FilterBy("has_orcid", value);
    }

    public FilterClass HasPmcId(bool value)
    {
        return FilterBy("has_pmcid", value);
    }

    public FilterClass HasPmId(bool value)
    {
        return FilterBy("has_pmid", value);
    }

    public FilterClass HasNgrams(bool value)
    {
        return FilterBy("has_ngrams", value);
    }

    public FilterClass HasReferences(bool value)
    {
        return FilterBy("has_references", value);
    }

    public FilterClass Journal(string value)
    {
        return FilterBy("journal", value);
    }

    public FilterClass HostInstitutionLineage(string value)
    {
        return FilterBy("locations.source.host_institution_lineage", value);
    }

    public FilterClass PublisherLineage(string value)
    {
        return FilterBy("locations.source.publisher_lineage", value);
    }

    public FilterClass HasIssn(bool value)
    {
        return FilterBy("primary_location.source.has_issn", value);
    }

    public FilterClass SearchRawAffiliationString(string value)
    {
        return FilterBy("raw_affiliation_string.search", value);
    }

    public FilterClass RelatedTo(string value)
    {
        return FilterBy("related_to", value);
    }

    public FilterClass Repository(string value)
    {
        return FilterBy("repository", value);
    }

    public FilterClass ToPublicationDate(string value)
    {
        return FilterBy("to_publication_date", value);
    }

#if NET6_0_OR_GREATER
    public FilterClass ToPublicationDate(DateOnly value)
    {
        return FilterBy("to_publication_date", value);
    }
#endif

    public FilterClass Version(string value)
    {
        return FilterBy("version", value);
    }

    public FilterClass FilterBy(string key, string value)
    {
        filterValues.Add((key, value));
        return this;
    }

    public FilterClass FilterBy(string key, IEnumerable<string> value)
    {
        filterValues.Add((key, string.Join("|", value)));
        return this;
    }

    public FilterClass FilterBy(string key, bool value)
    {
        FilterBy(key, value ? "true" : "false");
        return this;
    }

    public FilterClass FilterBy(string key, int value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public FilterClass FilterBy(string key, IEnumerable<int> value)
    {
        return FilterBy(key, string.Join("|", value));
    }

    public FilterClass FilterBy(string key, FilterOperator filterOperator, int value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public FilterClass FilterBy(string key, DateTime value)
    {
        FilterBy(key, value.ToString("yyyy-MM-dd"));
        return this;
    }

#if NET6_0_OR_GREATER

    public FilterClass FilterBy(string key, DateOnly value)
    {
        FilterBy(key, value.ToString("yyyy-MM-dd"));
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
        return string.Join(",", filterValues.Select(_ => $"{_.Item1}:{HttpUtility.UrlPathEncode(_.Item2)}"));
    }
}
