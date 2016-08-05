using MagniPi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Dashboard
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
}