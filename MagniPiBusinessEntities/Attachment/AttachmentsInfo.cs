using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Attachment
{
    public class AttachmentsInfo
    {
        public int Attachment_Id { get; set; }

        public string File_Name { get; set; }

        public string Unique_Id { get; set; }

        public int File_Type { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
