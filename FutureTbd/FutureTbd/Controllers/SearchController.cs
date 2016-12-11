using System;
using System.Web.Mvc;
using FutureTbd.Models;

namespace FutureTbd.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDataEndpoint _dataEndpoint;
        public const int MAXIMUM_SEARCH_TERM_LENGTH = 100;

        public SearchController(IDataEndpoint dataEndpoint)
        {
            if (dataEndpoint == null)
            {
                throw new ArgumentException("dataEndpoint");
            }
            _dataEndpoint = dataEndpoint;
        }

        public const string SEARCH_PAGE_TITLE = "Search";
        public const int MINIMUM_SEARCH_TERM_LENGTH = 2;
        public const string NULL_SEARCH_RESULT_ERROR_MESSAGE = "The search term cannot be null";
        public const string EMPTY_SEARCH_RESULT_ERROR_MESSAGE = "The search term cannot be empty";

        public static string ShortSearchTermErrorMessage()
        {
            return $"The search term should be longer than {MINIMUM_SEARCH_TERM_LENGTH} characters.";
        }

        public static string LongSearchTermErrorMessage()
        {
            return $"The search term cannot be longer than {MAXIMUM_SEARCH_TERM_LENGTH} characters.";
        }

        // GET: Search
        public ActionResult Index()
        {
            ViewBag.Title = SEARCH_PAGE_TITLE;

            return View("Index");
        }

        [HttpPost]
        public JsonResult ExecuteSearch(string searchText)
        {
            if (searchText == null)
            {
                return Json(new SearchResult {Error = NULL_SEARCH_RESULT_ERROR_MESSAGE});
            }
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return Json(new SearchResult {Error = EMPTY_SEARCH_RESULT_ERROR_MESSAGE});
            }
            if (searchText.Length <= MINIMUM_SEARCH_TERM_LENGTH)
            {
                return Json(new SearchResult {Error = ShortSearchTermErrorMessage()});
            }
            if (searchText.Length >= MAXIMUM_SEARCH_TERM_LENGTH)
            {
                return Json(new SearchResult {Error = LongSearchTermErrorMessage()});
            }

            ViewBag.Title = SEARCH_PAGE_TITLE;

            return Json(_dataEndpoint.Search(searchText));
        }

        public ActionResult SearchByState()
        {
            ViewBag.Title = SEARCH_PAGE_TITLE;

            return View("SearchByState");
        }

        [HttpPost]
        public JsonResult ExecuteSearchByState(string state)
        {
            if (state == null)
            {
                return Json(new SearchResult {Error = NULL_SEARCH_RESULT_ERROR_MESSAGE});
            }
            if (string.IsNullOrWhiteSpace(state))
            {
                return Json(new SearchResult {Error = EMPTY_SEARCH_RESULT_ERROR_MESSAGE});
            }

            ViewBag.Title = SEARCH_PAGE_TITLE;

            return Json(_dataEndpoint.SearchByState(state));
        }
    }
}