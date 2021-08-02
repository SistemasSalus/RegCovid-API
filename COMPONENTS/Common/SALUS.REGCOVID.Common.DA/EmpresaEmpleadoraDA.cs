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

namespace SALUS.REGCOVID.Common.DA
{
    public class EmpresaEmpleadoraDA
    {
        Database _enterpriseLibDb;

        public EmpresaEmpleadoraDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<EmpresaEmpleadoraResponse> GetEmpresaEmpleadoras(string filtroNombre)
        {
            List<EmpresaEmpleadoraResponse> oList = new List<EmpresaEmpleadoraResponse>();
            string commandText = "[dbo].[REGCOVID_Get_Empresas_Empleadoras]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@Filtro", DbType.String, filtroNombre);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<EmpresaEmpleadoraResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public bool InsertEmpresaEmpleadora(EmpresaEmpleadoraRequest oEmpresaEmpleadoraRequest)
        {
            string commandText = "[dbo].[REGCOVID_Insert_Empresas_Empleadoras]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                cmd.CommandTimeout = 2000;
                _enterpriseLibDb.AddInParameter(cmd, "@Nombre", DbType.String, oEmpresaEmpleadoraRequest.Nombre);                

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }


    }
}
