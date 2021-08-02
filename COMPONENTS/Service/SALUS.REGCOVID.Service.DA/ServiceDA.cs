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

namespace SALUS.REGCOVID.Service.DA
{
    public class ServiceDA
    {
        Database _enterpriseLibDb;

        public ServiceDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<ServiceResponse> GetServices(ServiceRequest oServiceRequest)
        {
            List<ServiceResponse> oList = new List<ServiceResponse>();
            string commandText = "[dbo].[REGCOVID_List_Services]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioStart", DbType.DateTime,DateTime.Parse(oServiceRequest.FechaServicio).Date);
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioEnd", DbType.DateTime, DateTime.Parse(oServiceRequest.FechaServicio).AddDays(1).Date);
                _enterpriseLibDb.AddInParameter(cmd, "@MedicalCenter", DbType.Int32, oServiceRequest.MedicalCenter);
                _enterpriseLibDb.AddInParameter(cmd, "@ComponentId", DbType.String, oServiceRequest.ComponentId == "null"?null: oServiceRequest.ComponentId);
                _enterpriseLibDb.AddInParameter(cmd, "@OrganizationId", DbType.String, oServiceRequest.OrganizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@NodeId", DbType.String, oServiceRequest.NodeId);
                _enterpriseLibDb.AddInParameter(cmd, "@UserName", DbType.String, oServiceRequest.UserName);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<ServiceResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public List<ServiceResponse> GetServicesForAdmin(ServiceRequestForAdmin oServiceRequest)
        {
            List<ServiceResponse> oList = new List<ServiceResponse>();
            string commandText = "[dbo].[REGCOVID_List_Services_ForAdmin]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioStart", DbType.DateTime, DateTime.Parse(oServiceRequest.FechaInicioServicio).Date);
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioEnd", DbType.DateTime, DateTime.Parse(oServiceRequest.FechaFinServicio).AddDays(1).Date);               
                _enterpriseLibDb.AddInParameter(cmd, "@NameOrDocument", DbType.String, oServiceRequest.NameOrDocument);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<ServiceResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public List<IndicadoresResponse> ServicesIndicators(string node, string dateService)
        {
            DateTime FechaServicioStart = DateTime.Parse(dateService);
            DateTime FechaServicioEnd = DateTime.Parse(dateService).AddDays(1);
            List<IndicadoresResponse> oList = new List<IndicadoresResponse>();
            string commandText = "[dbo].[REGCOVID_Indicadores]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@Node", DbType.String, node);
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioStart", DbType.DateTime, FechaServicioStart);
                _enterpriseLibDb.AddInParameter(cmd, "@FechaServicioEnd", DbType.DateTime, FechaServicioEnd);                 

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<IndicadoresResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public bool UpdateStatusToDeletedsService(string serviceId)
        {
            string commandText = "[dbo].[REGCOVID_EliminarServicioByServiceId]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceId", DbType.String, serviceId);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }




    }
}
