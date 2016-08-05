using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Testimonial
{
    public class TestimonialInfo
    {
        public int Testimonial_Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Attachment_Id { get; set; }

        public string Author_Name { get; set; }

        public string Author_Designation { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
