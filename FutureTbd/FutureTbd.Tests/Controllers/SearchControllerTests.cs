using System.Web.Helpers;
using System.Web.Mvc;
using FutureTbd.Controllers;
using FutureTbd.Models;
using Moq;
using NUnit.Framework;

namespace FutureTbd.Tests.Controllers
{
    [TestFixture]
    public class SearchControllerTests
    {
        #region Constructor Test

        [Test]
        public void GivenNullEndpoint_WhenCreatingController_ThenErrorOccurs()
        {
            Assert.That(() => new SearchController(null), Throws.Exception);
        }

        #endregion

        #region Index Tests

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenResultIsNotNull()
        {
            var controller = new SearchController(Mock.Of<IDataEndpoint>());
            var result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexPageTitleIsSetCorrectly()
        {
            var controller = new SearchController(Mock.Of<IDataEndpoint>());
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewBag.Title, Is.EqualTo(SearchController.SEARCH_PAGE_TITLE));
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexViewIsReturned()
        {
            var controller = new SearchController(Mock.Of<IDataEndpoint>());
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        #endregion

        #region Search Tests

        [Test]
        public void GivenRequestToSearch_WhenCallingIndex_ThenResultIsNotNull()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("search term");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GivenRequestToSearch_WhenCallingSearch_ThenResultIsJsonResult()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("search term");

            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void GivenCallToSearch_WhenSearchingText_ThenSearchEndpointIsCalled()
        {
            var mockEndpoint = Mock.Of<IDataEndpoint>();
            var controller = new SearchController(mockEndpoint);
            controller.ExecuteSearch("search term");

            Mock.Get(mockEndpoint).Verify(m => m.Search(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void GivenCallToSearch_WhenSearchingText_ThenResultIsJsonResultOfSerachResultObject()
        {
            var mockEndpoint = Mock.Of<IDataEndpoint>();
            var searchResult=new SearchResult {ResultString = "test"};
            Mock.Get(mockEndpoint).Setup(m => m.Search(It.IsAny<string>())).Returns(searchResult);
            var controller = new SearchController(mockEndpoint);
           JsonResult result= controller.ExecuteSearch("search term");

           Assert.That(result.Data as SearchResult, Is.EqualTo(searchResult));
        }

        [Test]
        public void GivenCallToSearch_WhenSearchingText_ThenSearchEndpointIsCalledWithCorrectParameter()
        {
            const string searchText = "search Text";
            var mockEndpoint = Mock.Of<IDataEndpoint>();
            var controller = new SearchController(mockEndpoint);
            controller.ExecuteSearch(searchText);

            Mock.Get(mockEndpoint).Verify(m => m.Search(searchText), Times.Once());
        }

        [Test]
        public void GivenNullSearchText_WhenSearching_ThenJsonIsReturned()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch(null);

            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void GivenNullSearchText_WhenSearching_ThenSearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch(null);
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult.Error, Is.EqualTo(SearchController.NULL_SEARCH_RESULT_ERROR_MESSAGE));
        }

        [Test]
        public void GivenEmptyStringSearchText_WhenSearching_ThenSearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("");
            var searchresult = result.Data as SearchResult;
            Assert.That(searchresult?.Error, Is.EqualTo(SearchController.EMPTY_SEARCH_RESULT_ERROR_MESSAGE));
        }

        [Test]
        public void GivenWhiteSpaceStringSearchText_WhenSearching_ThenSearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("      ");
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error, Is.EqualTo(SearchController.EMPTY_SEARCH_RESULT_ERROR_MESSAGE));
        }

        [Test]
        public void GivenLessThanMininumSearchCharacters_WhenSearching_ThenSearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("HA");
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error, Is.EqualTo(SearchController.ShortSearchTermErrorMessage()));
        }

        [Test]
        public void GivenLessThanMininumSearchCharacters_WhenSearching_ThenSearchResultMinimumCharMessageIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch("HA");
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error,
                Is.EqualTo(
                    $"The search term should be longer than {SearchController.MINIMUM_SEARCH_TERM_LENGTH} characters."));
        }

        [Test]
        public void GivenGreaterThanAllowedMaximumSearchCharacters_WhenSearching_ThensearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result =
                controller.ExecuteSearch(LongSearchTerm);
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error, Is.EqualTo(SearchController.LongSearchTermErrorMessage()));
        }

        [Test]
        public void GivenGreaterMaximumSearchCharacters_WhenSearching_ThensearchResultErrorIsSetCorrectly()
        {
            SearchController controller = NewSearchController();

            var result =
                controller.ExecuteSearch(SearchTermWithMaximumLength);
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error, Is.EqualTo(SearchController.LongSearchTermErrorMessage()));
        }

        [Test]
        public void
            GivenGreaterThanAllowedMaximumSearchCharacters_WhenSearching_ThensearchResultMaximumCharMessageIsSetCorrectly
            ()
        {
            SearchController controller = NewSearchController();

            var result = controller.ExecuteSearch(LongSearchTerm);
            var searchResult = result.Data as SearchResult;
            Assert.That(searchResult?.Error,
                Is.EqualTo(
                    $"The search term cannot be longer than {SearchController.MAXIMUM_SEARCH_TERM_LENGTH} characters."));
        }

        #endregion

        #region Testing Helpers

        private const string SearchTermWithMaximumLength =
            "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        private const string LongSearchTerm =
            "HA111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        private SearchController NewSearchController(IDataEndpoint dataEndpoint = null)
        {
            return new SearchController(dataEndpoint ?? MockDataEndpoint());
        }

        private IDataEndpoint MockDataEndpoint()
        {
            var mockEnpoint = Mock.Of<IDataEndpoint>();
            Mock.Get(mockEnpoint).Setup(m => m.Search(It.IsAny<string>())).Returns(new SearchResult());
            return mockEnpoint;
        }

        #endregion
    }
}