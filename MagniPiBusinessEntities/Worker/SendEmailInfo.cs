using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Worker
{
    public class SendEmailInfo
    {

        public int ID { get; set; }

        public string To_Email_Id { get; set; }

        public string CC_Email_Id { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

    }
}
