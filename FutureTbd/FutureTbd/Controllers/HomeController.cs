using System.Web.Mvc;

namespace FutureTbd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View("Index");
        }
    }
}