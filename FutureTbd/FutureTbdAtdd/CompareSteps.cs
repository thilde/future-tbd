using System.Web.Mvc;
using FutureTbd.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FutureTbdAtdd
{
    [Binding]
    class CompareSteps
    {
        private CompareController _compareController;
        private ActionResult _result;


        [Given(@"Request To Compare")]
        public void GivenRequestToCompare()
        {
            _compareController = new CompareController();
        }

        [When(@"Comparing Results")]
        public void WhenComparingResults()
        {
            _result = _compareController.Index();
        }

        [Then(@"Compare Result Is Not Null")]
        public void ThenCompareResultIsNotNull()
        {
            Assert.IsNotNull(_result);
        }
    }
}