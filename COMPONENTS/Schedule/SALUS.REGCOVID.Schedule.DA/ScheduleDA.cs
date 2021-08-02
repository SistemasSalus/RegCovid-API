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

namespace SALUS.REGCOVID.Schedule.DA
{
    public class ScheduleDA
    {
        Database _enterpriseLibDb;

        public ScheduleDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public string ScheduleWorkerRegCovid(ScheduleRegcovidRequest oScheduleRegcovidRequest, string protocolId)
        {
            string commandText = "[dbo].[REGCOVID_ScheduleWorker]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                cmd.CommandTimeout = 0;
                _enterpriseLibDb.AddInParameter(cmd, "@NodeId", DbType.Int32, oScheduleRegcovidRequest.NodeId);
                _enterpriseLibDb.AddInParameter(cmd, "@OrganizationId", DbType.String, oScheduleRegcovidRequest.OrganizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@EmpresaPrincipal", DbType.String, oScheduleRegcovidRequest.OrganizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@SedeId", DbType.Int32, oScheduleRegcovidRequest.SedeId);
                _enterpriseLibDb.AddInParameter(cmd, "@ProtocoloId", DbType.String, protocolId);
                _enterpriseLibDb.AddInParameter(cmd, "@FirstName", DbType.String, oScheduleRegcovidRequest.FirstName);
                _enterpriseLibDb.AddInParameter(cmd, "@FirstLastName", DbType.String, oScheduleRegcovidRequest.FirstLastName);
                _enterpriseLibDb.AddInParameter(cmd, "@SecondLastName", DbType.String, oScheduleRegcovidRequest.SecondLastName);
                _enterpriseLibDb.AddInParameter(cmd, "@DocTypeId", DbType.Int32, oScheduleRegcovidRequest.DocTypeId);
                _enterpriseLibDb.AddInParameter(cmd, "@DocNumber", DbType.String, oScheduleRegcovidRequest.DocNumber);
                _enterpriseLibDb.AddInParameter(cmd, "@SexTypeId", DbType.Int32, oScheduleRegcovidRequest.SexTypeId);
                _enterpriseLibDb.AddInParameter(cmd, "@Birthdate", DbType.DateTime, oScheduleRegcovidRequest.Birthdate);
                _enterpriseLibDb.AddInParameter(cmd, "@Mail", DbType.String, oScheduleRegcovidRequest.Mail);
                _enterpriseLibDb.AddInParameter(cmd, "@TelephoneNumber", DbType.String, oScheduleRegcovidRequest.TelephoneNumber);
                _enterpriseLibDb.AddInParameter(cmd, "@CurrentOccupation", DbType.String, oScheduleRegcovidRequest.CurrentOccupation);
                _enterpriseLibDb.AddInParameter(cmd, "@AdressLocation", DbType.String, oScheduleRegcovidRequest.AdressLocation);
                _enterpriseLibDb.AddInParameter(cmd, "@NombreSede", DbType.String, oScheduleRegcovidRequest.NombreSede);
                _enterpriseLibDb.AddInParameter(cmd, "@TipoEmpresaCovidId", DbType.Int32, oScheduleRegcovidRequest.TipoEmpresaCovidId);
                _enterpriseLibDb.AddInParameter(cmd, "@UserId", DbType.Int32, oScheduleRegcovidRequest.UserId);
                _enterpriseLibDb.AddInParameter(cmd, "@Tecnico", DbType.String, oScheduleRegcovidRequest.Tecnico);
                _enterpriseLibDb.AddInParameter(cmd, "@ClinicaExternad", DbType.Int32, oScheduleRegcovidRequest.ClinicaExternad);
                _enterpriseLibDb.AddInParameter(cmd, "@FechaExamen", DbType.DateTime, oScheduleRegcovidRequest.FechaExamen);
                _enterpriseLibDb.AddInParameter(cmd, "@EmpresaEmpleadora", DbType.String, oScheduleRegcovidRequest.EmpresaEmpleadora);
                _enterpriseLibDb.AddInParameter(cmd, "@ReasonExamId", DbType.Int32, oScheduleRegcovidRequest.ReasonExamId);
                _enterpriseLibDb.AddInParameter(cmd, "@PlaceExamId", DbType.Int32, oScheduleRegcovidRequest.PlaceExamId);
                _enterpriseLibDb.AddOutParameter(cmd, "@ServiceId", DbType.String, 16);
                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return Convert.ToString(_enterpriseLibDb.GetParameterValue(cmd, "@ServiceId"));
            }

        }
        public OrganizationFact GetOrganizationFact(int userId)
        {
            List<OrganizationFact> list =new List<OrganizationFact>();
            string commandText = "[dbo].[REGCOVID_Get_OrganizationFactId]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@userID", DbType.Int32, userId);
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    list = new Mapper().Map<OrganizationFact>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return list[0];
        }
        public ProtocolResponse GetProtocolIdForSchedule(string organizationId, string componentId)
        {
            List<ProtocolResponse> oList = new List<ProtocolResponse>();
            string commandText = "[dbo].[REGCOVID_Get_ProtocolId]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@OrganizationId", DbType.String, organizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@ComponentId", DbType.String, componentId);
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<ProtocolResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList().FirstOrDefault();
        }
    }
}
