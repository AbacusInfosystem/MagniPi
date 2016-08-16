using MagniPi.Common;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Customer
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            customer = new CustomerInfo();

            customers = new List<CustomerInfo>();

            Filter = new Customer_Filter();


        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public CustomerInfo customer { get; set; }

        public List<CustomerInfo> customers { get; set; }

        public Customer_Filter Filter { get; set; }


    }

    public class Customer_Filter
    {
        public string Customer_Name { get; set; }

        public string Contact { get; set; }

        //public int Customer_Id { get; set; }

    }

}