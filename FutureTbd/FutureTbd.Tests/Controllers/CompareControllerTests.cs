using System.Web.Mvc;
using FutureTbd.Controllers;
using NUnit.Framework;

namespace FutureTbd.Tests.Controllers
{
    [TestFixture]
    public class CompareControllerTests
    {
        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenResultIsNotNull()
        {
            var controller = new CompareController();
            var result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexPageTitleIsSetCorrectly()
        {
            var controller = new CompareController();
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewBag.Title, Is.EqualTo(CompareController.COMPARE_PAGE_TITLE));
        }

        [Test]
        public void GivenRequestToIndex_WhenCallingIndex_ThenIndexViewIsReturned()
        {
            var controller = new CompareController();
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Compare"));
        }
    }
}