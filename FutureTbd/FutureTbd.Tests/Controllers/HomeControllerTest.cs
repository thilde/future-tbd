using System.Web.Mvc;
using FutureTbd.Controllers;
using NUnit.Framework;

namespace FutureTbd.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        #region Index

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenResultIsNotNull()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexPageTitleIsSetCorrectly()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewBag.Title, Is.EqualTo(HomeController.HOME_PAGE_TITLE));
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexViewIsReturned()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

        #endregion
    }
}