using MagniPiBusinessEntities.Attachment;
using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Utilities;
using MagniPiRepo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Attachment
{
    public class AttachmentRepo
    {
        SQLHelperRepo _sqlRepo;

        public AttachmentRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public void Insert_Attachment(AttachmentsInfo attachment)
        {

            _sqlRepo.ExecuteNonQuery(Set_Values_In_Attachments(attachment), StoredProcedures.Insert_Attachments_Sp.ToString(), CommandType.StoredProcedure);

        }

        private List<SqlParameter> Set_Values_In_Attachments(AttachmentsInfo attachment)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            //sqlParams.Add(new SqlParameter("@Attachment_Id", attachments.Attachment_Id));
            sqlParams.Add(new SqlParameter("@File_Name", attachment.File_Name));
            sqlParams.Add(new SqlParameter("@Unique_Id", attachment.Unique_Id));
            sqlParams.Add(new SqlParameter("@File_Type", attachment.File_Type));
            sqlParams.Add(new SqlParameter("@Is_Active", attachment.Is_Active));
            sqlParams.Add(new SqlParameter("@Created_By", attachment.Created_By));
            sqlParams.Add(new SqlParameter("@Updated_By", attachment.Updated_By));
            sqlParams.Add(new SqlParameter("@Created_On", attachment.Created_On));
            sqlParams.Add(new SqlParameter("@Updated_On", attachment.Updated_On));

            return sqlParams;
        }

        public List<AttachmentsInfo> Get_Attachments(ref PaginationInfo pager)
        {
            List<AttachmentsInfo> attachmentss = new List<AttachmentsInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Attachments_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt,ref pager))
            {
                attachmentss.Add(Get_Attachments_Values(dr));
            }
            return attachmentss;
        }

        private AttachmentsInfo Get_Attachments_Values(DataRow dr)
        {
            AttachmentsInfo attachments = new AttachmentsInfo();

            attachments.Attachment_Id = Convert.ToInt32(dr["Attachment_Id"]);
            attachments.File_Name = Convert.ToString(dr["File_Name"]);
            attachments.Unique_Id = Convert.ToString(dr["Unique_Id"]);
            attachments.File_Type = Convert.ToInt32(dr["File_Type"]);
            attachments.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            attachments.Created_By = Convert.ToInt32(dr["Created_By"]);
            attachments.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            attachments.Created_On = Convert.ToDateTime(dr["Created_On"]);
            attachments.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return attachments;
        }

        public AttachmentsInfo Get_Attachment_By_Id(int Attachment_Id)
        {
            AttachmentsInfo attachment = new AttachmentsInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Attachment_Id", Attachment_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attachment_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                attachment = Get_Attachments_Values(dr);
            }
            return attachment;
        }


        public void Delete_Attachment_By_Id(int Attachment_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Attachment_Id", Attachment_Id));
            _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Attachment_By_Id_Sp.ToString(), CommandType.StoredProcedure);
        }




    }
}
