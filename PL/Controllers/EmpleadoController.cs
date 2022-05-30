using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        [HttpGet]
        public ActionResult Getall()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }

        [HttpGet]
        public JsonResult Get()
        {
            ML.Result result = BL.Empleado.EmpleadoGetall();

            return Json(result, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public JsonResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ML.Empleado empleado)
        {    
            ML.Result result = BL.Empleado.EmpleadoAdd(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.EmpleadoDelete(IdEmpleado);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}