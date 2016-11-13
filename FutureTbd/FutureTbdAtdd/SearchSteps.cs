using System;
using FutureTbd.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace FutureTbdAtdd
{
    [Binding]
    public class SearchSteps
    {
        private IDataEndpoint _endpoint;
        private SearchController _controller;
        private string _result;

        [Given(@"Search For ""(.*)""")]
        public void GivenSearchFor(string searchText)
        {
            _endpoint = Mock.Of<IDataEndpoint>();
            Mock.Get(_endpoint).Setup(m => m.Search(It.IsAny<string>())).Returns("demo result ");
            _controller = new SearchController(_endpoint);
            _result= _endpoint.Search(searchText);
         }
        
        [When(@"Searching")]
        public void WhenSearching()
        {
        }
        
        [Then(@"Result is not ""(.*)""")]
        public void ThenResultIsNot(string p0)
        {
            Assert.IsNotNull(_result);
        }
    }
}
