﻿using System;
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

            #region Service

            routes.MapRoute(
                name: "service-1",
                url: "service/search-services",
                defaults: new { controller = "Service", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "service-2",
                url: "service/get-services",
                defaults: new { controller = "Service", action = "Get_Services", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "service-3",
                url: "service/save-service",
                defaults: new { controller = "Service", action = "Save_Service", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "service-4",
                url: "service/get-service-by-id",
                defaults: new { controller = "Service", action = "Index", id = UrlParameter.Optional }
            );
            
            #endregion

            #region Testimonial

            routes.MapRoute(
                name: "testimonial-1",
                url: "testimonial/search-testimonials",
                defaults: new { controller = "Testimonial", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "testimonial-2",
                url: "testimonial/get-testimonials",
                defaults: new { controller = "Testimonial", action = "Get_Testimonials", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "testimonial-3",
                url: "testimonial/save-testimonial",
                defaults: new { controller = "Testimonial", action = "Save_Testimonial", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "testimonial-4",
                url: "testimonial/get-testimonial-by-id",
                defaults: new { controller = "Testimonial", action = "Index", id = UrlParameter.Optional }
            );

            #endregion

            #region About Us

            routes.MapRoute(
                name: "about-us-1",
                url: "about-us/get-about-us-by-id",
                defaults: new { controller = "AboutUs", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "about-us-2",
                url: "about-us/save-about-us",
                defaults: new { controller = "AboutUs", action = "Save_About_Us", id = UrlParameter.Optional }
            );

            #endregion

            #region Customer

            routes.MapRoute(
                name: "customer-1",
                url: "customer/search-customers",
                defaults: new { controller = "Customer", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-2",
                url: "customer/get-customers",
                defaults: new { controller = "Customer", action = "Get_Customers", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-3",
                url: "customer/save-customer",
                defaults: new { controller = "Customer", action = "Save_Customer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-4",
                url: "customer/get-customer-by-id",
                defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-5",
                url: "customer/add-customer-members",
                defaults: new { controller = "Customer", action = "Add_Customer_Member", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-6",
                url: "customer/get-customer-members-by-customer-id",
                defaults: new { controller = "Customer", action = "Get_Customer_Members", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-7",
                url: "customer/save-customer-member",
                defaults: new { controller = "Customer", action = "Save_Customer_Member", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-8",
                url: "customer/get-member-details-by-id",
                defaults: new { controller = "Customer", action = "Get_Customer_Member_By_Id", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-9",
                url: "customer/get-customer-list-by-name/{Customer_Name}",
                defaults: new { controller = "Customer", action = "Get_Customer_By_Name_Autocomplete", Customer_Name=UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "customer-10",
                url: "customer/get-customer-events-by-customer-id",
                defaults: new { controller = "Customer", action = "Get_Event_By_Customer_Id", id = UrlParameter.Optional }
            );


            #endregion

            #region home

            routes.MapRoute(
                name: "home-1",
                url: "home/view-blog-details-by-id",
                defaults: new { controller = "Home", action = "BlogDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-2",
                url: "home/view-service-details-by-id",
                defaults: new { controller = "Home", action = "ServiceDetails", id = UrlParameter.Optional }
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