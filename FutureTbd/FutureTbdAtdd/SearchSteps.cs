using System.Web.Mvc;
using FutureTbd.Controllers;
using FutureTbd.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace FutureTbdAtdd
{
    [Binding]
    public class SearchSteps
    {
        private IDataEndpoint _endpoint;
        private SearchController _controller;
        private JsonResult _result;

        [Given(@"Search For ""(.*)""")]
        public void GivenSearchFor(string searchText)
        {
            _endpoint = Mock.Of<IDataEndpoint>();
            Mock.Get(_endpoint).Setup(m => m.Search(It.IsAny<string>())).Returns(new SearchResult());
            _controller = new SearchController(_endpoint);
            _result = _controller.ExecuteSearch(searchText);
        }


        [Then(@"Result is not ""(.*)""")]
        public void ThenResultIsNot(string p0)
        {
            Assert.IsNotNull(_result);
        }

        [Then(@"Result contains error ""(.*)""")]
        public void ThenResultContainsError(string errorMessage)
        {
            var searchResult = _result.Data as SearchResult;
            Assert.AreEqual(errorMessage, searchResult?.Error);
        }

        [When(@"Searching")]
        public void WhenSearching()
        {

        }
        [Given(@"Search For null")]
        public void GivenSearchForNull()
        {
            _endpoint = Mock.Of<IDataEndpoint>();
            Mock.Get(_endpoint).Setup(m => m.Search(It.IsAny<string>())).Returns(new SearchResult());
            _controller = new SearchController(_endpoint);
            _result = _controller.ExecuteSearch(null);
        }




    }
}