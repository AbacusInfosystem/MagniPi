using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Customer;
using MagniPiBusinessEntities.Event;
using MagniPiBusinessEntities.Worker;
using MagniPiDataAccess.Utilities;
using MagniPiDataAccess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Customer
{
    public class CustomerRepo
    {

        SQLHelperRepo _sqlRepo;

        public CustomerRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Customer(CustomerInfo customer)
        {
            int Customer_Id = 0;

            Customer_Id = Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Customer(customer), StoredProcedures.Insert_Customer_Sp.ToString(), CommandType.StoredProcedure));

            if (customer.Is_Indivisual)
            {
                customer.member.Customer_Id = Customer_Id;

                _sqlRepo.ExecuteNonQuery(Set_Values_In_Member(customer.member), StoredProcedures.Insert_Member_Sp.ToString(), CommandType.StoredProcedure);
            }

            return Customer_Id;
        }

        public void Update_Customer(CustomerInfo customer)
        {
           
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer(customer), StoredProcedures.Update_Customer_Sp.ToString(), CommandType.StoredProcedure);

            if (customer.Is_Indivisual)
            {
                _sqlRepo.ExecuteNonQuery(Set_Values_In_Member(customer.member), StoredProcedures.Update_Member_Sp.ToString(), CommandType.StoredProcedure);
            }
        }

        private List<SqlParameter> Set_Values_In_Customer(CustomerInfo customer)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (customer.Customer_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Customer_Id", customer.Customer_Id));
            }

            sqlParams.Add(new SqlParameter("@Customer_Name", customer.Customer_Name));
            sqlParams.Add(new SqlParameter("@Description", customer.Description));
            sqlParams.Add(new SqlParameter("@Address", customer.Address));
            sqlParams.Add(new SqlParameter("@Contact", customer.Contact));
            sqlParams.Add(new SqlParameter("@Email", customer.Email));
            sqlParams.Add(new SqlParameter("@Is_Indivisual", customer.Is_Indivisual));
            sqlParams.Add(new SqlParameter("@Is_Active", customer.Is_Active));

            if (customer.Customer_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", customer.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", customer.Created_On));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", customer.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", customer.Updated_On));

            return sqlParams;
        }

        private List<SqlParameter> Set_Values_In_Member(MemberInfo member)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (member.Member_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Member_Id", member.Member_Id));
            }

            sqlParams.Add(new SqlParameter("@Customer_Id", member.Customer_Id));
            sqlParams.Add(new SqlParameter("@First_Name", member.First_Name));
            sqlParams.Add(new SqlParameter("@Last_Name", member.Last_Name));
            sqlParams.Add(new SqlParameter("@Gender", member.Gender));
            sqlParams.Add(new SqlParameter("@Contact", member.Contact));
            sqlParams.Add(new SqlParameter("@Email", member.Email));
            sqlParams.Add(new SqlParameter("@Address", member.Address));
            sqlParams.Add(new SqlParameter("@Is_Active", member.Is_Active));

            if (member.Member_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", member.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", member.Created_On));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", member.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", member.Updated_On));

            return sqlParams;
        }

        public List<CustomerInfo> Get_Customers(ref PaginationInfo Pager)
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Customers_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                customers.Add(Get_Customer_Values(dr));
            }
            return customers;
        }

        public CustomerInfo Get_Customer_By_Id(int Customer_Id)
        {
            CustomerInfo customer = new CustomerInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                customer = Get_Customer_Values(dr);
            }
            return customer;
        }

        private CustomerInfo Get_Customer_Values(DataRow dr)
        {
            CustomerInfo customer = new CustomerInfo();

            customer.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
            customer.Description = Convert.ToString(dr["Description"]);
            customer.Address = Convert.ToString(dr["Address"]);
            customer.Contact = Convert.ToString(dr["Contact"]);
            customer.Email = Convert.ToString(dr["Email"]);
            customer.Is_Indivisual = Convert.ToBoolean(dr["Is_Indivisual"]);
            customer.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            customer.Created_By = Convert.ToInt32(dr["Created_By"]);
            customer.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            customer.Created_On = Convert.ToDateTime(dr["Created_On"]);
            customer.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return customer;
        }

        //filter
        public List<CustomerInfo> Get_Customers_By_Customer_Name_And_Contact(ref PaginationInfo Pager, string Customer_Name, string Contact)
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));
            sqlParams.Add(new SqlParameter("@Contact", Contact));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customers_By_Customer_Name_And_Contact_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                customers.Add(Get_Customer_Values(dr));
            }
            return customers;
        }

        public List<CustomerInfo> Get_Customers_By_Customer_Name(ref PaginationInfo Pager, string Customer_Name)
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customers_By_Customer_Name_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                customers.Add(Get_Customer_Values(dr));
            }
            return customers;
        }

        public List<CustomerInfo> Get_Customers_By_Contact(ref PaginationInfo Pager, string Contact)
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Contact", Contact));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customers_By_Contact_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                customers.Add(Get_Customer_Values(dr));
            }
            return customers;
        }

        //member
        public List<MemberInfo> Get_Member_Customer_By_Id(int Customer_Id)
        {
            List<MemberInfo> members = new List<MemberInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Member_Customer_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                members.Add(Get_Member_Values(dr));
            }
            return members;
        }

        private MemberInfo Get_Member_Values(DataRow dr)
        {
            MemberInfo member = new MemberInfo();

            member.Member_Id = Convert.ToInt32(dr["Member_Id"]);
            member.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            member.First_Name = Convert.ToString(dr["First_Name"]);
            member.Last_Name = Convert.ToString(dr["Last_Name"]);
            member.Gender = Convert.ToString(dr["Gender"]);
            member.Contact = Convert.ToString(dr["Contact"]);
            member.Email = Convert.ToString(dr["Email"]);
            member.Address = Convert.ToString(dr["Address"]);
            member.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            member.Created_By = Convert.ToInt32(dr["Created_By"]);
            member.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            member.Created_On = Convert.ToDateTime(dr["Created_On"]);
            member.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return member;
        }

        public void Insert_Member(MemberInfo member)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Member(member), StoredProcedures.Insert_Member_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Member(MemberInfo member)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Member(member), StoredProcedures.Update_Member_Sp.ToString(), CommandType.StoredProcedure);
        }

        public MemberInfo Get_Member_By_Id(int Customer_Id, int Member_Id)
        {
            MemberInfo member = new MemberInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));
            sqlParams.Add(new SqlParameter("@Member_Id", Member_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Member_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                member = Get_Member_Values(dr);
            }
            return member;
        }

        //event
        public List<EventInfo> Get_Event_By_Customer_Id(int Customer_Id)
        {
            List<EventInfo> events = new List<EventInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_By_Customer_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                events.Add(Get_Event_Values(dr));
            }
            return events;
        }

        private EventInfo Get_Event_Values(DataRow dr)
        {
            EventInfo Event = new EventInfo();

            Event.Event_Id = Convert.ToInt32(dr["Event_Id"]);
            Event.Event_Name = Convert.ToString(dr["Event_Name"]);
            Event.Description = Convert.ToString(dr["Description"]);
            Event.Event_Type = Convert.ToInt32(dr["Event_Type"]);
            Event.Location = Convert.ToString(dr["Location"]);
            Event.Attachment_Id = Convert.ToInt32(dr["Attachment_Id"]);
            Event.Is_Stoped = Convert.ToBoolean(dr["Is_Stoped"]);
            Event.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            Event.Created_By = Convert.ToInt32(dr["Created_By"]);
            Event.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            Event.Created_On = Convert.ToDateTime(dr["Created_On"]);
            Event.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return Event;
        }

        //autocomplete
        public List<AutocompleteInfo> Get_Customer_By_Name_Autocomplete(string Customer_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_By_Name_Autocomplete_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo autoData = new AutocompleteInfo();

                autoData.Label = Convert.ToString(dr["Customer_Name"]);
                autoData.Value = Convert.ToInt32(dr["Customer_Id"]);

                autoList.Add(autoData);
            }
            return autoList;
        }

        


    }
}
