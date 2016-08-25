using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagniPiBusinessEntities.Event;
using MagniPiDataAccess.Event;
using MagniPiBusinessEntities.Common;

namespace MagniPiManager.Event
{
    public class EventManager
    {

        EventRepo _eventRepo;

        public EventManager()
        {
            _eventRepo = new EventRepo();
        }

        public int Insert_Event(EventInfo Event)
        {
            return _eventRepo.Insert_Event(Event);
        }

        public void Update_Event(EventInfo Event)
        {
            _eventRepo.Update_Event(Event);
        }

        public List<EventInfo> Get_Events(ref PaginationInfo Pager)
        {
            return _eventRepo.Get_Events(ref Pager);
        }

        public EventInfo Get_Event_By_Id(int Event_Id)
        {
            return _eventRepo.Get_Event_By_Id(Event_Id);
        }

        public List<EventDateInfo> Get_Event_Date_By_Event_Id(ref PaginationInfo Pager, int Event_Id)
        {
            return _eventRepo.Get_Event_Date_By_Event_Id(ref Pager, Event_Id);
        }

        public void Insert_Event_Date(EventDateInfo eventdate)
        {
            _eventRepo.Insert_Event_Date(eventdate);
        }

        public void Update_Event_Date(EventDateInfo eventdate)
        {
            _eventRepo.Update_Event_Date(eventdate);
        }

        public EventDateInfo Get_Event_Date_By_Id(int Event_Date_Id)
        {
            return _eventRepo.Get_Event_Date_By_Id(Event_Date_Id);
        }

        public List<EventInfo> Get_Events_By_Event_Name_And_Month(ref PaginationInfo Pager, string Event_Name, string Month)
        {
            return _eventRepo.Get_Events_By_Event_Name_And_Month(ref Pager, Event_Name, Month);
        }

        public List<EventInfo> Get_Events_By_Event_Name(ref PaginationInfo Pager, string Event_Name)
        {
            return _eventRepo.Get_Events_By_Event_Name(ref Pager, Event_Name);
        }

        public List<EventInfo> Get_Events_By_Month(ref PaginationInfo Pager, string Month)
        {
            return _eventRepo.Get_Events_By_Month(ref Pager, Month);
        }

        public List<AutocompleteInfo> Get_Event_By_Name_Autocomplete(string Event_Name)
        {
            return _eventRepo.Get_Event_By_Name_Autocomplete(Event_Name);
        }

        public List<AutocompleteInfo> Get_Customer_By_Name_Autocomplete(string Customer_Name, int Event_Id)
        {
            return _eventRepo.Get_Customer_By_Name_Autocomplete(Customer_Name, Event_Id);
        }

        public void Insert_Customer_Event_Mapping(CustomerEventMappingInfo customereventmapping)
        {
            _eventRepo.Insert_Customer_Event_Mapping(customereventmapping);
        }

        public List<CustomerEventMappingInfo> Get_Event_Customers_By_Event_Id(int Event_Id)
        {
            return _eventRepo.Get_Event_Customers_By_Event_Id(Event_Id);
        }

        public List<MemberEventMappingInfo> Get_Event_Members(ref PaginationInfo pager, int Event_Id, int Customer_Id)
        {
            return _eventRepo.Get_Event_Members(ref pager, Event_Id, Customer_Id);
        }

        public void Save_Event_Members(List<MemberEventMappingInfo> member_event_mappings)
        {
            _eventRepo.Save_Event_Members(member_event_mappings);
        }

        public List<EventAttendanceInfo> Get_Event_Member_Attendance(ref PaginationInfo pager, int Event_Id, int Customer_Id, DateTime Date)
        {
            return _eventRepo.Get_Event_Member_Attendance(ref pager, Event_Id, Customer_Id, Date);
        }

        public List<EventDate> Get_Event_Dates(int Event_Id)
        {
            return _eventRepo.Get_Event_Dates(Event_Id);
        }

        public void Save_Event_Attendance(List<EventAttendanceInfo> eventattendances)
        {
            _eventRepo.Save_Event_Attendance(eventattendances);
        }

        public void Detete_Customer_Event_By_Id(int customer_Event_Mapping_Id)
        {
            _eventRepo.Detete_Customer_Event_By_Id(customer_Event_Mapping_Id);
        }

        public List<EventInfo> Get_Up_Comming_Events(ref PaginationInfo pager)
        {
            return _eventRepo.Get_Up_Comming_Events(ref pager);
        }

    }
}
