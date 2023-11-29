using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "hc about actresult";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "hc contact actresult";

            return View();
        }
    }
}