using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();

            oLista = new CN_Usuarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario usuario)
        {
            object resultado;
            string mensaje = string.Empty;

            if (usuario.Id == 0)
            {
                resultado = new CN_Usuarios().Registrar(usuario, out mensaje);
            }
            else
            {
                resultado = new CN_Usuarios().Editar(usuario, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(Usuario usuario)
        {
            object resultado;
            string mensaje = string.Empty;

            if (usuario.Id == 0)
            {
                resultado = false;
            }
            else
            {
                resultado = new CN_Usuarios().Eliminar(usuario.Id, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}