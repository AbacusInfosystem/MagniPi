using MagniPi.Common;
using MagniPi.Models.PreLogin;
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
            HomeViewModel homeViewModel = new HomeViewModel();

            try
            {
                if (TempData["FriendlyMessage"] != null)
                {
                    homeViewModel.FriendlyMessage.Add((FriendlyMessage)TempData["FriendlyMessage"]);
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Error : "+ex.ToString());
            }

            return View("Index", homeViewModel);
        }

        //public ActionResult Login()
        //{
        //    HomeViewModel homeViewModel = new HomeViewModel();

        //    try
        //    {
        //        if (TempData["FriendlyMessage"] != null)
        //        {
        //            homeViewModel.FriendlyMessage.Add((FriendlyMessage)TempData["FriendlyMessage"]);
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.Error("Error : " + ex.ToString());

        //        homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
        //    }

        //    return View("Login", homeViewModel);
        //}


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

        
        
    }
}
