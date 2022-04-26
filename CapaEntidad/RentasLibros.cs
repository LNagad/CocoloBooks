using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RentasLibros
    {
        public int IdRenta { get; set; }
        public int IdLibro { get; set; }
        public string LibroNombre { get; set; }
        public int IdUsuario {get; set; }
        public string UsuarioNombre { get; set; }
        public string FechaEntrega { get; set; }
        public int ComisionEntregaTardia { get; set; }
        public string fechaRenta { get; set; }
        public bool Estado { get; set; }

    }
}
