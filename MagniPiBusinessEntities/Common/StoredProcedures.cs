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

        #region Testimonial

        Update_About_Us_Sp,
        Get_About_Us_By_Id_Sp,

        #endregion

        #region Customer

        Insert_Customer_Sp,
        Update_Customer_Sp,
        Get_Customers_Sp,
        Get_Customer_By_Id_Sp,
        Get_Customers_By_Customer_Name_And_Contact_Sp,
        Get_Customers_By_Customer_Name_Sp,
        Get_Customers_By_Contact_Sp,
        Get_Customer_By_Name_Autocomplete_Sp,

        #region Member

        Insert_Member_Sp,
        Update_Member_Sp,
        Get_Member_Customer_By_Id_Sp,
        Get_Member_By_Id_Sp,

        #endregion

        #region Event

        Get_Event_By_Customer_Id_Sp,

        #endregion

        #endregion

        #region Event

        Insert_Event_Sp,
        Update_Event_Sp,
        Get_Events_Sp,
        Get_Event_By_Id_Sp,
        Get_Events_By_Event_Name_And_Month_Sp,
        Get_Events_By_Event_Name_Sp,
        Get_Events_By_Month_Sp,
        Get_Up_Comming_Events_Sp,

        #region Event Date

        Get_Event_Dates_By_Event_Id_Sp,
        Insert_Event_Date_Sp,
        Update_Event_Date_Sp,
        Get_Event_Date_By_Id_Sp,

        #endregion

        #region Event Subscriber

        Get_Event_By_Name_Autocomplete_Sp,
        Get_Customer_Autocomplete_Sp,
        Insert_Customer_Event_Mapping_Sp,
        Get_Event_Customers_By_Event_Id_Sp,
        Get_Event_Members_Sp,
        Insert_Member_Event_Mapping_Sp,
        Update_Member_Event_Mapping_Sp,
        Delete_Member_Event_Mapping_By_Id_Sp,
        Delete_Customer_Event_Mapping_By_Id_Sp,

        #endregion

        #region Event Attendance

        Get_Event_Member_Attendance_Sp,
        Get_Event_Dates_Sp,
        Insert_Event_Attendance_Sp,
        Update_Event_Attendance_Sp,
        Delete_Event_Attendance_By_Id_Sp,

        #endregion

        #endregion



    }

}
