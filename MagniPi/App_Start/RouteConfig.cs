using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MagniPi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Login

            routes.MapRoute(
                name: "Login",
                url: "home/magnipi-admin",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #endregion

            #region Upload File

            routes.MapRoute(
                name: "upload-file-1",
                url: "upload-file/index",
                defaults: new { controller = "UploadFile", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "upload-file-2",
                url: "upload-file/save-file",
                defaults: new { controller = "UploadFile", action = "Upload_File", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "upload-file-3",
                url: "upload-file/view-attachment",
                defaults: new { controller = "UploadFile", action = "View_Attachment_By_Id", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "upload-file-4",
                url: "upload-file/delete-attachment",
                defaults: new { controller = "UploadFile", action = "Delete_Attachment_By_Id", id = UrlParameter.Optional }
            );

            #endregion


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}