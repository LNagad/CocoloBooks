using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult ConsultarPorEditora(int id)
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Consulta().ListarPorEditora(id);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}