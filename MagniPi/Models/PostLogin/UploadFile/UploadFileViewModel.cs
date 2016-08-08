using MagniPi.Common;
using MagniPiBusinessEntities.Attachment;
using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniPi.Models.PostLogin.UploadFile
{
    public class UploadFileViewModel
    {

        public UploadFileViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            attachment = new AttachmentsInfo();

            attachments = new List<AttachmentsInfo>();



        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public AttachmentsInfo attachment { get; set; }

        public List<AttachmentsInfo> attachments { get; set; }


    }
}