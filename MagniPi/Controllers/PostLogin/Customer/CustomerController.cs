using MagniPi.Common;
using MagniPi.Models.PostLogin.Customer;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Customer;
using MagniPiHelper.Logging;
using MagniPiHelper.PageHelper;
using MagniPiManager.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Customer
{
    public class CustomerController : Controller
    {
        CustomerManager _customerMan;

        public CustomerController()
        {
            _customerMan = new CustomerManager();
        }

        public ActionResult Search(CustomerViewModel cViewModel)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Logger.Error("Customer Controller - Search: " + ex.ToString());

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Search", cViewModel);
        }

        public JsonResult Get_Customers(CustomerViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = cViewModel.Pager;

                if (!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name) && !string.IsNullOrEmpty(cViewModel.Filter.Contact))
                {
                    cViewModel.customers = _customerMan.Get_Customers_By_Customer_Name_And_Contact(ref pager, cViewModel.Filter.Customer_Name, cViewModel.Filter.Contact);
                }
                else if (!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name))
                {
                    cViewModel.customers = _customerMan.Get_Customers_By_Customer_Name(ref pager, cViewModel.Filter.Customer_Name);
                }
                else if (!string.IsNullOrEmpty(cViewModel.Filter.Contact))
                {
                    cViewModel.customers = _customerMan.Get_Customers_By_Contact(ref pager, cViewModel.Filter.Contact);
                }
                else
                {
                    cViewModel.customers = _customerMan.Get_Customers(ref pager);
                }

                cViewModel.Pager = pager;

                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customers: " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(cViewModel);
        }

        public ActionResult Index(CustomerViewModel cViewModel)
        {
            try
            {
               if (cViewModel.customer.Customer_Id != 0)
               {
                   cViewModel.customer = _customerMan.Get_Customer_By_Id(cViewModel.customer.Customer_Id);

                   if (cViewModel.customer.Is_Indivisual)
                   {
                       cViewModel.customer.members = _customerMan.Get_Member_Customer_By_Id(cViewModel.customer.Customer_Id);

                       cViewModel.customer.member = cViewModel.customer.members[0];
                   }

               }
               
            }
            catch(Exception ex)
            {
                Logger.Error("Customer Controller - Index: " + ex.ToString());

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", cViewModel);
        }

        public ActionResult Save_Customer(CustomerViewModel cViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                cViewModel.customer.Updated_By = session.User_Id;
                cViewModel.customer.Updated_On = DateTime.Now;
                cViewModel.customer.Created_By = session.User_Id;
                cViewModel.customer.Created_On = DateTime.Now;

                if (cViewModel.customer.Is_Indivisual)
                {
                    cViewModel.customer.member.Updated_By = session.User_Id;
                    cViewModel.customer.member.Updated_On = DateTime.Now;
                    cViewModel.customer.member.Created_By = session.User_Id;
                    cViewModel.customer.member.Created_On = DateTime.Now;
                }

                if (cViewModel.customer.Customer_Id != 0)
                {
                    _customerMan.Update_Customer(cViewModel.customer);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CST02"));

                }
                else
                {
                    _customerMan.Insert_Customer(cViewModel.customer);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CST01"));
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Customer Controller - Save_Customer: " + ex.ToString());

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Search", cViewModel);
        }

        public ActionResult Add_Customer_Member(CustomerViewModel cViewModel)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Logger.Error("Customer Controller - Add_Customer_Member: " + ex.ToString());

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("AddCustomerMember", cViewModel);
        }

        //member
        public JsonResult Get_Customer_Members(CustomerViewModel cViewModel)
        {
            try
            {
                if (cViewModel.customer.Customer_Id != 0)
                {
                    cViewModel.customer = _customerMan.Get_Customer_By_Id(cViewModel.customer.Customer_Id);

                    cViewModel.customer.members = _customerMan.Get_Member_Customer_By_Id(cViewModel.customer.Customer_Id);
                }
                
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customer_Members: " + ex.ToString());
            }
            
            return Json(cViewModel);
        }

        public JsonResult Save_Customer_Member(CustomerViewModel cViewModel)
        {
            try
            {
                SessionInfo session = new SessionInfo();

                if (Session["SessionInfo"] != null)
                {
                    session = (SessionInfo)Session["SessionInfo"];
                }

                cViewModel.customer.member.Updated_By = session.User_Id;
                cViewModel.customer.member.Updated_On = DateTime.Now;
                cViewModel.customer.member.Created_By = session.User_Id;
                cViewModel.customer.member.Created_On = DateTime.Now;    
                

                if (cViewModel.customer.member.Member_Id != 0)
                {
                    _customerMan.Update_Member(cViewModel.customer.member);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CMEM02"));

                }
                else
                {
                    _customerMan.Insert_Member(cViewModel.customer.member);

                    cViewModel.FriendlyMessage.Add(MessageStore.Get("CMEM01"));
                }

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Save_Customer_Member: " + ex.ToString());
            }

            return Json(cViewModel);
        }

        public JsonResult Get_Customer_Member_By_Id(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.customer.member = _customerMan.Get_Member_By_Id(cViewModel.customer.member.Customer_Id, cViewModel.customer.member.Member_Id);

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customer_Member_By_Id: " + ex.ToString());
            }

            return Json(cViewModel);
        }

        public JsonResult Get_Customer_By_Name_Autocomplete(string Customer_Name)
        {
            
            CustomerViewModel cViewModel = new CustomerViewModel();
            List<AutocompleteInfo> customerList = new List<AutocompleteInfo>();

            try
            {

                customerList = _customerMan.Get_Customer_By_Name_Autocomplete(Customer_Name);

            }
            catch(Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customer_By_Name_Autocomplete: " + ex.ToString());
            }

            return Json(customerList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Event_By_Customer_Id(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.customer.events = _customerMan.Get_Event_By_Customer_Id(cViewModel.customer.Customer_Id);

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Event_By_Customer_Id: " + ex.ToString());
            }

            return Json(cViewModel);
        }



        public ActionResult CustomerEventMapping()
        {
            return View();
        }

        


    }
}
