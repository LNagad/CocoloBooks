using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenimientoController : Controller
    {
        //+++++++++++++++++++++++++++++ VIEWS ++++++++++++++++++
        #region VIEWS

        public ActionResult Bibliografias()
        {
            return View();
        }

        public ActionResult Autores()
        {
            return View();
        }

        public ActionResult Editoras()
        {
            return View();
        }
        #endregion


        //+++++++++++++++++++++++++++++ BIBLIOGRAFIA ++++++++++++++++++
        #region BIBLIOGRAFIA

        [HttpGet]
        public JsonResult ListarBibliografias()
        {
            List<Bibliografias> oLista = new List<Bibliografias>();

            oLista = new CN_Bibliografias().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarBibliografia(Bibliografias bibliografia)
        {
            object resultado;
            string mensaje = string.Empty;

            if (bibliografia.Id == 0)
            {
                resultado = new CN_Bibliografias().Registrar(bibliografia, out mensaje);
            }
            else
            {
                resultado = new CN_Bibliografias().Editar(bibliografia, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarBibliografia(int id)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            
            resultado = new CN_Bibliografias().Eliminar(id, out mensaje);
            

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //+++++++++++++++++++++++++++++ AUTORES ++++++++++++++++++
        #region AUTORES

        [HttpGet]
        public JsonResult ListarAutores()
        {
            List<Autores> oLista = new List<Autores>();

            oLista = new CN_Autores().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarAutor(Autores autor)
        {
            object resultado;
            string mensaje = string.Empty;

            if (autor.Id == 0)
            {
                resultado = new CN_Autores().Registrar(autor, out mensaje);
            }
            else
            {
                resultado = new CN_Autores().Editar(autor, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarAutor(int id)
        {
            object resultado;
            string mensaje = string.Empty;

            if (id == 0)
            {
                resultado = false;
            }
            else
            {
                resultado = new CN_Autores().Eliminar(id, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        //+++++++++++++++++++++++++++++ EDITORAS ++++++++++++++++++
        #region EDITORAS

        [HttpGet]
        public JsonResult ListarEditoras()
        {
            List<Editoras> oLista = new List<Editoras>();

            oLista = new CN_Editoras().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GuardarEditoras(Editoras editora)
        {
            object resultado;
            string mensaje = string.Empty;

            if (editora.Id == 0)
            {
                resultado = new CN_Editoras().Registrar(editora, out mensaje);
            }
            else
            {
                resultado = new CN_Editoras().Editar(editora, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarEditoras(int id)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            resultado = new CN_Editoras().Eliminar(id, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        #endregion

    }
}