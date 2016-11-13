using System;
using System.Web.Mvc;

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
        public JsonResult ExecuteSearch(string searchText)
        {
            ViewBag.Title = SEARCH_PAGE_TITLE;
            _dataEndpoint.Search(searchText);
            return Json("");
        }
    }
}