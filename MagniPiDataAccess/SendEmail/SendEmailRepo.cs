using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Customer;
using MagniPiBusinessEntities.Worker;
using MagniPiDataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.SendEmail
{
    public class SendEmailRepo
    {
        SQLHelperRepo _sqlRepo;

        public SendEmailRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        //Registration
        public List<CustomerInfo> Get_Customers_To_Send_Registration_Mail()
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Customer_To_Send_Mails_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                CustomerInfo customer = new CustomerInfo();

                customer.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
                customer.Customer_Name = Convert.ToString(dr["Customer_Name"]);
                customer.Email = Convert.ToString(dr["Email"]);

                customers.Add(customer);
            }

            return customers;
        }

        public void Update_Registration_Mail_Send_Flag(int Customer_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));
            sqlParams.Add(new SqlParameter("@Is_Email_Send", true));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Update_Registration_Mail_Send_Flag_Sp.ToString(), CommandType.StoredProcedure);
        }

        //Reminder
        public List<MemberEventInfo> Get_Members_To_Send_Reminder_Mail()
        {
            List<MemberEventInfo> eventmembers = new List<MemberEventInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Members_To_Send_Reminder_Mail_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                MemberEventInfo member = new MemberEventInfo();

                member.Member_Id = Convert.ToInt32(dr["Member_Id"]);
                member.Member_Name = Convert.ToString(dr["Member_Name"]);
                member.Email = Convert.ToString(dr["Email"]);

                member.Member_Event_Mapping_Id = Convert.ToInt32(dr["Member_Event_Mapping_Id"]);

                member.Event_Id = Convert.ToInt32(dr["Event_Id"]);
                member.Event_Name = Convert.ToString(dr["Event_Name"]);
                member.Event_Type = Convert.ToInt32(dr["Event_Type"]);
                member.Description = Convert.ToString(dr["Description"]);
                member.Location = Convert.ToString(dr["Location"]);

                eventmembers.Add(member);
            }

            return eventmembers;
        }

        public void Update_Reminder_Mail_Send_Flag(int Member_Event_Mapping_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Member_Event_Mapping_Id", Member_Event_Mapping_Id));
            sqlParams.Add(new SqlParameter("@Is_Remind", true));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Update_Reminder_Send_Flag_Sp.ToString(), CommandType.StoredProcedure);
        }

        //Thank_You
        public List<MemberEventInfo> Get_Members_To_Send_Thank_You_Mail()
        {
            List<MemberEventInfo> eventmembers = new List<MemberEventInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Members_To_Send_Thank_You_Mail_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                MemberEventInfo member = new MemberEventInfo();

                member.Member_Id = Convert.ToInt32(dr["Member_Id"]);
                member.Member_Name = Convert.ToString(dr["Member_Name"]);
                member.Email = Convert.ToString(dr["Email"]);

                member.Member_Event_Mapping_Id = Convert.ToInt32(dr["Member_Event_Mapping_Id"]);

                member.Event_Id = Convert.ToInt32(dr["Event_Id"]);
                member.Event_Name = Convert.ToString(dr["Event_Name"]);
                member.Event_Type = Convert.ToInt32(dr["Event_Type"]);
                member.Description = Convert.ToString(dr["Description"]);
                member.Location = Convert.ToString(dr["Location"]);
                
                eventmembers.Add(member);
            }

            return eventmembers;
        }

        public void Update_Thank_You_Mail_Send_Flag(int Member_Event_Mapping_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Member_Event_Mapping_Id", Member_Event_Mapping_Id));
            sqlParams.Add(new SqlParameter("@Is_Thank_You_Send", true));

            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Update_Thank_You_Mail_Send_Flag_Sp.ToString(), CommandType.StoredProcedure);
        }

        


    }
}
