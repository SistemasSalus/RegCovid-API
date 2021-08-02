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
    public class NodesRegCovidDA
    {
        Database _enterpriseLibDb;

        public NodesRegCovidDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<NodeRegcovidResponse> GetNodesRegcovid()
        {
            List<NodeRegcovidResponse> oList = new List<NodeRegcovidResponse>();
            string commandText = "[dbo].[REGCOVID_Get_Nodes]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<NodeRegcovidResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }
    }
}
