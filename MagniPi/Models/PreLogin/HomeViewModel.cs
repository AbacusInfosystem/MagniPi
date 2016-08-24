using MagniPi.Common;
using MagniPiBusinessEntities.AboutUs;
using MagniPiBusinessEntities.Blog;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Service;
using MagniPiBusinessEntities.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PreLogin
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            blog = new BlogInfo();

            blogs = new List<BlogInfo>();

            service = new ServiceInfo();

            services = new List<ServiceInfo>();

            aboutus = new AboutUsInfo();

            testimonials = new List<TestimonialInfo>();


            Filter = new Home_Filter();


        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public BlogInfo blog { get; set; }

        public List<BlogInfo> blogs { get; set; }

        public ServiceInfo service { get; set; }

        public List<ServiceInfo> services { get; set; }

        public AboutUsInfo aboutus { get; set; }

        public List<TestimonialInfo> testimonials { get; set; }


        public Home_Filter Filter { get; set; }

    }

    public class Home_Filter
    {
        
        public string Blog_Month { get; set; }

        public string Service_Title { get; set; }

    }

}