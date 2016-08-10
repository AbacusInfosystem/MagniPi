using MagniPi.Common;
using MagniPi.Models.PostLogin.Service;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Service
{
    public class ServiceController : Controller
    {

        ServiceManager _serviceMan;

        public ServiceController()
        {
            _serviceMan = new ServiceManager();
        }

        public ActionResult Index(ServiceViewModel sViewModel)
        {
            try
            {
                if (sViewModel.service.Service_Id != 0)
                {
                    sViewModel.service = _serviceMan.Get_Service_By_Id(sViewModel.service.Service_Id);

                    sViewModel.service.Header_Image_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + sViewModel.service.File_Type_Str + @"\" + sViewModel.service.Header_Image_Url;
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Service Controller - Index: " + ex.ToString());

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", sViewModel);
        }

        public ActionResult Search(ServiceViewModel sViewModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.Error("Service Controller - Search: " + ex.ToString());

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("Search", sViewModel);
        }

        public JsonResult Get_Services(ServiceViewModel sViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = sViewModel.Pager;

                if (!string.IsNullOrEmpty(sViewModel.Filter.Service_Title))
                {
                    sViewModel.services = _serviceMan.Get_Services_By_Service_Title(ref pager, sViewModel.Filter.Service_Title);
                }
                else
                {
                    sViewModel.services = _serviceMan.Get_Services(ref pager);
                }

                sViewModel.Pager = pager;

                sViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", sViewModel.Pager.TotalRecords, sViewModel.Pager.CurrentPage + 1, sViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Service Controller - Get_Services: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(sViewModel);
        }

        public ActionResult Save_Service(ServiceViewModel sViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                sViewModel.service.Updated_By = session.User_Id;
                sViewModel.service.Updated_On = DateTime.Now;
                sViewModel.service.Created_By = session.User_Id;
                sViewModel.service.Created_On = DateTime.Now;

                if (sViewModel.service.Service_Id != 0)
                {
                    _serviceMan.Update_Service(sViewModel.service);

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("SRV02"));

                }
                else
                {

                    sViewModel.service.Service_Id = _serviceMan.Insert_Service(sViewModel.service);

                    sViewModel.FriendlyMessage.Add(MessageStore.Get("SRV01"));
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Service Controller - Save_Service: " + ex.ToString());

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", sViewModel);
        }



    }
}
