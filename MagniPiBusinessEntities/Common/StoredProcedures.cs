using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagniPiBusinessEntities.Common
{
    public enum StoredProcedures
    {

        #region Login

        sp_AuthenticateUser,

        #endregion

        #region Attachment

        Insert_Attachments_Sp,
        Get_Attachments_Sp,
        Get_Attachment_By_Id_Sp,
        Delete_Attachment_By_Id_Sp,
        
        Get_Attachments_By_File_Type_Sp,

        #endregion

        #region Blog

        Insert_Blog_Sp,
        Update_Blog_Sp,
        Get_Blogs_Sp,
        Get_Blog_By_Id_Sp,
        Delete_Blog_By_Id_Sp,
        Get_Blogs_By_Month_Sp,

        #endregion




        #region Event

        Insert_Event_Sp,
        Update_Event_Sp,
        Get_Event_Sp,
        Delete_Event_By_Id,

        #endregion


        
    }

}
