using System;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace FutureTbd.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDataEndpoint _dataEndpoint;

        public SearchController(IDataEndpoint dataEndpoint)
        {
            if (dataEndpoint == null)
            {
                throw new ArgumentException("dataEndpoint");
            }
            _dataEndpoint = dataEndpoint;
        }

        public const string SEARCH_PAGE_TITLE = "Search";
        // GET: Search
        public ActionResult Index()
        {
            ViewBag.Title = SEARCH_PAGE_TITLE;

            return View("Index");
        }

        [HttpPost]
        public string  ExecuteSearch(string searchText)
        {
            ViewBag.Title = SEARCH_PAGE_TITLE;
            
            return _dataEndpoint.Search(searchText);
        }
    }
}