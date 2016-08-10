using MagniPiBusinessEntities.Blog;
using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Utilities;
using MagniPiRepo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Blog
{
    public class BlogRepo
    {

        SQLHelperRepo _sqlRepo;

        public BlogRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Blog(BlogInfo blog)
        {
            //_sqlRepo.ExecuteNonQuery(Set_Values_In_Blog(blog), StoredProcedures.Insert_Blog_Sp.ToString(), CommandType.StoredProcedure);
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Blog(blog), StoredProcedures.Insert_Blog_Sp.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Blog(BlogInfo blog)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Blog(blog), StoredProcedures.Update_Blog_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Blog(BlogInfo blog)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (blog.Blog_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Blog_Id", blog.Blog_Id));
            }
            sqlParams.Add(new SqlParameter("@Title", blog.Title));
            sqlParams.Add(new SqlParameter("@Blog_Template", blog.Blog_Template));
            sqlParams.Add(new SqlParameter("@Header_Image", blog.Header_Image));
            sqlParams.Add(new SqlParameter("@Alternative_Text", blog.Alternative_Text));
            sqlParams.Add(new SqlParameter("@Is_Active", blog.Is_Active));

            if (blog.Blog_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", blog.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", blog.Created_On));
            }

            sqlParams.Add(new SqlParameter("@Updated_By", blog.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", blog.Updated_On));

            return sqlParams;
        }

        public List<BlogInfo> Get_Blogs(ref PaginationInfo Pager)
        {
            List<BlogInfo> blogs = new List<BlogInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Blogs_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                blogs.Add(Get_Blog_Values(dr));
            }
            return blogs;
        }

        public List<BlogInfo> Get_Blogs_By_Month(ref PaginationInfo Pager, string Month)
        {
            List<BlogInfo> blogs = new List<BlogInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Month", Month.Substring(0, 2)));
            sqlParams.Add(new SqlParameter("@Year", Month.Substring(Month.LastIndexOf('-') + 1)));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Blogs_By_Month_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                blogs.Add(Get_Blog_Values(dr));
            }
            return blogs;
        }

        public BlogInfo Get_Blog_By_Id(int Blog_Id)
        {
            BlogInfo blog = new BlogInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Blog_Id", Blog_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Blog_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                blog = Get_Blog_Values_By_Id(dr);
            }
            return blog;
        }

        private BlogInfo Get_Blog_Values(DataRow dr)
        {
            BlogInfo blog = new BlogInfo();

            blog.Blog_Id = Convert.ToInt32(dr["Blog_Id"]);
            blog.Title = Convert.ToString(dr["Title"]);
            blog.Blog_Template = Convert.ToString(dr["Blog_Template"]);
            blog.Header_Image = Convert.ToInt32(dr["Header_Image"]);
            blog.Alternative_Text = Convert.ToString(dr["Alternative_Text"]);
            blog.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            blog.Created_By = Convert.ToInt32(dr["Created_By"]);
            blog.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            blog.Created_On = Convert.ToDateTime(dr["Created_On"]);
            blog.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return blog;
        }

        private BlogInfo Get_Blog_Values_By_Id(DataRow dr)
        {
            BlogInfo blog = new BlogInfo();

            blog.Blog_Id = Convert.ToInt32(dr["Blog_Id"]);
            blog.Title = Convert.ToString(dr["Title"]);
            blog.Blog_Template = Convert.ToString(dr["Blog_Template"]);
            blog.Header_Image = Convert.ToInt32(dr["Header_Image"]);
            blog.Alternative_Text = Convert.ToString(dr["Alternative_Text"]);
            blog.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            blog.Created_By = Convert.ToInt32(dr["Created_By"]);
            blog.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            blog.Created_On = Convert.ToDateTime(dr["Created_On"]);
            blog.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            if (dr["File_Type"] != DBNull.Value)
            {
                blog.File_Type = Convert.ToInt32(dr["File_Type"]);
            }
            if (dr["Unique_Id"] != DBNull.Value)
            {
                blog.Header_Image_Url = Convert.ToString(dr["Unique_Id"]);
            }

            blog.User_Name = Convert.ToString(dr["First_Name"]) + " " + Convert.ToString(dr["Last_Name"]);

            return blog;
        }

        //public void Delete_Blog_By_Id(int blog_id)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    sqlParams.Add(new SqlParameter("@Blog_Id", blog_id));
        //    _sqlRepo.ExecuteNonQuery(sqlParams, StoredProcedures.Delete_Blog_By_Id_Sp.ToString(), CommandType.StoredProcedure);
        //}

    }
}
