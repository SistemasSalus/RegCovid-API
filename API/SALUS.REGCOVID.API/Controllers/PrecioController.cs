using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    public class PrecioController : ApiController
    {
        [HttpGet]
        [Route("Precio/precios")]
        public IHttpActionResult GetPrecios()
        {
            var oPrecio = new PrecioBL();

            var precios = oPrecio.GetPrecios();

            return Ok(precios);

        }

        [HttpPost]
        [Route("Precio/create")]
        public IHttpActionResult CreatePrecios(Precio precio)
        {
            var oPrecio = new PrecioBL();

            var precios = oPrecio.CreatePrecios(precio);

            return Ok(precios);

        }

        [HttpPut]
        [Route("Precio/update")]
        public IHttpActionResult GetPrecios(Precio precio)
        {
            var oPrecio = new PrecioBL();

            var precios = oPrecio.UpdatePrecios(precio);

            return Ok(precios);

        }

        [HttpGet]
        [Route("Precio/delete")]
        public IHttpActionResult DeletePrecios(int id)
        {
            var oPrecio = new PrecioBL();

            var precios = oPrecio.DeletePrecios(id);

            return Ok(precios);

        }
    }
}