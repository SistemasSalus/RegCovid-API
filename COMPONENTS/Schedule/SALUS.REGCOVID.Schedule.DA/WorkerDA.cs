using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace SALUS.REGCOVID.Schedule.DA
{
    public class WorkerDA
    {
        Database _enterpriseLibDb;

        public WorkerDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }
        public List<WorkerDataResponse> GetDataWorker(WorkerDataRequest oHcActualizadoRequest)
        {
            List<WorkerDataResponse> oList = new List<WorkerDataResponse>();
            string commandText = "[dbo].[REGCOVID_Get_Worker_From_HCActualizado]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@Filtro", DbType.String, oHcActualizadoRequest.Filtro);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<WorkerDataResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }
    }
}
