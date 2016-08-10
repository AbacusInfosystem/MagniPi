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

        #region Service

        Insert_Service_Sp,
        Update_Service_Sp,
        Get_Services_Sp,
        Get_Service_By_Id_Sp,
        Delete_Service_By_Id_Sp,
        Get_Services_By_Sertice_Title_Sp,

        #endregion

        #region Testimonial

        Insert_Testimonial_Sp,
        Update_Testimonial_Sp,
        Get_Testimonials_Sp,
        Get_Testimonial_By_Id_Sp,

        #endregion


        #region Event

        Insert_Event_Sp,
        Update_Event_Sp,
        Get_Event_Sp,
        Delete_Event_By_Id,

        #endregion


        
    }

}
