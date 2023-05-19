namespace OpenAlexNet;
using FilterClass = InstitutionsFilter;

public class InstitutionsFilter
{
    private readonly List<(string, string)> filterValues = new();

    public FilterClass ByCitedByCount(int value)
    {
        return FilterBy("cited_by_count", value);
    }

    public FilterClass ByCitedByCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("cited_by_count", filterOperator, value);
    }

    public FilterClass ByCountryCode(string value)
    {
        return FilterBy("country_code", value);
    }

    public FilterClass ByOpenAlex(string value)
    {
        return FilterBy("openalex", value);
    }

    public FilterClass ByRepositoriesHostOrganization(string value)
    {
        return FilterBy("repositories.host_organization", value);
    }

    public FilterClass ByRepositoriesHostOrganizationLineage(string value)
    {
        return FilterBy("repositories.host_organization_lineage", value);
    }

    public FilterClass ByRepositoriesId(string value)
    {
        return FilterBy("repositories.id", value);
    }

    public FilterClass BySummaryStats2YearMeanCitedness(double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", value);
    }

    public FilterClass BySummaryStats2YearMeanCitedness(FilterOperator filterOperator, double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", filterOperator, value);
    }

    public FilterClass BySummaryStatsHIndex(int value)
    {
        return FilterBy("summary_stats.h_index", value);
    }

    public FilterClass BySummaryStatsHIndex(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.h_index", filterOperator, value);
    }

    public FilterClass BySummaryStatsI10Index(int value)
    {
        return FilterBy("summary_stats.i10_index", value);
    }

    public FilterClass BySummaryStatsI10Index(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.i10_index", filterOperator, value);
    }

    public FilterClass ByRor(string value)
    {
        return FilterBy("ror", value);
    }

    public FilterClass ByType(string value)
    {
        return FilterBy("type", value);
    }

    public FilterClass ByWorksCount(int value)
    {
        return FilterBy("works_count", value);
    }

    public FilterClass ByWorksCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("works_count", filterOperator, value);
    }

    public FilterClass ByXConceptsId(string value)
    {
        return FilterBy("x_concepts.id", value);
    }

    public FilterClass Continent(string value)
    {
        return FilterBy("continent", value);
    }

    public FilterClass DefaultSearch(string value)
    {
        return FilterBy("default.search", value);
    }

    public FilterClass DisplayNameSearch(string value)
    {
        return FilterBy("display_name.search", value);
    }

    public FilterClass HasRorId(bool value)
    {
        return FilterBy("has_ror", value);
    }

    public FilterClass IsGlobalSouth(string value)
    {
        return FilterBy("InstitutionsFilter", value);
    }

    public FilterClass FilterBy(string key, string value)
    {
        filterValues.Add((key, value));
        return this;
    }

    public FilterClass FilterBy(string key, bool value)
    {
        filterValues.Add((key, value ? "true" : "false"));
        return this;
    }

    public FilterClass FilterBy(string key, int value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public FilterClass FilterBy(string key, FilterOperator filterOperator, int value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public FilterClass FilterBy(string key, double value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public FilterClass FilterBy(string key, FilterOperator filterOperator, double value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public FilterClass FilterBy(string key, DateTime value)
    {
        filterValues.Add((key, value.ToString("yyyy-MM-dd")));
        return this;
    }

#if NET6_0_OR_GREATER

    public FilterClass FilterBy(string key, DateOnly value)
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
