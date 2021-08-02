using SALUS.REGCOVID.Common.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class LocationsController : ApiController
    {
        [HttpGet]
        [Route("Locations/{organizationId}")]
        public IHttpActionResult GetAll(string organizationId)
        {
            var locationBL = new LocationBL();

            var sedes = locationBL.GetLocations(organizationId);

            return Ok(sedes);
        }
    }
}
