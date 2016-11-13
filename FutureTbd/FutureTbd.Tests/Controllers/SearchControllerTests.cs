using System.Web.Mvc;
using FutureTbd.Controllers;
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
            var controller = new SearchController(Mock.Of<IDataEndpoint>());
            JsonResult result = controller.ExecuteSearch("");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GivenRequestToSearch_WhenCallingSearch_ThenResultIsJsonResult()
        {
            var controller = new SearchController(Mock.Of<IDataEndpoint>());
            JsonResult result = controller.ExecuteSearch("");

            Assert.That(result, Is.TypeOf<JsonResult>());
        }

        [Test]
        public void GivenCallToSearch_WhenSearchingText_ThenSearchEndpointIsCalled()
        {
            var mockEndpoint = Mock.Of<IDataEndpoint>();
            var controller = new SearchController(mockEndpoint);
            controller.ExecuteSearch("");

            Mock.Get(mockEndpoint).Verify(m => m.Search(It.IsAny<string>()), Times.Once());
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

        #endregion
    }
}