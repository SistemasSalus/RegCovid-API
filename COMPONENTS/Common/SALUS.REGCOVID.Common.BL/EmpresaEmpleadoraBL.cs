using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class EmpresaEmpleadoraBL
    {
        private EmpresaEmpleadoraDA _EmpresaEmpleadoraDA = null;

        public EmpresaEmpleadoraBL()
        {
            _EmpresaEmpleadoraDA = new EmpresaEmpleadoraDA();
        }

        public List<EmpresaEmpleadoraResponse> GetEmpresaEmpleadoras(string filtroNombre)
        {
            if (filtroNombre == "null") filtroNombre = "";
            return _EmpresaEmpleadoraDA.GetEmpresaEmpleadoras(filtroNombre);
        }

        public bool InsertEmpresaEmpleadora(EmpresaEmpleadoraRequest oEmpresaEmpleadoraRequest)
        {
            return _EmpresaEmpleadoraDA.InsertEmpresaEmpleadora(oEmpresaEmpleadoraRequest);
        }

    }
}
