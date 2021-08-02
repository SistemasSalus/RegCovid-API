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
    public class SystemParameterController : ApiController
    {

        [HttpGet]
        [Route("SystemParameter/{groupId}")]
        public IHttpActionResult Nodes(int groupId)
        {
            var oSystemParameterBL = new SystemParameterBL ();

            var parameters = oSystemParameterBL.GetParameters(new SystemParameterRequest { GroupId = groupId });

            return Ok(parameters);
        }
    }
}
