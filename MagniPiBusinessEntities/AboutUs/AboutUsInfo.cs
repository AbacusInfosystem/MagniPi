using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.AboutUs
{
    public class AboutUsInfo
    {
        public int About_Us_Id { get; set; }

        public string About_Us_Template { get; set; }

        public int Attachment_Id { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
