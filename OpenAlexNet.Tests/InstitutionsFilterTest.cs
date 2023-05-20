namespace OpenAlexNet.Tests;

[TestClass]
public class InstitutionsFilterTest
{
    [TestMethod]
    public void ByCitedByCount()
    {
        var sut = new InstitutionsFilter();

        sut.ByCitedByCount(10);

        Assert.AreEqual("cited_by_count:10", sut.ToString());
    }
    [TestMethod]
    public void ByCitedByCountGreater()
    {
        var sut = new InstitutionsFilter();

        sut.ByCitedByCount(FilterOperator.Greater, 11);

        Assert.AreEqual("cited_by_count:>11", sut.ToString());
    }

    [TestMethod]
    public void DefaultSearch()
    {
        var sut = new InstitutionsFilter();

        sut.DefaultSearch("super secret org");

        Assert.AreEqual("default.search:super%20secret%20org", sut.ToString());
    }

    [TestMethod]
    public void ByCountryCode()
    {
        var sut = new InstitutionsFilter();

        sut.ByCountryCode(new string[] { "fr", "gb" });

        Assert.AreEqual("country_code:fr|gb", sut.ToString());
    }
}
