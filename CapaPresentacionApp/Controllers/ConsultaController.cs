using CapaEntidad;
using CapaNegocio;
using CapaPresentacionAdmin.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    [permisosAdmin]
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
        public JsonResult ConsultarPorCiencias(int id)
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Consulta().ConsultarPorCiencias(id);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarPorIdiomas(int id)
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Consulta().ConsultarPorIdiomas(id);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarPorAutores(int id)
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Consulta().ConsultarPorAutores(id);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarPorBibliografias(int id)
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Consulta().ConsultarPorBibliografias(id);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}