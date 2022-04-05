using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Autores
    {

        private CD_Autores objCapaDato = new CD_Autores();

        public List<Autores> Listar()
        {
            return objCapaDato.Listar();
        }

    }
}
