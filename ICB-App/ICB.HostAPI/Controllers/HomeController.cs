using ICB.EntityFrameworkCore.Services;
using ICB.EntityFrameworkCore.Services.KhachHangObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ICB.HostAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task< ActionResult> Index()
        {
            KhachHangProvider serivce = new KhachHangProvider();
            var a = await serivce.GetByIDAsync("151606");
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}