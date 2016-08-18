using MagniPiDataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagniPiBusinessEntities.Event;
using System.Data.SqlClient;
using System.Data;
using MagniPiBusinessEntities.Common;
using MagniPiRepo.Common;

namespace MagniPiDataAccess.Event
{
    public class EventRepo
    {

        SQLHelperRepo _sqlRepo;

        public EventRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Event(EventInfo Event)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Event(Event), StoredProcedures.Insert_Event_Sp.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Event(EventInfo Event)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Event(Event), StoredProcedures.Update_Event_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Event(EventInfo Event)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (Event.Event_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Event_Id", Event.Event_Id));
            }

            sqlParams.Add(new SqlParameter("@Event_Name", Event.Event_Name));
            sqlParams.Add(new SqlParameter("@Description", Event.Description));
            sqlParams.Add(new SqlParameter("@Event_Type", Event.Event_Type));
            sqlParams.Add(new SqlParameter("@Location", Event.Location));
            sqlParams.Add(new SqlParameter("@Attachment_Id", Event.Attachment_Id));
            sqlParams.Add(new SqlParameter("@Is_Stoped", Event.Is_Stoped));
            sqlParams.Add(new SqlParameter("@Is_Active", Event.Is_Active));

            if (Event.Event_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", Event.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", Event.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", Event.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", Event.Updated_On));

            return sqlParams;
        }

        public List<EventInfo> Get_Events(ref PaginationInfo Pager)
        {
            List<EventInfo> events = new List<EventInfo>();

            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Events_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                events.Add(Get_Event_Values(dr));
            }
            return events;
        }

        public EventInfo Get_Event_By_Id(int Event_Id)
        {
            EventInfo Event = new EventInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Event = Get_Event_Values_By_Id(dr);
            }
            return Event;
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

        private EventInfo Get_Event_Values_By_Id(DataRow dr)
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

            if (dr["File_Type"] != DBNull.Value)
            {
                Event.Attachment_Type = Convert.ToInt32(dr["File_Type"]);
            }
            if (dr["Unique_Id"] != DBNull.Value)
            {
                Event.Attachment_Url = Convert.ToString(dr["Unique_Id"]);
            }

            return Event;
        }
       
        //filter
        public List<EventInfo> Get_Events_By_Event_Name_And_Month(ref PaginationInfo Pager, string Event_Name, string Month)
        {
            List<EventInfo> events = new List<EventInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Name", Event_Name));
            sqlParams.Add(new SqlParameter("@Month", Month.Substring(0, 2)));
            sqlParams.Add(new SqlParameter("@Year", Month.Substring(Month.LastIndexOf('-') + 1)));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Events_By_Event_Name_And_Month_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                events.Add(Get_Event_Values(dr));
            }
            return events;
        }

        public List<EventInfo> Get_Events_By_Event_Name(ref PaginationInfo Pager, string Event_Name)
        {
            List<EventInfo> events = new List<EventInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Name", Event_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Events_By_Event_Name_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                events.Add(Get_Event_Values(dr));
            }
            return events;
        }

        public List<EventInfo> Get_Events_By_Month(ref PaginationInfo Pager, string Month)
        {
            List<EventInfo> events = new List<EventInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Month", Month.Substring(0, 2)));
            sqlParams.Add(new SqlParameter("@Year", Month.Substring(Month.LastIndexOf('-') + 1)));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Events_By_Month_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                events.Add(Get_Event_Values(dr));
            }
            return events;
        }


        //event date
        public List<EventDateInfo> Get_Event_Date_By_Event_Id(ref PaginationInfo Pager, int Event_Id)
        {
            List<EventDateInfo> eventdates = new List<EventDateInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Dates_By_Event_Id_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                eventdates.Add(Get_Event_Date_Values(dr));
            }
            return eventdates;
        }

        private EventDateInfo Get_Event_Date_Values(DataRow dr)
        {
            EventDateInfo eventdate = new EventDateInfo();

            eventdate.Event_Date_Id = Convert.ToInt32(dr["Event_Date_Id"]);
            eventdate.Event_Id = Convert.ToInt32(dr["Event_Id"]);
            eventdate.Date = Convert.ToDateTime(dr["Date"]);
            eventdate.Start_Time = Convert.ToString(dr["Start_Time"]);
            eventdate.End_Time = Convert.ToString(dr["End_Time"]);
            eventdate.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            eventdate.Created_By = Convert.ToInt32(dr["Created_By"]);
            eventdate.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            eventdate.Created_On = Convert.ToDateTime(dr["Created_On"]);
            eventdate.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return eventdate;
        }

        public void Insert_Event_Date(EventDateInfo eventdate)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Event_Date(eventdate), StoredProcedures.Insert_Event_Date_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Event_Date(EventDateInfo eventdate)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Event_Date(eventdate), StoredProcedures.Update_Event_Date_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Event_Date(EventDateInfo eventdate)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (eventdate.Event_Date_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Event_Date_Id", eventdate.Event_Date_Id));
            }            
            sqlParams.Add(new SqlParameter("@Event_Id", eventdate.Event_Id));
            sqlParams.Add(new SqlParameter("@Date", eventdate.Date));
            sqlParams.Add(new SqlParameter("@Start_Time", eventdate.Start_Time));
            sqlParams.Add(new SqlParameter("@End_Time", eventdate.End_Time));
            sqlParams.Add(new SqlParameter("@Is_Active", eventdate.Is_Active));

            if (eventdate.Event_Date_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", eventdate.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", eventdate.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", eventdate.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", eventdate.Updated_On));

            return sqlParams;
        }

        public EventDateInfo Get_Event_Date_By_Id(int Event_Date_Id)
        {
            EventDateInfo eventdate = new EventDateInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Date_Id", Event_Date_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Date_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                eventdate = Get_Event_Date_Values(dr);
            }
            return eventdate;
        }


        //autocomplete
        public List<AutocompleteInfo> Get_Event_By_Name_Autocomplete(string Event_Name)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Name", Event_Name));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_By_Name_Autocomplete_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                AutocompleteInfo autoData = new AutocompleteInfo();

                autoData.Label = Convert.ToString(dr["Event_Name"]);
                autoData.Value = Convert.ToInt32(dr["Event_Id"]);

                autoList.Add(autoData);
            }
            return autoList;
        }

        public List<AutocompleteInfo> Get_Customer_By_Name_Autocomplete(string Customer_Name, int Event_Id)
        {
            List<AutocompleteInfo> autoList = new List<AutocompleteInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Name", Customer_Name));
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Customer_Autocomplete_Sp.ToString(), CommandType.StoredProcedure);
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

        //customer event mapping
        public void Insert_Customer_Event_Mapping(CustomerEventMappingInfo customereventmapping)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Customer_Event_Mapping(customereventmapping), StoredProcedures.Insert_Customer_Event_Mapping_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Customer_Event_Mapping(CustomerEventMappingInfo customereventmapping)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            //sqlParams.Add(new SqlParameter("@Customer_Event_Mapping_Id", customereventmapping.Customer_Event_Mapping_Id));
            sqlParams.Add(new SqlParameter("@Event_Id", customereventmapping.Event_Id));
            sqlParams.Add(new SqlParameter("@Customer_Id", customereventmapping.Customer_Id));
            sqlParams.Add(new SqlParameter("@Is_Active", customereventmapping.Is_Active));
            sqlParams.Add(new SqlParameter("@Created_By", customereventmapping.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_By", customereventmapping.Updated_By));
            sqlParams.Add(new SqlParameter("@Created_On", customereventmapping.Created_On));
            sqlParams.Add(new SqlParameter("@Updated_On", customereventmapping.Updated_On));

            return sqlParams;
        }

        public List<CustomerEventMappingInfo> Get_Event_Customers_By_Event_Id(int Event_Id)
        {
            List<CustomerEventMappingInfo> customereventmappings = new List<CustomerEventMappingInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Customers_By_Event_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                customereventmappings.Add(Get_Customer_Event_Mapping_Values(dr));
            }
            return customereventmappings;
        }

        private CustomerEventMappingInfo Get_Customer_Event_Mapping_Values(DataRow dr)
        {
            CustomerEventMappingInfo customereventmapping = new CustomerEventMappingInfo();

            customereventmapping.Customer_Event_Mapping_Id = Convert.ToInt32(dr["Customer_Event_Mapping_Id"]);
            customereventmapping.Event_Id = Convert.ToInt32(dr["Event_Id"]);
            customereventmapping.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            customereventmapping.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            customereventmapping.Created_By = Convert.ToInt32(dr["Created_By"]);
            customereventmapping.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            customereventmapping.Created_On = Convert.ToDateTime(dr["Created_On"]);
            customereventmapping.Updated_On = Convert.ToDateTime(dr["Updated_On"]);
            customereventmapping.Customer_Name = Convert.ToString(dr["Customer_Name"]);

            return customereventmapping;
        }

        public List<MemberEventMappingInfo> Get_Event_Members(int Event_Id, int Customer_Id)
        {
            List<MemberEventMappingInfo> membereventmappings = new List<MemberEventMappingInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Members_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                membereventmappings.Add(Get_Member_Event_Mapping_Values(dr));
            }
            return membereventmappings;
        }

        private MemberEventMappingInfo Get_Member_Event_Mapping_Values(DataRow dr)
        {
            MemberEventMappingInfo membereventmapping = new MemberEventMappingInfo();

            membereventmapping.Member_Id = Convert.ToInt32(dr["Member_Id"]);
            membereventmapping.Member_Name = Convert.ToString(dr["Member_Name"]);
            membereventmapping.Contact = Convert.ToString(dr["Contact"]);


            if ((dr["Member_Event_Mapping_Id"]) != DBNull.Value)
            {
                membereventmapping.Member_Event_Mapping_Id = Convert.ToInt32(dr["Member_Event_Mapping_Id"]);
            }
               
            return membereventmapping;
        }

        public void Save_Event_Members(List<MemberEventMappingInfo> member_event_mappings)
        {
            foreach (var item in member_event_mappings)
            {
                if (item.Flag_Checked && item.Member_Event_Mapping_Id == 0)
                {
                    //insert
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Member_Event_Mapping(item), StoredProcedures.Insert_Member_Event_Mapping_Sp.ToString(), CommandType.StoredProcedure);
                }
                else if(!item.Flag_Checked && item.Member_Event_Mapping_Id != 0)
                {
                    //delete
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@Member_Event_Mapping_Id", item.Member_Event_Mapping_Id));

                    _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Member_Event_Mapping_By_Id_Sp.ToString(), CommandType.StoredProcedure);
                }
                else if (item.Flag_Checked && item.Member_Event_Mapping_Id != 0)
                {
                    //update
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Member_Event_Mapping(item), StoredProcedures.Update_Member_Event_Mapping_Sp.ToString(), CommandType.StoredProcedure);
                }

            }

        }

        private List<SqlParameter> Set_Values_In_Member_Event_Mapping(MemberEventMappingInfo membereventmapping)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (membereventmapping.Member_Event_Mapping_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Member_Event_Mapping_Id", membereventmapping.Member_Event_Mapping_Id));
            }
            
            sqlParams.Add(new SqlParameter("@Event_Id", membereventmapping.Event_Id));
            sqlParams.Add(new SqlParameter("@Member_Id", membereventmapping.Member_Id));
            sqlParams.Add(new SqlParameter("@Is_Remind", membereventmapping.Is_Remind));
            sqlParams.Add(new SqlParameter("@Is_Active", membereventmapping.Is_Active));

            if (membereventmapping.Member_Event_Mapping_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", membereventmapping.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", membereventmapping.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", membereventmapping.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", membereventmapping.Updated_On));

            return sqlParams;
        }

        public List<EventAttendanceInfo> Get_Event_Member_Attendance(int Event_Id, int Customer_Id, DateTime Date)
        {
            List<EventAttendanceInfo> eventattendances = new List<EventAttendanceInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));
            sqlParams.Add(new SqlParameter("@Customer_Id", Customer_Id));
            sqlParams.Add(new SqlParameter("@Date", Date));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Member_Attendance_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                eventattendances.Add(Get_Event_Attendance_Values(dr));
            }
            return eventattendances;
        }

        private EventAttendanceInfo Get_Event_Attendance_Values(DataRow dr)
        {
            EventAttendanceInfo eventattendance = new EventAttendanceInfo();

            eventattendance.Event_Id = Convert.ToInt32(dr["Event_Id"]);
            eventattendance.Customer_Id = Convert.ToInt32(dr["Customer_Id"]);
            eventattendance.Member_Id = Convert.ToInt32(dr["Member_Id"]);
            eventattendance.Member_Name = Convert.ToString(dr["Member_Name"]);
            eventattendance.Date = Convert.ToDateTime(dr["Date"]);

            if ((dr["Event_Attendance_Id"]) != DBNull.Value)
            {
                eventattendance.Event_Attendance_Id = Convert.ToInt32(dr["Event_Attendance_Id"]);
            }

            return eventattendance;
        }

        public List<EventDate> Get_Event_Dates(int Event_Id)
        {
            List<EventDate> dateList = new List<EventDate>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Event_Dates_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                EventDate date = new EventDate();

                date.Day = Convert.ToDateTime(dr["Date"]);

                dateList.Add(date);
            }
            return dateList;
        }

        public void Save_Event_Attendance(List<EventAttendanceInfo> eventattendances)
        {
            foreach (var item in eventattendances)
            {
                if(item.Flag && item.Event_Attendance_Id == 0)
                {
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Event_Attendance(item), StoredProcedures.Insert_Event_Attendance_Sp.ToString(), CommandType.StoredProcedure);
                }
                else if(!item.Flag && item.Event_Attendance_Id != 0)
                {
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@Event_Attendance_Id", item.Event_Attendance_Id));

                    _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Event_Attendance_By_Id_Sp.ToString(), CommandType.StoredProcedure);
                }
                else if (item.Flag && item.Event_Attendance_Id != 0)
                {
                    _sqlRepo.ExecuteNonQuery(Set_Values_In_Event_Attendance(item), StoredProcedures.Update_Event_Attendance_Sp.ToString(), CommandType.StoredProcedure);
                }

            }

            
            


        }

        private List<SqlParameter> Set_Values_In_Event_Attendance(EventAttendanceInfo eventattendance)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (eventattendance.Event_Attendance_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Event_Attendance_Id", eventattendance.Event_Attendance_Id));
            }
            sqlParams.Add(new SqlParameter("@Event_Id", eventattendance.Event_Id));
            sqlParams.Add(new SqlParameter("@Member_Id", eventattendance.Member_Id));
            sqlParams.Add(new SqlParameter("@Date", eventattendance.Date));
            sqlParams.Add(new SqlParameter("@Is_Active", eventattendance.Is_Active));

            if (eventattendance.Event_Attendance_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", eventattendance.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", eventattendance.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", eventattendance.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", eventattendance.Updated_On));

            return sqlParams;
        }




    }
}
