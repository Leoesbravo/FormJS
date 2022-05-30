using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLAPI.Controllers
{
    public class EstadoController : ApiController
    {
        [HttpGet]
        [Route("api/Estado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
