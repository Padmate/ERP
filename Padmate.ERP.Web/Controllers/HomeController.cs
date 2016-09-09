using Padmate.ERP.Models;
using Padmate.ERP.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padmate.ERP.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Default()
        {
            return View();
        }

        [Authorization]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}