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
    public class OthersMedicalCentersController : ApiController
    {
        [HttpGet]
        [Route("OthersMedicalCenters")]
        public IHttpActionResult GetAll()
        {
            var oSystemParameterBL = new SystemParameterBL();

            var otherMedicalCenters = oSystemParameterBL.GetParameters(new SystemParameterRequest { GroupId = 280 });

            return Ok(otherMedicalCenters);
        }
    }
}
