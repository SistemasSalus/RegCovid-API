using SALUS.REGCOVID.Common.BL;
using SALUS.REGCOVID.Common.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class EmpresaPrincipalController : ApiController
    {
        [HttpGet]
        [Route("EmpresaPrincipal/{userId}")]
        public IHttpActionResult GetEmpresasPrincipales(int userId)
        {
            var empresaPrincipalBL = new EmpresaPrincipalBL();

            var empresasPrincipales = empresaPrincipalBL.GetEmpresasPrincipales(userId);

            return Ok(empresasPrincipales);
        }
    }
}