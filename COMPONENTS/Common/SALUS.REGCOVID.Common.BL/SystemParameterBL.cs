using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class SystemParameterBL
    {
        private SystemParameterDA _systemParameterDA = null;

        public SystemParameterBL()
        {
            _systemParameterDA = new SystemParameterDA();
        }

        public List<SystemParameterResponse> GetParameters(SystemParameterRequest oSystemParameterRequest)
        {
            return _systemParameterDA.GetParameters(oSystemParameterRequest);
        }

    }
}
