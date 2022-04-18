using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Autores
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Estado { get; set; }

        public string paisOrigen { get; set; }

        public string IdiomaNativo { get; set; }

    }
}
