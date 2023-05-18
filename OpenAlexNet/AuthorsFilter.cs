namespace OpenAlexNet;

public class AuthorsFilter
{
    private readonly List<(string, string)> filterValues = new();

    public AuthorsFilter ByCitedByCount(int value)
    {
        return FilterBy("cited_by_count", value);
    }

    public AuthorsFilter ByCitedByCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("cited_by_count", filterOperator, value);
    }

    public AuthorsFilter ByOpenAlex(string value)
    {
        return FilterBy("ids.openalex", value);
    }

    public AuthorsFilter ByLastKnownInstitutionCountryCode(string value)
    {
        return FilterBy("last_known_institution.country_code", value);
    }

    public AuthorsFilter ByLastKnownInstitutionId(string value)
    {
        return FilterBy("last_known_institution.id", value);
    }

    public AuthorsFilter ByLastKnownInstitutionRor(string value)
    {
        return FilterBy("last_known_institution.ror", value);
    }

    public AuthorsFilter ByLastKnownInstitutionType(string value)
    {
        return FilterBy("last_known_institution.type", value);
    }

    public AuthorsFilter BySummaryStats2YearMeanCitedness(double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", value);
    }

    public AuthorsFilter BySummaryStats2YearMeanCitedness(FilterOperator filterOperator, double value)
    {
        return FilterBy("summary_stats.2yr_mean_citedness", filterOperator, value);
    }

    public AuthorsFilter BySummaryStatsHIndex(int value)
    {
        return FilterBy("summary_stats.h_index", value);
    }

    public AuthorsFilter BySummaryStatsHIndex(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.h_index", filterOperator, value);
    }

    public AuthorsFilter BySummaryStatsI10Index(int value)
    {
        return FilterBy("summary_stats.i10_index", value);
    }

    public AuthorsFilter BySummaryStatsI10Index(FilterOperator filterOperator, int value)
    {
        return FilterBy("summary_stats.i10_index", filterOperator, value);
    }

    public AuthorsFilter ByWorksCount(int value)
    {
        return FilterBy("works_count", value);
    }

    public AuthorsFilter ByWorksCount(FilterOperator filterOperator, int value)
    {
        return FilterBy("works_count", filterOperator, value);
    }

    public AuthorsFilter ByXConceptsId(string value)
    {
        return FilterBy("x_concepts.id", value);
    }

    public AuthorsFilter DefaultSearch(string value)
    {
        return FilterBy("default.search", value);
    }

    public AuthorsFilter DisplayNameSearch(string value)
    {
        return FilterBy("display_name.search", value);
    }

    public AuthorsFilter HasOrcId(bool value)
    {
        return FilterBy("has_orcid", value);
    }

    public AuthorsFilter ByLastKnownInstitutionContinent(string value)
    {
        return FilterBy("last_known_institution.continent", value);
    }

    public AuthorsFilter IsLastKnownInstitutionGlobalSouth(string value)
    {
        return FilterBy("last_known_institution.is_global_south", value);
    }

    public AuthorsFilter FilterBy(string key, string value)
    {
        filterValues.Add((key, value));
        return this;
    }

    public AuthorsFilter FilterBy(string key, bool value)
    {
        filterValues.Add((key, value ? "true" : "false"));
        return this;
    }

    public AuthorsFilter FilterBy(string key, int value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public AuthorsFilter FilterBy(string key, FilterOperator filterOperator, int value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public AuthorsFilter FilterBy(string key, double value)
    {
        return FilterBy(key, FilterOperator.Equals, value);
    }

    public AuthorsFilter FilterBy(string key, FilterOperator filterOperator, double value)
    {
        return FilterBy(key, GetFilterOperatorPrefix(filterOperator) + value.ToString());
    }

    public AuthorsFilter FilterBy(string key, DateTime value)
    {
        filterValues.Add((key, value.ToString("yyyy-MM-dd")));
        return this;
    }

#if NET6_0_OR_GREATER

    public AuthorsFilter FilterBy(string key, DateOnly value)
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
