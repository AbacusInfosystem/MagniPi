using MagniPi.Common;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Service
{
    public class ServiceViewModel
    {
        public ServiceViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            service = new ServiceInfo();

            services = new List<ServiceInfo>();

            Filter = new Service_Filter();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public ServiceInfo service { get; set; }

        public List<ServiceInfo> services { get; set; }

        public Service_Filter Filter { get; set; }

    }

    public class Service_Filter
    {
        public string Service_Title { get; set; }

    }

}