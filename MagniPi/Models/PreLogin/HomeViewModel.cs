using MagniPi.Common;
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

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
}