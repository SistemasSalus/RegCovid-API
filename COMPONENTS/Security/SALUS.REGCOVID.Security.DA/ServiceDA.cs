using SALUS.REGCOVID.Common.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System.Data.SqlClient;

namespace SALUS.REGCOVID.Security.DA
{
    public class ServiceDA
    {
        Database _enterpriseLibDb;

        public ServiceDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        //public List<ServiceResponse> GetServices(ServiceRequest oServiceRequest)
        //{
        //    List<ServiceResponse> oList = new List<ServiceResponse>();
        //    string commandText = "[dbo].[REGCOVID_List_Services]";

        //    using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
        //    {
        //        _enterpriseLibDb.AddInParameter(cmd, "@FechaServicio", DbType.DateTime, oServiceRequest.FechaServicio);
        //        _enterpriseLibDb.AddInParameter(cmd, "@MedicalCenter", DbType.String, oServiceRequest.MedicalCenter);
        //        _enterpriseLibDb.AddInParameter(cmd, "@Status", DbType.Int32, oServiceRequest.Status);
        //        _enterpriseLibDb.AddInParameter(cmd, "@ComponentId", DbType.String, oServiceRequest.ComponentId);
        //        _enterpriseLibDb.AddInParameter(cmd, "@OrganizationId", DbType.String, oServiceRequest.OrganizationId);
        //        _enterpriseLibDb.AddInParameter(cmd, "@NodeId", DbType.String, oServiceRequest.NodeId);

        //        using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
        //        {
        //            oList = new Mapper().Map<ServiceResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
        //        }
        //    }

        //    return oList.ToList();
        //}

        //public List<ServiceResponse> GetServicesClinics(ServiceOtherClinicsRequest oServiceOtherClinicsRequest)
        //{
        //    List<ServiceResponse> oList = new List<ServiceResponse>();
        //    string commandText = "[dbo].[usp_GetRegisterWorkesClinics]";

        //    using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
        //    {
        //        _enterpriseLibDb.AddInParameter(cmd, "@OrganizationId", DbType.String, oServiceOtherClinicsRequest.OrganizationId);
        //        _enterpriseLibDb.AddInParameter(cmd, "@NodeId", DbType.String, oServiceOtherClinicsRequest.NodeId);
        //        _enterpriseLibDb.AddInParameter(cmd, "@Fecha", DbType.String, oServiceOtherClinicsRequest.Fecha);

        //        using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
        //        {
        //            oList = new Mapper().Map<ServiceResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
        //        }
        //    }

        //    return oList.ToList();
        //}        

        //public List<IndicadoresResponse> Indicadores(IndicadoresRequest oIndicadoresRequest)
        //{
        //    List<IndicadoresResponse> oList = new List<IndicadoresResponse>();
        //    string commandText = "[dbo].[usp_Get_Indicadores]";

        //    using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
        //    {
        //        _enterpriseLibDb.AddInParameter(cmd, "@Nodo", DbType.String, oIndicadoresRequest.Nodo);

        //        using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
        //        {
        //            oList = new Mapper().Map<IndicadoresResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
        //        }
        //    }

        //    return oList.ToList();
        //}

        //public List<WorkerDataResponse> GetDataWorker(WorkerDataRequest oHcActualizadoRequest)
        //{
        //    List<WorkerDataResponse> oList = new List<WorkerDataResponse>();
        //    string commandText = "[dbo].[usp_Get_HCActualizado]";

        //    using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
        //    {
        //        _enterpriseLibDb.AddInParameter(cmd, "@Filtro", DbType.String, oHcActualizadoRequest.Filtro);

        //        using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
        //        {
        //            oList = new Mapper().Map<WorkerDataResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
        //        }
        //    }

        //    return oList.ToList();
        //}

      
       
        
    }
}
