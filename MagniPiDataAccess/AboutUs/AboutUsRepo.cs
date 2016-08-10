using MagniPiBusinessEntities.AboutUs;
using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.AboutUs
{
    public class AboutUsRepo
    {
        SQLHelperRepo _sqlRepo;

        public AboutUsRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public void Update_About_Us(AboutUsInfo aboutus)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_About_Us(aboutus), StoredProcedures.Update_About_Us_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_About_Us(AboutUsInfo aboutus)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@About_Us_Id", aboutus.About_Us_Id));
            sqlParams.Add(new SqlParameter("@About_Us_Template", aboutus.About_Us_Template));
            sqlParams.Add(new SqlParameter("@Header_Image", aboutus.Header_Image));
            sqlParams.Add(new SqlParameter("@Alternative_Text", aboutus.Alternative_Text));
            sqlParams.Add(new SqlParameter("@Is_Active", aboutus.Is_Active));
            sqlParams.Add(new SqlParameter("@Updated_By", aboutus.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", aboutus.Updated_On));

            return sqlParams;
        }

        public AboutUsInfo Get_About_Us_By_Id(int About_Us_Id)
        {
            AboutUsInfo aboutus = new AboutUsInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@About_Us_Id", About_Us_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_About_Us_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                aboutus = Get_About_Us_Values(dr);
            }
            return aboutus;
        }

        private AboutUsInfo Get_About_Us_Values(DataRow dr)
        {
            AboutUsInfo aboutus = new AboutUsInfo();

            aboutus.About_Us_Id = Convert.ToInt32(dr["About_Us_Id"]);
            aboutus.About_Us_Template = Convert.ToString(dr["About_Us_Template"]);
            aboutus.Header_Image = Convert.ToInt32(dr["Header_Image"]);
            aboutus.Alternative_Text = Convert.ToString(dr["Alternative_Text"]);
            aboutus.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            aboutus.Created_By = Convert.ToInt32(dr["Created_By"]);
            aboutus.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            aboutus.Created_On = Convert.ToDateTime(dr["Created_On"]);
            aboutus.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            if (dr["File_Type"] != DBNull.Value)
            {
                aboutus.File_Type = Convert.ToInt32(dr["File_Type"]);
            }
            if (dr["Unique_Id"] != DBNull.Value)
            {
                aboutus.Header_Image_Url = Convert.ToString(dr["Unique_Id"]);
            }

            return aboutus;
        }


    }
}
