using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Worker
{
    public class MemberEventInfo
    {
        public int Member_Id { get; set; }

        public string Member_Name { get; set; }

        public string Email { get; set; }
        //
        public int Member_Event_Mapping_Id { get; set; }
        //
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

    }
}
