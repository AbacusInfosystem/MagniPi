using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Service;
using MagniPiDataAccess.Utilities;
using MagniPiRepo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Service
{
    public class ServiceRepo
    {

        SQLHelperRepo _sqlRepo;

        public ServiceRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public int Insert_Service(ServiceInfo service)
        {
            return Convert.ToInt32(_sqlRepo.ExecuteScalerObj(Set_Values_In_Service(service), StoredProcedures.Insert_Service_Sp.ToString(), CommandType.StoredProcedure));
        }

        public void Update_Service(ServiceInfo service)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Service(service), StoredProcedures.Update_Service_Sp.ToString(), CommandType.StoredProcedure);
        }

        private List<SqlParameter> Set_Values_In_Service(ServiceInfo service)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (service.Service_Id != 0)
            {
                sqlParams.Add(new SqlParameter("@Service_Id", service.Service_Id));
            }
            
            sqlParams.Add(new SqlParameter("@Title", service.Title));
            sqlParams.Add(new SqlParameter("@Service_Template", service.Service_Template));
            sqlParams.Add(new SqlParameter("@Header_Image", service.Header_Image));
            sqlParams.Add(new SqlParameter("@Alternative_Text", service.Alternative_Text));
            sqlParams.Add(new SqlParameter("@Is_Active", service.Is_Active));

            if(service.Service_Id == 0)
            {
                sqlParams.Add(new SqlParameter("@Created_By", service.Created_By));
                sqlParams.Add(new SqlParameter("@Created_On", service.Created_On));
            }
            
            sqlParams.Add(new SqlParameter("@Updated_By", service.Updated_By));
            sqlParams.Add(new SqlParameter("@Updated_On", service.Updated_On));

            return sqlParams;
        }

        public List<ServiceInfo> Get_Services(ref PaginationInfo Pager)
        {
            List<ServiceInfo> services = new List<ServiceInfo>();
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Services_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                services.Add(Get_Service_Values(dr));
            }
            return services;
        }

        public List<ServiceInfo> Get_Services_By_Service_Title(ref PaginationInfo Pager, string Service_Title)
        {
            List<ServiceInfo> services = new List<ServiceInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Service_Title", Service_Title));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Services_By_Sertice_Title_Sp.ToString(), CommandType.StoredProcedure);
            foreach (DataRow dr in CommonMethods.GetRows(dt, ref Pager))
            {
                services.Add(Get_Service_Values(dr));
            }
            return services;
        }

        public ServiceInfo Get_Service_By_Id(int Service_Id)
        {
            ServiceInfo service = new ServiceInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@Service_Id", Service_Id));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Service_By_Id_Sp.ToString(), CommandType.StoredProcedure);
            List<DataRow> drList = new List<DataRow>();
            drList = dt.AsEnumerable().ToList();
            foreach (DataRow dr in drList)
            {
                service = Get_Service_Values_By_Id(dr);
            }
            return service;
        }

        private ServiceInfo Get_Service_Values(DataRow dr)
        {
            ServiceInfo service = new ServiceInfo();

            service.Service_Id = Convert.ToInt32(dr["Service_Id"]);
            service.Title = Convert.ToString(dr["Title"]);
            service.Service_Template = Convert.ToString(dr["Service_Template"]);
            service.Header_Image = Convert.ToInt32(dr["Header_Image"]);
            service.Alternative_Text = Convert.ToString(dr["Alternative_Text"]);
            service.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            service.Created_By = Convert.ToInt32(dr["Created_By"]);
            service.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            service.Created_On = Convert.ToDateTime(dr["Created_On"]);
            service.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return service;
        }

        private ServiceInfo Get_Service_Values_By_Id(DataRow dr)
        {
            ServiceInfo service = new ServiceInfo();

            service.Service_Id = Convert.ToInt32(dr["Service_Id"]);
            service.Title = Convert.ToString(dr["Title"]);
            service.Service_Template = Convert.ToString(dr["Service_Template"]);
            service.Header_Image = Convert.ToInt32(dr["Header_Image"]);
            service.Alternative_Text = Convert.ToString(dr["Alternative_Text"]);
            service.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
            service.Created_By = Convert.ToInt32(dr["Created_By"]);
            service.Updated_By = Convert.ToInt32(dr["Updated_By"]);
            service.Created_On = Convert.ToDateTime(dr["Created_On"]);
            service.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            if (dr["File_Type"] != DBNull.Value)
            {
                service.File_Type = Convert.ToInt32(dr["File_Type"]);
            }
            if (dr["Unique_Id"] != DBNull.Value)
            {
                service.Header_Image_Url = Convert.ToString(dr["Unique_Id"]);
            }

            service.User_Name = Convert.ToString(dr["First_Name"]) + " " + Convert.ToString(dr["Last_Name"]);

            return service;
        }

       
    }

}
