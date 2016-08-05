using MagniPi.Common;
using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PreLogin
{
    public class AuthenticationViewModel
    {
        public AuthenticationViewModel()
        {
            Session = new SessionInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public SessionInfo Session { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }
}