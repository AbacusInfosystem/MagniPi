using MagniPi.Common;
using MagniPi.Models.PostLogin.Event;
using MagniPiBusinessEntities.Common;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Event;
using MagniPi.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Event
{
    [SessionExpireAttribute]
    public class EventController : Controller
    {
        EventManager _eventMan;

        public EventController()
        {
            _eventMan = new EventManager();
        }

        public ActionResult Search(EventViewModel eViewModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.Error("Event Controller - Search: " + ex.ToString());

                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Search", eViewModel);
        }

        public JsonResult Get_Events(EventViewModel eViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = eViewModel.Pager;

                if (!string.IsNullOrEmpty(eViewModel.Filter.Event_Name) && !string.IsNullOrEmpty(eViewModel.Filter.Month))
                {
                    eViewModel.events = _eventMan.Get_Events_By_Event_Name_And_Month(ref pager, eViewModel.Filter.Event_Name, eViewModel.Filter.Month);
                }
                else if (!string.IsNullOrEmpty(eViewModel.Filter.Event_Name))
                {
                    eViewModel.events = _eventMan.Get_Events_By_Event_Name(ref pager, eViewModel.Filter.Event_Name);
                }
                else if (!string.IsNullOrEmpty(eViewModel.Filter.Month))
                {
                    eViewModel.events = _eventMan.Get_Events_By_Month(ref pager, eViewModel.Filter.Month);
                }
                else
                {
                    eViewModel.events = _eventMan.Get_Events(ref pager);
                }

                eViewModel.Pager = pager;

                eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Events: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(eViewModel);
        }

        public ActionResult Index(EventViewModel eViewModel)
        {
            try
            {

                if (TempData["EventViewModel"] != null)
                {
                    eViewModel = (EventViewModel)TempData["EventViewModel"];
                }

                if (eViewModel.Event.Event_Id != 0)
                {
                    eViewModel.Event = _eventMan.Get_Event_By_Id(eViewModel.Event.Event_Id);

                    if (eViewModel.Event.Attachment_Id != 0)
                    {
                        eViewModel.Event.Attachment_Url = ConfigurationManager.AppSettings["Upload_Image_Path"].ToString() + @"\" + eViewModel.Event.Attachment_Type_Str + @"\" + eViewModel.Event.Attachment_Url;
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.Error("Event Controller - Index: " + ex.ToString());

                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", eViewModel);
        }

        public ActionResult Save_Event(EventViewModel eViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                eViewModel.Event.Updated_By = session.User_Id;
                eViewModel.Event.Updated_On = DateTime.Now;
                eViewModel.Event.Created_By = session.User_Id;
                eViewModel.Event.Created_On = DateTime.Now;

                if (eViewModel.Event.Event_Id != 0)
                {
                    _eventMan.Update_Event(eViewModel.Event);

                    eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT02"));
                }
                else
                {
                    eViewModel.Event.Event_Id = _eventMan.Insert_Event(eViewModel.Event);

                    eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT01"));
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Event Controller - Save_Event: " + ex.ToString());

                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            TempData["EventViewModel"] = eViewModel;

            return RedirectToAction("Index", "Event");
        }

        public JsonResult Get_Event_Dates(EventViewModel eViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = eViewModel.Pager;

                if (eViewModel.Event.Event_Id != 0)
                {
                    eViewModel.Event.Event_Dates = _eventMan.Get_Event_Date_By_Event_Id(ref pager, eViewModel.Event.Event_Id);

                    eViewModel.Pager = pager;

                    eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
                }

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_Dates: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(eViewModel);
        }

        public JsonResult Save_Event_Date(EventViewModel eViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                eViewModel.Event.event_date.Updated_By = session.User_Id;
                eViewModel.Event.event_date.Updated_On = DateTime.Now;
                eViewModel.Event.event_date.Created_By = session.User_Id;
                eViewModel.Event.event_date.Created_On = DateTime.Now;


                if (eViewModel.Event.event_date.Event_Date_Id != 0)
                {
                    _eventMan.Update_Event_Date(eViewModel.Event.event_date);

                    eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT04"));

                }
                else
                {
                    _eventMan.Insert_Event_Date(eViewModel.Event.event_date);

                    eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT03"));
                }

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Save_Event_Date: " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Get_Event_Date_By_Id(EventViewModel eViewModel)
        {

            try
            {

                eViewModel.Event.event_date = _eventMan.Get_Event_Date_By_Id(eViewModel.Event.event_date.Event_Date_Id);

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_Date_By_Id: " + ex.ToString());
            }

            return Json(eViewModel);
        }


        public ActionResult Event_Subscribe(EventViewModel eViewModel)
        {
            try
            {
                eViewModel.Event = _eventMan.Get_Event_By_Id(eViewModel.Event.Event_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("Event Controller - Event_Subscribe: " + ex.ToString());

                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("EventSubscribe", eViewModel);
        }

        public JsonResult Get_Event_By_Name_Autocomplete(string Event_Name)
        {

            EventViewModel eViewModel = new EventViewModel();
            List<AutocompleteInfo> eventList = new List<AutocompleteInfo>();

            try
            {

                eventList = _eventMan.Get_Event_By_Name_Autocomplete(Event_Name);

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_By_Name_Autocomplete: " + ex.ToString());
            }

            return Json(eventList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Customer_By_Name_Autocomplete(string Customer_Name, int Event_Id)
        {

            EventViewModel eViewModel = new EventViewModel();
            List<AutocompleteInfo> customerList = new List<AutocompleteInfo>();

            try
            {

                customerList = _eventMan.Get_Customer_By_Name_Autocomplete(Customer_Name, Event_Id);

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Customer_By_Name_Autocomplete: " + ex.ToString());
            }

            return Json(customerList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save_Customer_Event_Mapping(EventViewModel eViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                eViewModel.Event.customer_event_mapping.Is_Active = true;
                eViewModel.Event.customer_event_mapping.Updated_By = session.User_Id;
                eViewModel.Event.customer_event_mapping.Updated_On = DateTime.Now;
                eViewModel.Event.customer_event_mapping.Created_By = session.User_Id;
                eViewModel.Event.customer_event_mapping.Created_On = DateTime.Now;

                _eventMan.Insert_Customer_Event_Mapping(eViewModel.Event.customer_event_mapping);

                eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT05"));

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Save_Customer_Event_Mapping: " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Get_Event_Customers_By_Event_Id(EventViewModel eViewModel)
        {

            try
            {
                eViewModel.Event.customer_event_mappings = _eventMan.Get_Event_Customers_By_Event_Id(eViewModel.Event.Event_Id);
                eViewModel.eventdates = _eventMan.Get_Event_Dates(eViewModel.Event.Event_Id);

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_Customers_By_Event_Id: " + ex.ToString());
            }

            return Json(eViewModel);
        }

        public JsonResult Get_Event_Members(EventViewModel eViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = eViewModel.Pager;
                eViewModel.Event.member_event_mappings = _eventMan.Get_Event_Members(ref pager, eViewModel.Event.customer_event_mapping.Event_Id, eViewModel.Event.customer_event_mapping.Customer_Id);

                eViewModel.Pager = pager;
                eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_Members: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(eViewModel);
        }

        public JsonResult Save_Event_Members(EventViewModel eViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                foreach (var item in eViewModel.Event.member_event_mappings)
                {
                    item.Is_Active = true;
                    item.Updated_By = session.User_Id;
                    item.Updated_On = DateTime.Now;
                    item.Created_By = session.User_Id;
                    item.Created_On = DateTime.Now;

                    //eViewModel.Event.member_event_mappings = 
                }

                _eventMan.Save_Event_Members(eViewModel.Event.member_event_mappings);

                eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT06"));

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Save_Customer_Event_Mapping: " + ex.ToString());
            }

            return Json(eViewModel);
        }

        //event attendance
        public ActionResult Event_Attendance(EventViewModel eViewModel)
        {
            try
            {
                eViewModel.Event = _eventMan.Get_Event_By_Id(eViewModel.Event.Event_Id);

            }
            catch (Exception ex)
            {
                Logger.Error("Event Controller - Event_Attendance: " + ex.ToString());

                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("EventAttendance", eViewModel);
        }

        public JsonResult Get_Event_Member_Attendance(EventViewModel eViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = eViewModel.Pager;
                eViewModel.Event.event_attendances = _eventMan.Get_Event_Member_Attendance(ref pager, eViewModel.Event.event_attendance.Event_Id, eViewModel.Event.event_attendance.Customer_Id, eViewModel.Event.event_attendance.Date);

                eViewModel.Pager = pager;
                eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Get_Event_Member_Attendance: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(eViewModel);
        }

        public JsonResult Save_Event_Attendance(EventViewModel eViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                foreach (var item in eViewModel.Event.event_attendances)
                {
                    item.Is_Active = true;
                    item.Updated_By = session.User_Id;
                    item.Updated_On = DateTime.Now;
                    item.Created_By = session.User_Id;
                    item.Created_On = DateTime.Now;

                }

                _eventMan.Save_Event_Attendance(eViewModel.Event.event_attendances);

                eViewModel.FriendlyMessage.Add(MessageStore.Get("EVT07"));

            }
            catch (Exception ex)
            {
                eViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Event Controller - Save_Customer_Event_Mapping: " + ex.ToString());
            }

            return Json(eViewModel);
        }



        //public ActionResult AssignEvent()
        //{
        //    return View();
        //}


    }
}
