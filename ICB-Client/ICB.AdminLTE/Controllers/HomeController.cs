using System.Web.Mvc;

namespace ICB.AdminLTE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        public ActionResult Detail()
        {
            
            return View();
        }
    }
}
