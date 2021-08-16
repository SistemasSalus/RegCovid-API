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
            List<Precio> oLoadDataPrecio = new List<Precio>();

            string commandText = "[dbo].[REGCOVID_SelectPrice]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                using (IDataReader drReader = _enterpriseLibDb.ExecuteReader(cmd))
                {
                    oLoadDataPrecio = new Mapper().Map<Precio>(((RefCountingDataReader)drReader).InnerReader as SqlDataReader);
                }
            }

            return oLoadDataPrecio;
        }

        public bool CreatePrecios(Precio precio)
        {
            string commandText = "[dbo].[REGCOVID_CreatePrice]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@organizationId", DbType.String, precio.organizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@locationId", DbType.String, precio.locationId);
                _enterpriseLibDb.AddInParameter(cmd, "@tipoPrueba", DbType.String, precio.tipoPrueba);
                _enterpriseLibDb.AddInParameter(cmd, "@lugarToma", DbType.Int32, precio.lugarTomaID);
                _enterpriseLibDb.AddInParameter(cmd, "@precio", DbType.Decimal, precio.precio);
                _enterpriseLibDb.AddInParameter(cmd, "@user", DbType.Int32, precio.insertUser);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }

        public bool UpdatePrecios(Precio precio)
        {
            string commandText = "[dbo].[REGCOVID_UpdatePrice]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@id", DbType.Int32, precio.id);
                _enterpriseLibDb.AddInParameter(cmd, "@organizationId", DbType.String, precio.organizationId);
                _enterpriseLibDb.AddInParameter(cmd, "@locationId", DbType.String, precio.locationId);
                _enterpriseLibDb.AddInParameter(cmd, "@tipoPrueba", DbType.String, precio.tipoPrueba);
                _enterpriseLibDb.AddInParameter(cmd, "@lugarToma", DbType.Int32, precio.lugarTomaID);
                _enterpriseLibDb.AddInParameter(cmd, "@precio", DbType.Decimal, precio.precio);
                _enterpriseLibDb.AddInParameter(cmd, "@user", DbType.Int32, precio.insertUser);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }
        public bool DeletePrecios(int id)
        {
            string commandText = "[dbo].[REGCOVID_DeletePrice]";

            using (DbCommand cmd = _enterpriseLibDb.GetStoredProcCommand(commandText))
            {
                _enterpriseLibDb.AddInParameter(cmd, "@id", DbType.Int32, id);

                _enterpriseLibDb.ExecuteNonQuery(cmd);

                return true;
            }
        }
    }
}
