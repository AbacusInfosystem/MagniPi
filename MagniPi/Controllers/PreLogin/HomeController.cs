using MagniPi.Common;
using MagniPi.Models.PreLogin;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.AboutUs;
using MagniPiManager.Blog;
using MagniPiManager.Event;
using MagniPiManager.Service;
using MagniPiManager.Testimonial;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ActionResult Blog_Listing(HomeViewModel homeViewModel)
        {
            //PaginationInfo pager = new PaginationInfo();

            try
            {
                //BlogManager _blogMan = new BlogManager();
                //pager = homeViewModel.Pager;

                //homeViewModel.blogs = _blogMan.Get_Blogs(ref pager);

                //foreach (var item in homeViewModel.blogs)
                //{
                //    item.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + item.File_Type_Str + @"\" + item.Header_Image_Url;
                //}

                //homeViewModel.Pager = pager;

                //homeViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", homeViewModel.Pager.TotalRecords, homeViewModel.Pager.CurrentPage + 1, homeViewModel.Pager.PageSize, 10, true);
            
            }
            catch(Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Blog_Listing: " + ex.ToString());
            }
            //finally
            //{
            //    pager = null;
            //}

            return View("BlogListing", homeViewModel);
        }

        public JsonResult Get_Blogs(HomeViewModel homeViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                BlogManager _blogMan = new BlogManager();

                pager = homeViewModel.Pager;

                pager.PageSize = 9;

                if (!string.IsNullOrEmpty(homeViewModel.Filter.Blog_Month))
                {
                    homeViewModel.blogs = _blogMan.Get_Blogs_By_Month(ref pager, homeViewModel.Filter.Blog_Month);
                }
                else
                {
                    homeViewModel.blogs = _blogMan.Get_Blogs(ref pager);
                }

                foreach (var item in homeViewModel.blogs)
                {
                    item.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + item.File_Type_Str + @"\" + item.Header_Image_Url;

                    string removePattern = @"</?(?(?="")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:(["",']?).*?\1?)?)*\s*/?>";
                    item.Blog_Template = Regex.Replace(item.Blog_Template, @"(<img\/?[^>]+>)", @"", RegexOptions.IgnoreCase);
                    item.Blog_Template = Regex.Replace(item.Blog_Template, removePattern, "");

                    if (item.Blog_Template.Length > 275)
                    {
                        item.Blog_Template = item.Blog_Template.Substring(0, 270);
                        item.Blog_Template = item.Blog_Template + " [...]";
                    }
                    
                }

                homeViewModel.Pager = pager;

            }
            catch (Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Get_Blogs: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(homeViewModel);
        }

        public ActionResult Blog_Details(int Blog_Id)
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            try
            {
                if (Blog_Id != 0)
                {
                    BlogManager _blogMan = new BlogManager();

                    homeViewModel.blog = _blogMan.Get_Blog_By_Id(Blog_Id);

                    homeViewModel.blog.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.blog.File_Type_Str + @"\" + homeViewModel.blog.Header_Image_Url;
                }

            }
            catch(Exception ex)
            {
                Logger.Error("Home Controller - Blog_Details: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("BlogDetails", homeViewModel);
        }

        public ActionResult Testimonial_Listing(HomeViewModel homeViewModel)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Logger.Error("Home Controller - Testimonial_Listing: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("TestimonialListing", homeViewModel);
        }

        public JsonResult Get_Testimonials(HomeViewModel homeViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                TestimonialManager _testimonialMan = new TestimonialManager();

                pager = homeViewModel.Pager;
               
                homeViewModel.testimonials = _testimonialMan.Get_Testimonials(ref pager);

                foreach (var item in homeViewModel.testimonials)
                {
                    item.Author_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + item.File_Type_Str + @"\" + item.Author_Image_Url;
                }

                homeViewModel.Pager = pager;

            }
            catch (Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Get_Testimonials: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(homeViewModel);
        }

        public ActionResult AboutUs(HomeViewModel homeViewModel)
        {
            AboutUsManager _aboutusMan = new AboutUsManager();

            try
            {
                homeViewModel.aboutus = _aboutusMan.Get_About_Us_By_Id(1);

                homeViewModel.aboutus.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.aboutus.File_Type_Str + @"\" + homeViewModel.aboutus.Header_Image_Url;
            }
            catch(Exception ex)
            {
                Logger.Error("Home Controller - AboutUs: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("AboutUs", homeViewModel);
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Service_Listing(HomeViewModel homeViewModel)
        {
            try
            {

            }
            catch(Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Service_Listing: " + ex.ToString());
            }
            return View("ServiceListing", homeViewModel);
        }

        public JsonResult Get_Services(HomeViewModel homeViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                ServiceManager _serviceMan = new ServiceManager();

                pager = homeViewModel.Pager;

                pager.PageSize = 9;

                if (!string.IsNullOrEmpty(homeViewModel.Filter.Service_Title))
                {
                    homeViewModel.services = _serviceMan.Get_Services_By_Service_Title(ref pager, homeViewModel.Filter.Service_Title);
                }
                else
                {
                    homeViewModel.services = _serviceMan.Get_Services(ref pager);
                }

                foreach (var item in homeViewModel.services)
                {
                    item.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + item.File_Type_Str + @"\" + item.Header_Image_Url;

                    string removePattern = @"</?(?(?="")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:(["",']?).*?\1?)?)*\s*/?>";
                    item.Service_Template = Regex.Replace(item.Service_Template, @"(<img\/?[^>]+>)", @"", RegexOptions.IgnoreCase);                    
                    item.Service_Template = Regex.Replace(item.Service_Template, removePattern, "");

                    if (item.Service_Template.Length > 275)
                    {
                        item.Service_Template = item.Service_Template.Substring(0, 270);
                        item.Service_Template = item.Service_Template + " [...]";
                    }

                }

                homeViewModel.Pager = pager;

            }
            catch (Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Get_Services: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(homeViewModel);
        }

        public ActionResult Service_Details(int Service_Id)
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            try
            {
                if (Service_Id != 0)
                {
                    ServiceManager _serviceMan = new ServiceManager();

                    homeViewModel.service = _serviceMan.Get_Service_By_Id(Service_Id);

                    homeViewModel.service.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.service.File_Type_Str + @"\" + homeViewModel.service.Header_Image_Url;
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Home Controller - Service_Details: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("ServiceDetails", homeViewModel);
        }

        public ActionResult Event_Listing(HomeViewModel homeViewModel)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Logger.Error("Home Controller - Event_Listing: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("EventListing", homeViewModel);
        }

        public JsonResult Get_Events(HomeViewModel homeViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                EventManager _eventMan = new EventManager();

                pager = homeViewModel.Pager;

                pager.PageSize = 9;

                homeViewModel.events = _eventMan.Get_Up_Comming_Events(ref pager);

                foreach (var item in homeViewModel.events)
                {
                    item.Attachment_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + item.Attachment_Type_Str + @"\" + item.Attachment_Url;
                }

                homeViewModel.Pager = pager;

            }
            catch (Exception ex)
            {
                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Home Controller - Get_Events: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(homeViewModel);
        }

        public ActionResult Event_Details(int Event_Id)
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            try
            {
                if (Event_Id != 0)
                {
                    EventManager _eventMan = new EventManager();

                    homeViewModel.Event = _eventMan.Get_Event_By_Id(Event_Id);

                    homeViewModel.Event.Attachment_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + homeViewModel.Event.Attachment_Type_Str + @"\" + homeViewModel.Event.Attachment_Url;

                    homeViewModel.Event.eventdates = _eventMan.Get_Event_Dates(Event_Id);

                }

            }
            catch (Exception ex)
            {
                Logger.Error("Home Controller - Event_Details: " + ex.ToString());

                homeViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("EventDetails", homeViewModel);
        }

		public ActionResult Home()
		{
			return View();
		}

        
        
    }

}
