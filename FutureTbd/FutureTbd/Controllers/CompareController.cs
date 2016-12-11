using System.Web.Mvc;

namespace FutureTbd.Controllers
{
    public class CompareController : Controller
    {
        public const string COMPARE_PAGE_TITLE = "Future TBD | Compare ";
        // GET: Compare
        public ActionResult Index()
        {
            ViewBag.Title = COMPARE_PAGE_TITLE;
            return View("Compare");
          


        }
    }
}