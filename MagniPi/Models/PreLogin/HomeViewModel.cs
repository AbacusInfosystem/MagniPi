using MagniPi.Common;
using MagniPiBusinessEntities.Blog;
using MagniPiBusinessEntities.Service;
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

            blog = new BlogInfo();

            service = new ServiceInfo();


        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public BlogInfo blog { get; set; }

        public ServiceInfo service { get; set; }


    }
}