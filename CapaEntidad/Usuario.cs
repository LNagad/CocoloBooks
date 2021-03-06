using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public int TipoUsuario { get; set; } //1 = usuario /2 = admin / 3 = Empleados
        public string Cedula { get; set; }
        public int NCarnet { get; set; }
        public int TipoPersona { get; set; } //juridica / fiscal
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
