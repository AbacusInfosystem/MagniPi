using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MagniPiBusinessEntities.Blog
{
    public class BlogInfo
    {
        public int Blog_Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Blog_Template { get; set; }

        public int Header_Image { get; set; }

        public string Alternative_Text { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

        //
        public int File_Type { get; set; }

        public string File_Type_Str
        {
            get
            {
                return ((FileType)File_Type).ToString();
            }
            set
            {
                value = File_Type_Str;
            }
        }

        public string Header_Image_Url { get; set; }
        //

    }

}
