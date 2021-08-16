using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;

namespace SALUS.REGCOVID.Common.DA
{
    public class EmpresaPrincipalDA
    {
        Database _enterpriseLibDb;

        public EmpresaPrincipalDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<EmpresaPrincipal> GetEmpresasPrincipales(int userId)
        {
            List<EmpresaPrincipal> oList = new List<EmpresaPrincipal>();
            string commandText = "[dbo].[REGCOVID_sp_GetEmpresasPrincipales]";
            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@userId", DbType.Int32, userId);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<EmpresaPrincipal>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();

        }
        public List<EmpresaPrincipal> GetEmpresas()
        {
            List<EmpresaPrincipal> oList = new List<EmpresaPrincipal>();
            string commandText = "[dbo].[REGCOVID_Get_Organization]";
            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<EmpresaPrincipal>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();

        }
    }
}
