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

        public List<Libros> ListarLibrosActivos()
        {
            return obj.ListarLibrosActivos();
        }

        public int RegistrarRenta(RentasLibros datosRenta, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(datosRenta.FechaEntrega) )
            {
                mensaje = "Por favor asigne la fecha de entrega de esta renta.";
            } 
            else if (datosRenta.ComisionEntregaTardia == 0) 
            {
                mensaje = "Asigne la comision a cobrar al cliente por entrega tardia " + datosRenta.ComisionEntregaTardia;
            } 
            
            if (string.IsNullOrEmpty(mensaje))
            {
                return obj.RegistrarRenta(datosRenta, out mensaje);
            } 
            else
            {
                return 0;
            }
            
        }
    }
}
