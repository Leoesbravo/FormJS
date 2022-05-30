using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EstadoController : Controller
    {
        //
        // GET: /Estado/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            ML.Result result = BL.Estado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}