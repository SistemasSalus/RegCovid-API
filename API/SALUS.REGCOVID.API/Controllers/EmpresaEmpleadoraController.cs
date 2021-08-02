using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class EmpresaEmpleadoraController : ApiController
    {
        [HttpGet]
        [Route("EmpresaEmpleadora/{filtroNombre}")]
        public IHttpActionResult GetByFilter(string filtroNombre)
        {
            var empresaEmpleadoraBL = new EmpresaEmpleadoraBL();

            var empresasEmpleadoras = empresaEmpleadoraBL.GetEmpresaEmpleadoras(filtroNombre);

            return Ok(empresasEmpleadoras);
        }

        [HttpPost]
        [Route("EmpresaEmpleadora")]
        public IHttpActionResult AddEmpresaEmpleadora(EmpresaEmpleadoraRequest oEmpresaEmpleadoraRequest)
        {
            var oEmpresaEmpleadoraBL = new EmpresaEmpleadoraBL();

            var result = oEmpresaEmpleadoraBL.InsertEmpresaEmpleadora(oEmpresaEmpleadoraRequest);
            
            return Ok(result);
        }
    }
}
