using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Customer;
using MagniPiBusinessEntities.Event;
using MagniPiDataAccess.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Customer
{
    public class CustomerManager
    {

        CustomerRepo _customerRepo;

        public CustomerManager()
        {
            _customerRepo = new CustomerRepo();
        }

        public void Insert_Customer(CustomerInfo customer)
        {
            _customerRepo.Insert_Customer(customer);
        }

        public void Update_Customer(CustomerInfo customer)
        {
            _customerRepo.Update_Customer(customer);
        }

        public List<CustomerInfo> Get_Customers(ref PaginationInfo Pager)
        {
            return _customerRepo.Get_Customers(ref Pager);
        }

        public CustomerInfo Get_Customer_By_Id(int Customer_Id)
        {
            return _customerRepo.Get_Customer_By_Id(Customer_Id);
        }

        public List<MemberInfo> Get_Member_Customer_By_Id(int Customer_Id)
        {
            return _customerRepo.Get_Member_Customer_By_Id(Customer_Id);
        }

        public List<CustomerInfo> Get_Customers_By_Customer_Name_And_Contact(ref PaginationInfo Pager, string Customer_Name, string Contact)
        {
            return _customerRepo.Get_Customers_By_Customer_Name_And_Contact(ref Pager, Customer_Name, Contact);
        }

        public List<CustomerInfo> Get_Customers_By_Customer_Name(ref PaginationInfo Pager, string Customer_Name)
        {
            return _customerRepo.Get_Customers_By_Customer_Name(ref Pager, Customer_Name);
        }

        public List<CustomerInfo> Get_Customers_By_Contact(ref PaginationInfo Pager, string Contact)
        {
            return _customerRepo.Get_Customers_By_Contact(ref Pager, Contact);
        }

        public void Insert_Member(MemberInfo member)
        {
            _customerRepo.Insert_Member(member);
        }

        public void Update_Member(MemberInfo member)
        {
            _customerRepo.Update_Member(member);
        }

        public MemberInfo Get_Member_By_Id(int Customer_Id, int Member_Id)
        {
            return _customerRepo.Get_Member_By_Id(Customer_Id, Member_Id);
        }

        public List<EventInfo> Get_Event_By_Customer_Id(int Customer_Id)
        {
            return _customerRepo.Get_Event_By_Customer_Id(Customer_Id);
        }

        public List<AutocompleteInfo> Get_Customer_By_Name_Autocomplete(string Customer_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            autoList = _customerRepo.Get_Customer_By_Name_Autocomplete(Customer_Name);

            return autoList;
        }

    }
}
