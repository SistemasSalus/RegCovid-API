using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace SALUS.REGCOVID.Common.DA
{
    public class SystemParameterDA
    {
        Database _enterpriseLibDb;

        public SystemParameterDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<SystemParameterResponse> GetParameters(SystemParameterRequest oSystemParameterRequest)
        {
            List<SystemParameterResponse> oList = new List<SystemParameterResponse>();
            string commandText = "[dbo].[REGCOVID_Get_SystemParameters]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@GroupId", DbType.Int32, oSystemParameterRequest.GroupId);
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<SystemParameterResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

    }
}
