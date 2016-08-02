using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Logger.Debug("");
            return View();
        }

        public ActionResult BlogListing()
        {
            return View();
        }

        public ActionResult BlogDetails()
        {
            return View();
        }

        public ActionResult TestimonialListing()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult ServiceListing()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
    }
}
