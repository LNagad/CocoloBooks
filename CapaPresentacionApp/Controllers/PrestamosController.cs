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


        public JsonResult ListarLibrosActivos()
        {
            List<Libros> Olista = new List<Libros>();

            Olista = new CN_PrestamoLibros().ListarLibrosActivos();

            return Json(new { data = Olista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarRentas()
        {
            List<RentasLibros> Olista = new List<RentasLibros>();

            Olista = new CN_PrestamoLibros().ListarRentas();

            return Json(new { data = Olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarRenta(RentasLibros datosRenta)
        {
            object resultado;
            string mensaje = string.Empty;

            resultado = new CN_PrestamoLibros().RegistrarRenta(datosRenta, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActualizarRenta(RentasLibros datosRenta)
        {
            object resultado;
            string mensaje = string.Empty;

            resultado = new CN_PrestamoLibros().ActualizarRenta(datosRenta, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}