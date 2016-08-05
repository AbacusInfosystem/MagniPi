using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Feedback
{
    public class FeedbackInfo
    {
        public int Feedback_Id { get; set; }

        public int Event_Id { get; set; }

        public int Member_Id { get; set; }

        public string Feedback { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
