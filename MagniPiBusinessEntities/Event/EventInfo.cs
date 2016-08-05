using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Event
{
  
    public class EventInfo
    {
        public EventInfo()
        {
            Event_Dates = new List<EventDateInfo>();
        }

        public int Event_Id { get; set; }

        public string Event_Name { get; set; }

        public string Description { get; set; }

        public int Event_Type { get; set; }

        public string Location { get; set; }

        public int Attachment_Id { get; set; }

        public bool Is_Stoped { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        List<EventDateInfo> Event_Dates { get; set; }
    }

    public class EventDateInfo
    {
        public int Event_Date_Id { get; set; }

        public int Event_Id { get; set; }

        public DateTime Date { get; set; }

        public string Start_Time { get; set; }

        public string End_Time { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

    public class CustomerEventMappingInfo
    {
        public int Customer_Event_Mapping_Id { get; set; }

        public int Event_Id { get; set; }

        public int Customer_Id { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

    public class MemberEventMappingInfo
    {
        public int Member_Event_Mapping_Id { get; set; }

        public int Event_Id { get; set; }

        public int Member_Id { get; set; }

        public bool Is_Remind { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

    public class EventAttendanceInfo
    {
        public int Event_Attendance_Id { get; set; }

        public int Event_Id { get; set; }

        public int Member_Id { get; set; }

        public DateTime Date { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }


}
