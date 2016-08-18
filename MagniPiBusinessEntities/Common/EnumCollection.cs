using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniPiBusinessEntities.Common
{

    public enum MessageType
    {
        Information = 1,
        Error = 2,
        Success = 3,
        Warning = 4,
    }

    public enum FileType
    {
        Image = 1,
        Video = 2,

    }

    public enum EventType
    {
        Conferences = 1,
        Seminars = 2,
        Meetings = 3,
        VIP_Events = 4,
        Award_Ceremonies = 5,
        Opening_Ceremonies = 6,
        Product_Launches = 7,
        Parties = 8,
        Press_Conferences = 9,
        Other = 10,

    }


}
