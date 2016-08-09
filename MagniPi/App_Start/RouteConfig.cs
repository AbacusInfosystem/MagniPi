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

            routes.MapRoute(
                name: "upload-file-5",
                url: "upload-file/get-browsed-images",
                defaults: new { controller = "UploadFile", action = "Get_Attachment_By_Type", id = UrlParameter.Optional }
            );

            #endregion

            #region Blog

            routes.MapRoute(
                name: "blog-1",
                url: "blog/search-blogs",
                defaults: new { controller = "Blog", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "blog-2",
                url: "blog/get-blogs",
                defaults: new { controller = "Blog", action = "Get_Blogs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "blog-3",
                url: "blog/save-blog",
                defaults: new { controller = "Blog", action = "Save_Blog", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "blog-4",
                url: "blog/get-blog-by-id",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );


            #endregion

            #region home

            routes.MapRoute(
                name: "home-1",
                url: "home/view-blog-details-by-id",
                defaults: new { controller = "Home", action = "BlogDetails", id = UrlParameter.Optional }
            );

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
				defaults :new
				{
					controller = "Home",
					action = "Home",
					id = UrlParameter.Optional
				}
            );
        }
    }
}