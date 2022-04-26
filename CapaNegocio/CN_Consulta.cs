using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Consulta
    {
        private CD_Consulta objCapaDato = new CD_Consulta();

        public List<Libros> ListarPorEditora(int id)
        {
            return objCapaDato.ListarPorEditora(id);
        }
        public List<Libros> ConsultarPorCiencias(int id)
        {
            return objCapaDato.ListarPorCiencias(id);
        }
        public List<Libros> ConsultarPorIdiomas(int id)
        {
            return objCapaDato.ListarPorIdiomas(id);
        }
        public List<Libros> ConsultarPorAutores(int id)
        {
            return objCapaDato.ListarPorAutores(id);
        }
        public List<Libros> ConsultarPorBibliografias(int id)
        {
            return objCapaDato.ListarPorBibliografias(id);
        }
    }
}
