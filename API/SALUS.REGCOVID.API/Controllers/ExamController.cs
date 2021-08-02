using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Exam.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class ExamController : ApiController
    {
        [HttpGet]
        [Route("Exam/getValues")]
        public IHttpActionResult GetValuesComponent(string serviceId, string componentId)
        {
            var examBL = new ExamBL();

            var data = examBL.GetValuesComponent(serviceId, componentId);

            return Ok(data);
        }


        [HttpPost]
        [Route("Exam/saveSurvey")]
        public IHttpActionResult SaveSurvey(SurveyRequest oSurveyRequest)
        {
            var oExamBL = new ExamBL();

            var result = oExamBL.SaveSurvey(oSurveyRequest);

            return Ok(result);
        }

        [HttpPost]
        [Route("Exam/savelaboratory")]
        public IHttpActionResult Savelaboratory(LaboratoryRequest oLaboratoryRequest)
        {
            var oExamBL = new ExamBL();

            var result = oExamBL.SaveLaboratory(oLaboratoryRequest);

            return Ok(result);
        }

    }
}
