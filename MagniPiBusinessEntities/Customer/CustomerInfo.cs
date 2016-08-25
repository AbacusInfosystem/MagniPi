using MagniPiBusinessEntities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Customer
{
   
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            member = new MemberInfo();

            members = new List<MemberInfo>();

            events = new List<EventInfo>();


        }

        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public bool Is_Indivisual { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        public MemberInfo member { get; set; }

        public List<MemberInfo> members { get; set; }

        public List<EventInfo> events { get; set; }

    }

    public class MemberInfo
    {
        public int Member_Id { get; set; }

        public int Customer_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Gender { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
