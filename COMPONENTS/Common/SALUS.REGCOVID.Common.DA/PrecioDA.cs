using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SALUS.REGCOVID.Common.DA
{
    public class PrecioDA
    {
        Database _enterpriseLibDb;

        public PrecioDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<Precio> GetPrecios()
        {
            List<Precio> oListPrecio = new List<Precio>();

            string commandText = "[dbo].[REGCOVID_ServicesPivot]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oListPrecio = new Mapper().Map<Precio>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }
            return oListPrecio;
        }
    }
}
