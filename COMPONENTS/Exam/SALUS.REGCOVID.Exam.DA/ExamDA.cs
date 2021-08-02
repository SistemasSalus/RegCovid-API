using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource.HelperDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Exam.DA
{
    public class ExamDA
    {
        Database _enterpriseLibDb;

        public ExamDA()
        {
            _enterpriseLibDb = new SqlDatabase(UtilDB.GetConnectionString());
        }

        public List<ValuesComponentResponse> GetValuesComponent(string serviceId, string componentId)
        {
            List<ValuesComponentResponse> oList = new List<ValuesComponentResponse>();
            string commandText = "[dbo].[REGCOVID_GET_VALUES_COMPONENT]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceId", DbType.String, serviceId);
                _enterpriseLibDb.AddInParameter(cmd, "@ComponentId", DbType.String, componentId);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<ValuesComponentResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public bool InsertValues(InsertValuesRequest oInsertValuesRequest)
        {
            string commandText = "[dbo].[usp_Insert_Valores]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                cmd.CommandTimeout = 2000;
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceComponentId", DbType.String, oInsertValuesRequest.ServiceComponentId);
                _enterpriseLibDb.AddInParameter(cmd, "@ComponentFieldId", DbType.String, oInsertValuesRequest.ComponentFieldId);
                _enterpriseLibDb.AddInParameter(cmd, "@Value1", DbType.String, oInsertValuesRequest.Value1);
                _enterpriseLibDb.AddInParameter(cmd, "@InsertUserId", DbType.Int32, oInsertValuesRequest.InsertUserId);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }

        public bool InsertValuesInBlock(List<InsertValuesRequest> oInsertValuesListRequest)
        {

            using (var connection = GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = "[dbo].[usp_Insert_Valores]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 20000;
                        command.Parameters.Add("@ServiceComponentId", SqlDbType.VarChar, 16);
                        command.Parameters.Add("@ComponentFieldId", SqlDbType.VarChar, 16);
                        command.Parameters.Add("@Value1", SqlDbType.VarChar, 1000);
                        command.Parameters.Add("@InsertUserId", SqlDbType.Int);
                        try
                        {
                            foreach (var item in oInsertValuesListRequest)
                            {
                                command.Parameters["@ServiceComponentId"].Value = item.ServiceComponentId;
                                command.Parameters["@ComponentFieldId"].Value = item.ComponentFieldId;
                                command.Parameters["@Value1"].Value = (object)item.Value1 ?? DBNull.Value;
                                command.Parameters["@InsertUserId"].Value = 11;
                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool UpdateValues(UpdateValuesRequest oUpdateValuesRequest)
        {
            string commandText = "[dbo].[usp_Actualizar_Valores]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                cmd.CommandTimeout = 2000;
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceComponentFieldValuesId", DbType.String, oUpdateValuesRequest.ServiceComponentFieldValuesId);
                _enterpriseLibDb.AddInParameter(cmd, "@Value1", DbType.String, oUpdateValuesRequest.Value1);
                _enterpriseLibDb.AddInParameter(cmd, "@UpdateUserId", DbType.Int32, oUpdateValuesRequest.UpdateUserId);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }

        public bool CulminateSurvey(string serviceComponentId)
        {
            string commandText = "[dbo].[usp_Culminar_Encuesta]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceComponentId", DbType.String, serviceComponentId);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }

        public bool CulminateLaboratory(string serviceComponentId)
        {
            string commandText = "[dbo].[usp_Culminar_Laboratorio]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceComponentId", DbType.String, serviceComponentId);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }

        public List<ValuesServiceResponse> GetValuesService(string serviceComponentId)
        {
            List<ValuesServiceResponse> oList = new List<ValuesServiceResponse>();
            string commandText = "[dbo].[usp_Get_ServiceComponentFieldValuesByServiceComponentId]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@ServiceComponentId", DbType.String, serviceComponentId);

                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oList = new Mapper().Map<ValuesServiceResponse>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oList.ToList();
        }

        public SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            return new SqlConnection(connectionString);
        }
    }
}
