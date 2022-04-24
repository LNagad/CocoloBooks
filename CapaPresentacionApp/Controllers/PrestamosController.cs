using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class PrestamosController : Controller
    {
        public JsonResult ListarUsuariosClientes()
        {
            List<Usuario> Olista = new List<Usuario>();

            Olista = new CN_PrestamoLibros().ListarUsuariosClientes();

            return Json(new { data = Olista }, JsonRequestBehavior.AllowGet );
        }


    }
}