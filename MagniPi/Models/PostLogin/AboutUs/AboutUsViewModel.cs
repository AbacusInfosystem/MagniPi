using MagniPi.Common;
using MagniPiBusinessEntities.AboutUs;
using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.AboutUs
{
    public class AboutUsViewModel
    {
        public AboutUsViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            aboutus = new AboutUsInfo();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        //public PaginationInfo Pager { get; set; }

        public AboutUsInfo aboutus { get; set; }

    }
}