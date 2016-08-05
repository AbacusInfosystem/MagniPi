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

        public void Insert_Event(EventInfo Event)
        {
            _eventRepo.Insert_Event(Event);
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

        public void Delete_Event_By_Id(int Event_Id)
        {
            _eventRepo.Delete_Event_By_Id(Event_Id);
        }
    }
}
