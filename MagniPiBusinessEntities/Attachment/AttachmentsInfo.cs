using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MagniPiBusinessEntities.Attachment
{
    public class AttachmentsInfo
    {
        public int Attachment_Id { get; set; }

        public string File_Name { get; set; }

        public string Unique_Id { get; set; }

        public int File_Type { get; set; }

        public string File_Type_Str { 
            get
            {
                return ((FileType)File_Type).ToString();
            }
            set
            {
                value = File_Type_Str;
            }
        }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        public HttpPostedFileBase[] Upload_Image { get; set; } 


    }

}
