namespace OpenAlexNet.Tests
{
    [TestClass]
    public class WorksFilterTest
    {
        [TestMethod]
        public void ByAuthorId()
        {
            var sut = new WorksFilter();

            sut.ByAuthorId("my author");

            Assert.AreEqual("author.id:my author", sut.ToString());
        }

        [TestMethod]
        public void ByRawAffiliationString()
        {
            var sut = new WorksFilter();

            sut.SearchRawAffiliationString("super secret org");

            Assert.AreEqual("raw_affiliation_string.search:super secret org", sut.ToString());
        }
    }
}