using MagniPi.Filters;
using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Customer
{
	[SessionExpireAttribute]
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Index()
        {
            try
            {
               
               
            }
            catch(Exception ex)
            {
                Logger.Error("Exception : " + ex.ToString());
            }
            return View();
        }

        public ActionResult CustomerEventMapping()
        {
            return View();
        }


    }
}
