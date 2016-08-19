﻿using MagniPi.Common;
using MagniPi.Models.PreLogin;
using MagniPiHelper.Logging;
using MagniPiManager.Blog;
using MagniPiManager.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
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

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", homeViewModel);
        }

        public ActionResult System_Error()
        {
            return View("Error");
        }


        public ActionResult BlogListing()
        {
            return View();
        }

        public ActionResult BlogDetails(HomeViewModel homeViewModel)
        {
            try
            {
                if (homeViewModel.blog.Blog_Id != 0)
                {
                    BlogManager _blogMan = new BlogManager();

                    homeViewModel.blog = _blogMan.Get_Blog_By_Id(homeViewModel.blog.Blog_Id);

                    homeViewModel.blog.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.blog.File_Type_Str + @"\" + homeViewModel.blog.Header_Image_Url;
                }

            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("BlogDetails", homeViewModel);
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

        public ActionResult ServiceDetails(HomeViewModel homeViewModel)
        {
            try
            {
                if (homeViewModel.service.Service_Id != 0)
                {
                    ServiceManager _serviceMan = new ServiceManager();

                    homeViewModel.service = _serviceMan.Get_Service_By_Id(homeViewModel.service.Service_Id);

                    homeViewModel.service.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.service.File_Type_Str + @"\" + homeViewModel.service.Header_Image_Url;
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("ServiceDetails", homeViewModel);
        }

		public ActionResult Home()
		{
			return View();
		}

        
        
    }
}
