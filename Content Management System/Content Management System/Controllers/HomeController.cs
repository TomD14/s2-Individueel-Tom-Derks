using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Content_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Beschrijving";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Gegevens";

            return View();
        }

        public ActionResult Inventaris()
        {
            return View();
        }
    }
}