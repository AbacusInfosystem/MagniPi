using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagniPiDataAccess.Authentication
{
    public class AuthenticationRepo
    {
        SQLHelperRepo _sqlRepo;

        public AuthenticationRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public SessionInfo AuthernticateLogin(SessionInfo session)
        {
            SessionInfo user = new SessionInfo();

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@User_Name", session.User_Name));

            sqlParam.Add(new SqlParameter("@Password", session.Password));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParam, StoredProcedures.sp_AuthenticateUser.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.AsEnumerable().FirstOrDefault();

                if (dr != null)
                {
                    user.User_Id = Convert.ToInt32(dr["User_Id"]);

                    user.First_Name = Convert.ToString(dr["First_Name"]);

                    user.Last_Name = Convert.ToString(dr["Last_Name"]);

                    user.Contact = Convert.ToString(dr["Contact"]);

                    user.Email = Convert.ToString(dr["Email"]);

                    user.Address = Convert.ToString(dr["Address"]);

                    user.Gender = Convert.ToString(dr["Gender"]);

                    user.User_Name = Convert.ToString(dr["User_Name"]);

                    user.Image = Convert.ToString(dr["Image"]);

                    if (dr["Is_Active"] != DBNull.Value)
                    {
                        user.Is_Active = Convert.ToBoolean(dr["Is_Active"]);
                    }

                    user.Created_On = Convert.ToDateTime(dr["Created_On"]);

                    user.Created_By = Convert.ToInt32(dr["Created_By"]);

                    user.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

                    user.Updated_By = Convert.ToInt32(dr["Updated_By"]);

                }
            }

            return user;
        }



    }
}
