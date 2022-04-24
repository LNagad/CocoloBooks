using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string TandaLabor { get; set; }
        public string PorcientoComision { get; set; }
        public string FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }
}
