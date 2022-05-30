using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLAPI.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        // GET api/aseguradora
        public IHttpActionResult GetAll()
        {

            ML.Empleado empleado  = new ML.Empleado();
            empleado.Estado = new ML.Estado();
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
        [HttpGet]
        [Route("api/Empleado/GetById/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }
        [HttpPost]
        [Route("api/Empleado/Add")]
        // POST: api/SubCategoria
        public IHttpActionResult Post([FromBody]ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.EmpleadoAdd(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPost]
        [Route("api/Empleado/Update")]
        // PUT: api/SubCategoria/5
        public IHttpActionResult Put([FromBody]ML.Empleado empleado)
        {
            var result = BL.Empleado.EmpleadoUpdate(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("api/Empleado/Delete/{IdEmpleado}")]
        // GET: api/SubCategoria/Delete
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.EmpleadoDelete(IdEmpleado);

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
