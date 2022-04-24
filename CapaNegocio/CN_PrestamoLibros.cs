using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PrestamoLibros
    {
        private CD_PrestamoLibros obj = new CD_PrestamoLibros();
        
        public List<Usuario> ListarUsuariosClientes()
        {
            return obj.ListarUsuariosClientes();
        }

    }
}
