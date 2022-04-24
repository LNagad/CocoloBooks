using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        #region VIEWS
        public ActionResult Libros()
        {
            return View();
        }

        public ActionResult PrestamoLibros()
        {
            return View();
        }

        #endregion

        #region Metodos

        [HttpGet]
        public JsonResult ListarLibros()
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Libros().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarLibroSeleccionado()
        {
            List<Libros> oLista = new List<Libros>();

            oLista = new CN_Libros().ListarSelected();


            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GuardarLibro(Libros libro)
        {
            object resultado;
            string mensaje = string.Empty;

            if (libro.Id == 0)
            {
                resultado = new CN_Libros().Registrar(libro, out mensaje);
            }
            else
            {
                resultado = new CN_Libros().Editar(libro, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult EliminarLibro(int id)
        {
            bool resultado = false;
            string mensaje = string.Empty;


            resultado = new CN_Libros().Eliminar(id, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}