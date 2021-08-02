using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.Resource.HelperDb
{
   public class UtilDB
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[Constants.CONEXION_NAME].ConnectionString;
        }
    }
}
