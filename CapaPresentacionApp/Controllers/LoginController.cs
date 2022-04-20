using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.Clave = CN_Recursos.ConvertirSha256(oUsuario.Clave);

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {

                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuario.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (oUsuario.Id != 0)
            {
                Session["usuario"] = oUsuario;
                
                var myobj = new CapaDatos.CD_Usuarios();
                myobj.GetUsuarioSession(oUsuario.Id);

                if ( CapaEntidad.Session.TipoUsuario == 1 ) // roleo
                {
                    return RedirectToAction("Index", "HomePage");

                } else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }
        public ActionResult CerrarSesion()
        {
            CapaEntidad.Session.TipoUsuario = 0;
            Session["Usuario"] = null;
            return RedirectToAction("Index", "HomePage");
        }
    }
}