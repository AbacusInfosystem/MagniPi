using MagniPi.Common;
using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.Event
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Event = new EventInfo();

            events = new List<EventInfo>();

            Filter = new Event_Filter();

            eventdates = new List<EventDate>();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public EventInfo Event { get; set; }

        public List<EventInfo> events { get; set; }

        public Event_Filter Filter { get; set; }

        public List<EventDate> eventdates { get; set; }

    }

    public class Event_Filter
    {
        public string Event_Name { get; set; }

        public string Month { get; set; }

    }


}