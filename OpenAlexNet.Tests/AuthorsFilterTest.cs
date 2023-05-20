namespace OpenAlexNet.Tests;

[TestClass]
public class AuthorsFilterTest
{
    [TestMethod]
    public void ByCitedByCount()
    {
        var sut = new AuthorsFilter();

        sut.ByCitedByCount(10);

        Assert.AreEqual("cited_by_count:10", sut.ToString());
    }
    [TestMethod]
    public void ByCitedByCountGreater()
    {
        var sut = new AuthorsFilter();

        sut.ByCitedByCount(FilterOperator.Greater, 11);

        Assert.AreEqual("cited_by_count:>11", sut.ToString());
    }

    [TestMethod]
    public void DefaultSearch()
    {
        var sut = new AuthorsFilter();

        sut.DefaultSearch("super secret org");

        Assert.AreEqual("default.search:super%20secret%20org", sut.ToString());
    }
}
