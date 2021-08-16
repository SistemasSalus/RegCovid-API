using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class EmpresaPrincipalBL
    {
        private EmpresaPrincipalDA _EmpresaPrincipalDA = null;

        public EmpresaPrincipalBL()
        {
            _EmpresaPrincipalDA = new EmpresaPrincipalDA();
        }

        public List<EmpresaPrincipal> GetEmpresasPrincipales(int userId)
        {
            return _EmpresaPrincipalDA.GetEmpresasPrincipales(userId);
        }
        public List<EmpresaPrincipal> GetEmpresas()
        {
            return _EmpresaPrincipalDA.GetEmpresas();
        }
    }
}
