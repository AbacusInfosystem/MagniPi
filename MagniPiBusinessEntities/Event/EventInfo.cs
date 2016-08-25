using MagniPiBusinessEntities.Common;
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

            event_date = new EventDateInfo();

            customer_event_mapping = new CustomerEventMappingInfo();

            customer_event_mappings = new List<CustomerEventMappingInfo>();

            member_event_mappings = new List<MemberEventMappingInfo>();

            member_event_mapping = new MemberEventMappingInfo();

            event_attendance = new EventAttendanceInfo();

            event_attendances = new List<EventAttendanceInfo>();

            eventdates = new List<EventDate>();

        }

        public int Event_Id { get; set; }

        public string Event_Name { get; set; }

        public string Description { get; set; }

        public int Event_Type { get; set; }

        public string Event_Type_Str
        {
            get
            {
                return ((EventType)Event_Type).ToString();
            }
            set
            {
                value = Event_Type_Str;
            }
        }

        public string Location { get; set; }

        public int Attachment_Id { get; set; }

        public bool Is_Stoped { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        public List<EventDateInfo> Event_Dates { get; set; }

        public EventDateInfo event_date { get; set; }

        //
        public string Attachment_Url { get; set; }

        public int Attachment_Type { get; set; }

        public string Attachment_Type_Str
        {
            get
            {
                return ((FileType)Attachment_Type).ToString();
            }
            set
            {
                value = Attachment_Type_Str;
            }
        }
        //

        public CustomerEventMappingInfo customer_event_mapping { get; set; }

        public List<CustomerEventMappingInfo> customer_event_mappings { get; set; }

        public List<MemberEventMappingInfo> member_event_mappings { get; set; }

        public MemberEventMappingInfo member_event_mapping { get; set; }

        public EventAttendanceInfo event_attendance { get; set; }

        public List<EventAttendanceInfo> event_attendances { get; set; }

        public List<EventDate> eventdates { get; set; }

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

        public string Customer_Name { get; set; }

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

        public string Member_Name { get; set; }

        public string Contact { get; set; }

        public bool Is_Remind { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        public bool Flag_Checked { get; set; }
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

        public int Customer_Id { get; set; }

        public string Member_Name { get; set; }

        public bool Flag { get; set; }


    }

    public class EventDate
    {
        public DateTime Day { get; set; }
    }

}
