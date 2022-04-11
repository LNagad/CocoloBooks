using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarLibro(int id)
        {
            var Mensaje = String.Empty;
            var resultado = false;
            try
            {
                CapaEntidad.LibroDetalleSelect.idLibro = id;
                Mensaje = $"Se ha colocado el id {id} a la capa";
                resultado = true;
            }
            catch (Exception ex)
            {
                Mensaje = $"No se ha podido colocar el id ({ex})";
                
            }
       
            return Json(new { data = resultado , mensaje = Mensaje } , JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetalleLibro()
        {
            
            ViewBag.Id = CapaEntidad.LibroDetalleSelect.idLibro;
            
            return View();
        }
    }
}