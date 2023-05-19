namespace OpenAlexNet;

public class InstitutionsFilter
{
    private readonly List<(string, string)> filterValues = new();

    public InstitutionsFilter ByCitedByCount(int value)
    {
        return FilterBy("cited_by_count", value);
    }

    public InstitutionsFilter ByCitedByCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("cited_by_count", filterOperator, value);
    }

    public InstitutionsFilter ByCountryCode(string value)
    {
        return FilterBy("country_code", value);
    }

    public InstitutionsFilter ByOpenAlex(string value)
    {
        return FilterBy("openalex", value);
    }

    public InstitutionsFilter ByRepositoriesHostOrganization(string value)
    {
        return FilterBy("repositories.host_organization", value);
    }

    public InstitutionsFilter ByRepositoriesHostOrganizationLineage(string value)
    {
        return FilterBy("repositories.host_organization_lineage", value);
    }

    public InstitutionsFilter ByRepositoriesId(string value)
    {
        return FilterBy("repositories.id", value);
    }

    public InstitutionsFilter BySummaryStats2YearMeanCitedness(double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", value);
    }

    public InstitutionsFilter BySummaryStats2YearMeanCitedness(FilterOperator filterOperator, double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", filterOperator, value);
    }

    public InstitutionsFilter BySummaryStatsHIndex(int value)
    {
        return FilterBy("summary_stats.h_index", value);
    }

    public InstitutionsFilter BySummaryStatsHIndex(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.h_index", filterOperator, value);
    }

    public InstitutionsFilter BySummaryStatsI10Index(int value)
    {
        return FilterBy("summary_stats.i10_index", value);
    }

    public InstitutionsFilter BySummaryStatsI10Index(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.i10_index", filterOperator, value);
    }

    public InstitutionsFilter ByRor(string value)
    {
        return FilterBy("ror", value);
    }

    public InstitutionsFilter ByType(string value)
    {
        return FilterBy("type", value);
    }

    public InstitutionsFilter ByWorksCount(int value)
    {
        return FilterBy("works_count", value);
    }

    public InstitutionsFilter ByWorksCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("works_count", filterOperator, value);
    }

    public InstitutionsFilter ByXConceptsId(string value)
    {
        return FilterBy("x_concepts.id", value);
    }

    public InstitutionsFilter Continent(string value)
    {
        return FilterBy("continent", value);
    }

    public InstitutionsFilter DefaultSearch(string value)
    {
        return FilterBy("default.search", value);
    }

    public InstitutionsFilter DisplayNameSearch(string value)
    {
        return FilterBy("display_name.search", value);
    }

    public InstitutionsFilter HasRorId(bool value)
    {
        return FilterBy("has_ror", value);
    }

    public InstitutionsFilter IsGlobalSouth(string value)
    {
        return FilterBy("InstitutionsFilter", value);
    }

    public InstitutionsFilter FilterBy(string key, string value)
    {
        filterValues.Add((key, value));
        return this;
    }

    public InstitutionsFilter FilterBy(string key, bool value)
    {
        filterValues.Add((key, value ? "true" : "false"));
        return this;
    }

    public InstitutionsFilter FilterBy(string key, int value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public InstitutionsFilter FilterBy(string key, FilterOperator filterOperator, int value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public InstitutionsFilter FilterBy(string key, double value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public InstitutionsFilter FilterBy(string key, FilterOperator filterOperator, double value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public InstitutionsFilter FilterBy(string key, DateTime value)
    {
        filterValues.Add((key, value.ToString("yyyy-MM-dd")));
        return this;
    }

#if NET6_0_OR_GREATER

    public InstitutionsFilter FilterBy(string key, DateOnly value)
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
