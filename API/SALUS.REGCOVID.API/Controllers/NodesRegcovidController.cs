using SALUS.REGCOVID.Common.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class NodesRegcovidController : ApiController
    {
        [HttpGet]
        [Route("NodesRegcovid")]
        public IHttpActionResult GetAll()
        {
            var nodesRegCovidBL = new NodesRegCovidBL();

            var nodes = nodesRegCovidBL.GetNodesRegcovid();

            return Ok(nodes);
        }
    }
}
