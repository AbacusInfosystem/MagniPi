using MagniPi.Common;
using MagniPi.Models.PostLogin.AboutUs;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiManager.AboutUs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.AboutUs
{
    public class AboutUsController : Controller
    {

        AboutUsManager _aboutusMan;

        public AboutUsController()
        {
            _aboutusMan = new AboutUsManager();
        }

        public ActionResult Index(AboutUsViewModel auViewModel)
        {
            try
            {
                auViewModel.aboutus.About_Us_Id = 1;

                if (auViewModel.aboutus.About_Us_Id != 0)
                {
                    auViewModel.aboutus = _aboutusMan.Get_About_Us_By_Id(auViewModel.aboutus.About_Us_Id);

                    auViewModel.aboutus.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + auViewModel.aboutus.File_Type_Str + @"\" + auViewModel.aboutus.Header_Image_Url;
                }

            }
            catch(Exception ex)
            {
                auViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("AboutUs Controller - Index: " + ex.ToString());
            }

            return View("Index", auViewModel);
        }

        public ActionResult Save_About_Us(AboutUsViewModel auViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                auViewModel.aboutus.Updated_By = session.User_Id;
                auViewModel.aboutus.Updated_On = DateTime.Now;

                if (auViewModel.aboutus.About_Us_Id != 0)
                {
                    _aboutusMan.Update_About_Us(auViewModel.aboutus);

                    auViewModel.FriendlyMessage.Add(MessageStore.Get("ABT01"));

                }
                
            }
            catch (Exception ex)
            {
                Logger.Error("AboutUs Controller - Save_About_Us: " + ex.ToString());

                auViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", auViewModel);
        }

    }
}
