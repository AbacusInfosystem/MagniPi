using MagniPi.Common;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Testimonial
{
    public class TestimonialViewModel
    {
        public TestimonialViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            testimonial = new TestimonialInfo();

            testimonials = new List<TestimonialInfo>();


        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public TestimonialInfo testimonial { get; set; }

        public List<TestimonialInfo> testimonials { get; set; }


    }
}