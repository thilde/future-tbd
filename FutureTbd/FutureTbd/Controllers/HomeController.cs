using System.Web.Mvc;

namespace FutureTbd.Controllers
{
    public class HomeController : Controller
    {
        public const string HOME_PAGE_TITLE = "Home Page";

        public ActionResult Index()
        {
            ViewBag.Title = HOME_PAGE_TITLE;

            return View("Index");
        }
    }
}