using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Testimonial;
using MagniPiDataAccess.Utilities;
using MagniPiRepo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Testimonial
{
    public class TestimonialRepo
    {

        SQLHelperRepo _sqlRepo;

        public TestimonialRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Testimonial(TestimonialInfo testimonial)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Testimonial(testimonial), StoredProcedures.Insert_Testimonial_Sp.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Testimonial(TestimonialInfo testimonial)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Testimonial(testimonial), StoredProcedures.Update_Testimonial_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Testimonial(TestimonialInfo testimonial)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (testimonial.Testimonial_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Testimonial_Id", testimonial.Testimonial_Id));
            }
            
            sqlParams.Add(new SqlParameter("@Title", testimonial.Title));
            sqlParams.Add(new SqlParameter("@Content", testimonial.Content));
            sqlParams.Add(new SqlParameter("@Author_Image", testimonial.Author_Image));
            sqlParams.Add(new SqlParameter("@Author_Name", testimonial.Author_Name));
            sqlParams.Add(new SqlParameter("@Author_Designation", testimonial.Author_Designation));
            sqlParams.Add(new SqlParameter("@Is_Active", testimonial.Is_Active));

            if (testimonial.Testimonial_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", testimonial.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", testimonial.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", testimonial.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", testimonial.Updated_On));

            return sqlParams;
        }

        public List<TestimonialInfo> Get_Testimonials(ref PaginationInfo Pager)
        {
            List<TestimonialInfo> testimonials = new List<TestimonialInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Testimonials_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                //testimonials.Add(Get_Testimonial_Values(dr));
                testimonials.Add(Get_Testimonial_Values_By_Id(dr));
            }
            return testimonials;
        }

        public TestimonialInfo Get_Testimonial_By_Id(int Testimonial_Id)
        {
            TestimonialInfo testimonial = new TestimonialInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Testimonial_Id", Testimonial_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Testimonial_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                testimonial = Get_Testimonial_Values_By_Id(dr);
            }
            return testimonial;
        }

        private TestimonialInfo Get_Testimonial_Values(DataRow dr)
        {
            TestimonialInfo testimonial = new TestimonialInfo();

            testimonial.Testimonial_Id = Convert.ToInt32(dr["Testimonial_Id"]);
            testimonial.Title = Convert.ToString(dr["Title"]);
            testimonial.Content = Convert.ToString(dr["Content"]);
            testimonial.Author_Image = Convert.ToInt32(dr["Author_Image"]);
            testimonial.Author_Name = Convert.ToString(dr["Author_Name"]);
            testimonial.Author_Designation = Convert.ToString(dr["Author_Designation"]);
            testimonial.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            testimonial.Created_By = Convert.ToInt32(dr["Created_By"]);
            testimonial.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            testimonial.Created_On = Convert.ToDateTime(dr["Created_On"]);
            testimonial.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return testimonial;
        }

        private TestimonialInfo Get_Testimonial_Values_By_Id(DataRow dr)
        {
            TestimonialInfo testimonial = new TestimonialInfo();

            testimonial.Testimonial_Id = Convert.ToInt32(dr["Testimonial_Id"]);
            testimonial.Title = Convert.ToString(dr["Title"]);
            testimonial.Content = Convert.ToString(dr["Content"]);
            testimonial.Author_Image = Convert.ToInt32(dr["Author_Image"]);
            testimonial.Author_Name = Convert.ToString(dr["Author_Name"]);
            testimonial.Author_Designation = Convert.ToString(dr["Author_Designation"]);
            testimonial.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            testimonial.Created_By = Convert.ToInt32(dr["Created_By"]);
            testimonial.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            testimonial.Created_On = Convert.ToDateTime(dr["Created_On"]);
            testimonial.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            if (dr["File_Type"] != DBNull.Value)
            {
                testimonial.File_Type = Convert.ToInt32(dr["File_Type"]);
            }
            if (dr["Unique_Id"] != DBNull.Value)
            {
                testimonial.Author_Image_Url = Convert.ToString(dr["Unique_Id"]);
            }
           
            return testimonial;
        }
       

    }
}
