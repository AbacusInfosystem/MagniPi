using MagniPi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagniPi.Controllers.PostLogin.Feedback
{
	[SessionExpireAttribute]
    public class FeedbackController : Controller
    {
        //
		// GET: /Feedback/[SessionExpireAttribute]

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }


    }
}
