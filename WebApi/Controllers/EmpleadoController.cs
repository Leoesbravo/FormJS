using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        //
        // GET: /Empleado/
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        // GET api/usuario
        public IHttpActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.EmpleadoGetall();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
	}
}