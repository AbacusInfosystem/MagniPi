using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace MagniPi.Filters
{
	public class SessionExpireAttribute:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			HttpContext ctx = HttpContext.Current;
			// check  sessions here
			if(HttpContext.Current.Session["SessionInfo"] == null)
			{
				filterContext.Result = new RedirectResult("~/Home/Index");
				return;
			}
			base.OnActionExecuting(filterContext);
		}
	}
}