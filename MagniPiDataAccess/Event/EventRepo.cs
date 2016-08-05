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

        public void Insert_Event(EventInfo Event)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Event(Event), StoredProcedures.Insert_Event_Sp.ToString(), CommandType.StoredProcedure);
        }

        public void Update_Event(EventInfo Event)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Event(Event), StoredProcedures.Update_Event_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Event(EventInfo Event)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", Event.Event_Id));
            sqlParams.Add(new SqlParameter("@Event_Name", Event.Event_Name));
            sqlParams.Add(new SqlParameter("@Description", Event.Description));
            sqlParams.Add(new SqlParameter("@Event_Type", Event.Event_Type));
            sqlParams.Add(new SqlParameter("@Location", Event.Location));
            sqlParams.Add(new SqlParameter("@Attachment_Id", Event.Attachment_Id));
            sqlParams.Add(new SqlParameter("@Is_Stoped", Event.Is_Stoped));
            sqlParams.Add(new SqlParameter("@Is_Active", Event.Is_Active));
            sqlParams.Add(new SqlParameter("@Created_By", Event.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_By", Event.Updated_By));
            sqlParams.Add(new SqlParameter("@Created_On", Event.Created_On));
            sqlParams.Add(new SqlParameter("@Updated_On", Event.Updated_On));
            return sqlParams;
        }

        public List<EventInfo> Get_Events(ref PaginationInfo Pager)
        {
            List<EventInfo> events = new List<EventInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Event_Sp.ToString(), CommandType.StoredProcedure);
            //foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            //{
            //    events.Add(Get_Event_Values(dr));
            //}
            return events;
        }
        public EventInfo Get_Event_By_Id(int Event_Id)
        {
            EventInfo Event = new EventInfo();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Event_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                Event = Get_Event_Values(dr);
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
        public void Delete_Event_By_Id(int event_id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Event_Id", event_id));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Event_By_Id.ToString(), CommandType.StoredProcedure);
        }
    }
}
