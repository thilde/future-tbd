using System.Web.Mvc;

namespace FutureTbd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          

            return View("Index");
        }
    }
}