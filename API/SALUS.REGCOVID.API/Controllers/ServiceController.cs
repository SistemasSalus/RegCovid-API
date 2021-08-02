using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Service.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        [Route("service/servicesForAdmin")]
        public IHttpActionResult servicesForAdmin([FromUri]ServiceRequestForAdmin oServiceRequest)
        {
            var oServiceBL = new ServiceBL();

            var services = oServiceBL.GetServicesForAdmin(oServiceRequest);

            return Ok(services);
        }

        [HttpGet]
        [Route("service/services")]
        public IHttpActionResult Services([FromUri] ServiceRequest oServiceRequest)
        {
            var oServiceBL = new ServiceBL();

            var services = oServiceBL.GetServices(oServiceRequest);

            return Ok(services);
        }

        [HttpGet]
        [Route("service/indicators")]
        public IHttpActionResult ServicesIndicators(string node, string date)
        {
            var oServiceBL = new ServiceBL();

            var indicadores = oServiceBL.ServicesIndicators(node, date);

            return Ok(indicadores);
        }

        [HttpGet]
        [Route("service/DeleteService")]
        public IHttpActionResult DeleteService(string serviceId)
        {
            var oServiceBL = new ServiceBL();

            var indicadores = oServiceBL.UpdateStatusToDeletedsService(serviceId);

            return Ok(indicadores);
        }

        [HttpGet]
        [Route("service/Pdf")]
        public HttpResponseMessage GetServiceFile(string serviceId)
        {
            if (String.IsNullOrEmpty(serviceId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            string fileName;
            string localFilePath;
            
            localFilePath = getFileFromID(serviceId, out fileName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;
        }

        private string getFileFromID(string serviceId, out string fileName)
        {
            fileName = serviceId;
            var pathPdf = ConfigurationManager.AppSettings["PATH_PDF"] + fileName+".pdf";
            return pathPdf;
        }
    }
}
