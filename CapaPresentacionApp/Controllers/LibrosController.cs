using CapaEntidad;
using CapaNegocio;
using CapaPresentacionAdmin.Permisos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        [permisosAdmin]
        public ActionResult PrestamoLibros()
        {
            return View();
        }
        [permisosAdmin]
        public ActionResult RentasRealizadas()
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
        public JsonResult GuardarLibro(string objeto, HttpPostedFileBase archivoImagen)
        {
            object resultado;
            string mensaje = string.Empty;
            bool operacionExitosa = true;
            bool guardarImagenExito = true;

            Libros oLibro = new Libros();

            oLibro = JsonConvert.DeserializeObject<Libros>(objeto);

            if (oLibro.Id == 0)
            {
                int idGenerado = new CN_Libros().Registrar(oLibro, out mensaje);

                if (idGenerado != 0)
                {
                    oLibro.Id = idGenerado;
                } 
                else
                {
                    operacionExitosa = false;
                }
            }
            else
            {
                operacionExitosa = new CN_Libros().Editar(oLibro, out mensaje);

            }

            if (operacionExitosa)
            {
                if (archivoImagen != null)
                {
                    string rutaGuardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombreImagen = string.Concat(oLibro.Id.ToString(), extension);

                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(rutaGuardar, nombreImagen)); //guardar en una ruta

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardarImagenExito = false;
                    }

                    if (guardarImagenExito)
                    {
                        oLibro.RutaImagen = rutaGuardar;
                        oLibro.NombreImagen = nombreImagen;

                        bool rspta = new CN_Libros().GuardarDatosImagen(oLibro, out mensaje);
                    } else
                    {
                        mensaje = "Se guardo el libro pero hubo error con la imagen";
                    }
                }
            }

            return Json(new { operacionExitosa = operacionExitosa, idGenerado = oLibro.Id, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ImagenArchivo(string id)
        {
            int nuevoId = Convert.ToInt32(id);
            bool resultado;
            Libros oLibro = new CN_Libros().Listar().Where(p => p.Id == nuevoId).FirstOrDefault();

            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oLibro.RutaImagen, oLibro.NombreImagen), out resultado);

            return Json(new
            {
                resultado = resultado,
                textoBase64 = textoBase64,
                extension = Path.GetExtension(oLibro.NombreImagen)

            }, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    resultado = true,
            //    textoBase64 = 's',
            //    extension = "asdasd"

            //}, JsonRequestBehavior.AllowGet);
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