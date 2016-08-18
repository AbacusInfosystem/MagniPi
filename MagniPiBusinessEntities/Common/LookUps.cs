using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Common
{
    public static class LookUps
    {
        public static Dictionary<int, string> Get_File_Type()
        {
            Dictionary<int, string> file_Type = new Dictionary<int, string>();

            file_Type.Add(1, FileType.Image.ToString());
            file_Type.Add(2, FileType.Video.ToString());

            return file_Type;
        }

        public static Dictionary<int, string> Get_Event_Type()
        {
            Dictionary<int, string> event_Type = new Dictionary<int, string>();

            event_Type.Add(1, EventType.Conferences.ToString());
            event_Type.Add(2, EventType.Seminars.ToString());
            event_Type.Add(3, EventType.Meetings.ToString());
            event_Type.Add(4, EventType.VIP_Events.ToString());
            event_Type.Add(5, EventType.Award_Ceremonies.ToString());
            event_Type.Add(6, EventType.Opening_Ceremonies.ToString());
            event_Type.Add(7, EventType.Product_Launches.ToString());
            event_Type.Add(8, EventType.Parties.ToString());
            event_Type.Add(9, EventType.Press_Conferences.ToString());
            event_Type.Add(10, EventType.Other.ToString());

            return event_Type;
        }



    }
}
