using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Security.DA
{
    public class AuthorizationDA
    {
        Database _enterpriseLibDb;

        public AuthorizationDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public LoginResponse LoginUserCovid(LoginRequest oLoginRequest)
        {
            List<LoginResponse> oList = new List<LoginResponse>();
            string commandText = "[dbo].[usp_Authorization_Regcovid]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@NodeId", DbType.Int32, oLoginRequest.NodeId);
                _enterpriseLibDb.AddInParameter(cmd, "@UserName", DbType.String, oLoginRequest.UserName);
                _enterpriseLibDb.AddInParameter(cmd, "@Password", DbType.String, oLoginRequest.Password);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<LoginResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.FirstOrDefault();
        }
    }
}
