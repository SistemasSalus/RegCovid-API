using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class EmpresaEmpleadoraRequest
    {
        public string Nombre { get; set; }
    }

    public class EmpresaEmpleadoraResponse
    {
        public int EmpresaEmpleadoraId { get; set; }
        public string Nombre { get; set; }
    }


}
