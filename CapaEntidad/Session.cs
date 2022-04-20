using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public static class Session
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Correo { get; set; }
        public static string Clave { get; set; }
        public static int TipoUsuario { get; set; } //usuario / admin / master
        public static string Cedula { get; set; }
        public static int NCarnet { get; set; }
        public static int TipoPersona { get; set; } //juridica / fiscal
        public static DateTime FechaRegistro { get; set; }
        public static bool Estado { get; set; }

    }
}
