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

			routes.MapRoute(
			   name :"upload-file-6",
			   url :"upload-file/get-images",
			   defaults :new
			   {
				   controller = "Get_Images",
				   action = "Get_Attachment_By_Type",
				   id = UrlParameter.Optional
			   }
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

            #region Customer

            routes.MapRoute(
                name: "event-1",
                url: "event/search-events",
                defaults: new { controller = "Event", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-2",
                url: "event/get-events",
                defaults: new { controller = "Event", action = "Get_Events", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-3",
                url: "event/save-event",
                defaults: new { controller = "Event", action = "Save_Event", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-4",
                url: "event/get-event-by-id",
                defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-5",
                url: "event/get-event-dates-by-event-id",
                defaults: new { controller = "Event", action = "Get_Event_Dates", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-6",
                url: "event/save-event-date",
                defaults: new { controller = "Event", action = "Save_Event_Date", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-7",
                url: "event/get-event-date-by-id",
                defaults: new { controller = "Event", action = "Get_Event_Date_By_Id", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-8",
                url: "event/subscribe-event-details",
                defaults: new { controller = "Event", action = "Event_Subscribe", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-9",
                url: "event/get-event-attenance-details",
                defaults: new { controller = "Event", action = "Event_Attendance", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-10",
                url: "event/get-event-list-by-name/{Event_Name}",
                defaults: new { controller = "Event", action = "Get_Event_By_Name_Autocomplete", Event_Name = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-11",
                url: "event/get-customer-list-by-name/{Customer_Name}/{Event_Id}",
                defaults: new { controller = "Event", action = "Get_Customer_By_Name_Autocomplete", Customer_Name = UrlParameter.Optional, Event_Id = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-12",
                url: "event/get-customers-by-event-id",
                defaults: new { controller = "Event", action = "Get_Event_Customers_By_Event_Id", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-13",
                url: "event/save-event-customer-mapping",
                defaults: new { controller = "Event", action = "Save_Customer_Event_Mapping", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "event-14",
                url: "event/get-member-by-customer-id",
                defaults: new { controller = "Event", action = "Get_Event_Members", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "event-15",
               url: "event/save-event-member-mapping",
               defaults: new { controller = "Event", action = "Save_Event_Members", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-16",
               url: "event/get-members-attendance",
               defaults: new { controller = "Event", action = "Get_Event_Member_Attendance", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-17",
               url: "event/save-event-attendance",
               defaults: new { controller = "Event", action = "Save_Event_Attendance", id = UrlParameter.Optional }
           );


            #endregion

            #region home

            routes.MapRoute(
                name: "home-1",
                url: "home/view-blog-details-by-id",
                defaults: new { controller = "Home", action = "Blog_Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-2",
                url: "home/view-service-details-by-id",
                defaults: new { controller = "Home", action = "Service_Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-3",
                url: "home/get-blogs-listing",
                defaults: new { controller = "Home", action = "Blog_Listing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-4",
                url: "home/get-blogs",
                defaults: new { controller = "Home", action = "Get_Blogs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-5",
                url: "home/get-services-listing",
                defaults: new { controller = "Home", action = "Service_Listing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-6",
                url: "home/get-services",
                defaults: new { controller = "Home", action = "Get_Services", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-7",
                url: "home/get-about-us",
                defaults: new { controller = "Home", action = "AboutUs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-8",
                url: "home/get-testimonial-listing",
                defaults: new { controller = "Home", action = "Testimonial_Listing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "home-9",
                url: "home/get-testimonials-list",
                defaults: new { controller = "Home", action = "Get_Testimonials", id = UrlParameter.Optional }
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