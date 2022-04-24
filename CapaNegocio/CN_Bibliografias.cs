using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Bibliografias
    {
        private CD_Bibliografias objCapaDato = new CD_Bibliografias();

        public List<Bibliografias> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Bibliografias bibliografia, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(bibliografia.Name) || string.IsNullOrWhiteSpace(bibliografia.Name))
            {
                Mensaje = "El nombre de la bibliografia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(bibliografia.Description) || string.IsNullOrWhiteSpace(bibliografia.Description))
            {
                Mensaje = "La descripcion de la bibliografia no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(bibliografia, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Bibliografias bibliografia, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(bibliografia.Name) || string.IsNullOrWhiteSpace(bibliografia.Name))
            {
                Mensaje = "El nombre de la bibliografia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(bibliografia.Description) || string.IsNullOrWhiteSpace(bibliografia.Description))
            {
                Mensaje = "La descripcion de la bibliografia no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(bibliografia, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
     }

}

