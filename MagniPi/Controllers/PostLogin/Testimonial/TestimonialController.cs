using MagniPi.Common;
using MagniPi.Filters;
using MagniPi.Models.PostLogin.Testimonial;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Testimonial;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Testimonial
{
	[SessionExpireAttribute]
    public class TestimonialController : Controller
    {

        TestimonialManager _testimonialMan;

        public TestimonialController()
        {
            _testimonialMan = new TestimonialManager();
        }

        public ActionResult Search(TestimonialViewModel tViewModel)
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Testimonial Controller - Search: " + ex.ToString());
            }
            return View("Search", tViewModel);
        }

        public ActionResult Index(TestimonialViewModel tViewModel)
        {
            try
            {
                if (tViewModel.testimonial.Testimonial_Id != 0)
                {
                    tViewModel.testimonial = _testimonialMan.Get_Testimonial_By_Id(tViewModel.testimonial.Testimonial_Id);

                    tViewModel.testimonial.Author_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + tViewModel.testimonial.File_Type_Str + @"\" + tViewModel.testimonial.Author_Image_Url;
                }

            }
            catch(Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Testimonial Controller - Index: " + ex.ToString());
            }
            return View("Index", tViewModel);
        }

        public JsonResult Get_Testimonials(TestimonialViewModel tViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = tViewModel.Pager;

                tViewModel.testimonials = _testimonialMan.Get_Testimonials(ref pager);

                tViewModel.Pager = pager;

                tViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", tViewModel.Pager.TotalRecords, tViewModel.Pager.CurrentPage + 1, tViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Testimonial Controller - Get_Testimonials: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(tViewModel);
        }

        public ActionResult Save_Testimonial(TestimonialViewModel tViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                tViewModel.testimonial.Updated_By = session.User_Id;
                tViewModel.testimonial.Updated_On = DateTime.Now;
                tViewModel.testimonial.Created_By = session.User_Id;
                tViewModel.testimonial.Created_On = DateTime.Now;

                if (tViewModel.testimonial.Testimonial_Id != 0)
                {
                    _testimonialMan.Update_Testimonial(tViewModel.testimonial);

                    tViewModel.FriendlyMessage.Add(MessageStore.Get("TST02"));

                }
                else
                {
                    tViewModel.testimonial.Testimonial_Id = _testimonialMan.Insert_Testimonial(tViewModel.testimonial);

                    tViewModel.FriendlyMessage.Add(MessageStore.Get("TST01"));
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Testimonial Controller - Save_Testimonial: " + ex.ToString());

                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", tViewModel);
        }


    }
}
