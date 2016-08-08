using MagniPi.Common;
using MagniPi.Models.PostLogin.Dashboard;
using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Dashboard
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            DashboardViewModel dViewModel = new DashboardViewModel();

            try
            {
                if (TempData["FriendlyMessage"] != null)
                {
                    dViewModel.FriendlyMessage.Add((FriendlyMessage)TempData["FriendlyMessage"]);
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Error : " + ex.ToString());

                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", dViewModel);
        }

    }
}
