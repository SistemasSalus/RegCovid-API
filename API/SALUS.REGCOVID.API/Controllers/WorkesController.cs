using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Schedule.BL;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class WorkesController : ApiController
    {
        [HttpGet]
        [Route("Workes/{dni}")]
        public IHttpActionResult GetDataWorker(string dni)
        {
            var oWorkerBL = new WorkerBL();

            var data = oWorkerBL.GetDataWorker(new WorkerDataRequest { Filtro = dni });

            return Ok(data);
        }
    }
}
