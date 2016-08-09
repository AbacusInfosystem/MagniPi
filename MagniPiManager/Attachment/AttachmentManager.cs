using MagniPiBusinessEntities.Attachment;
using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Attachment
{
    public class AttachmentManager
    {
        AttachmentRepo _attachmentsRepo;

        public AttachmentManager()
        {
            _attachmentsRepo = new AttachmentRepo();

        }

        public void Insert_Attachment(AttachmentsInfo attachment)
        {
            _attachmentsRepo.Insert_Attachment(attachment);
        }

        public List<AttachmentsInfo> Get_Attachments(ref PaginationInfo pager)
        {
            return _attachmentsRepo.Get_Attachments(ref pager);
        }

        public AttachmentsInfo Get_Attachment_By_Id(int Attachment_Id)
        {
            return _attachmentsRepo.Get_Attachment_By_Id(Attachment_Id);
        }

        public void Delete_Attachment_By_Id(int Attachment_Id)
        {
            _attachmentsRepo.Delete_Attachment_By_Id(Attachment_Id);
        }

        public List<AttachmentsInfo> Get_Attachment_By_Type(ref PaginationInfo pager, int File_Type)
        {
            return _attachmentsRepo.Get_Attachment_By_Type(ref pager, File_Type);
        }


    }
}
