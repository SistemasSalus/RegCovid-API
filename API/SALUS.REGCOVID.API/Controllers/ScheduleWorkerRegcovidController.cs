using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Schedule.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class ScheduleWorkerRegcovidController : ApiController
    {
        [HttpPost]
        [Route("ScheduleWorkerRegcovid/schedule")]
        public IHttpActionResult ScheduleRegCovid(ScheduleRegcovidRequest oScheduleRegcovidRequest)
        {
            var oScheduleBL = new ScheduleBL();

            var serviceId = oScheduleBL.ScheduleWorkerRegCovid(oScheduleRegcovidRequest);

            return Ok(serviceId);
        }
    }
}
