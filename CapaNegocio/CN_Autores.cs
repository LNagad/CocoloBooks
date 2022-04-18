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

        public int Registrar(Autores autores, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(autores.Name) || string.IsNullOrWhiteSpace(autores.Name))
            {
                Mensaje = "El nombre del autor no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(autores.Description) || string.IsNullOrWhiteSpace(autores.Description))
            {
                Mensaje = "La descripcion del Autor no puede estar vacia";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(autores, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Autores autores, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(autores.Name) || string.IsNullOrWhiteSpace(autores.Name))
            {
                Mensaje = "El nombre del Autor no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(autores.Description) || string.IsNullOrWhiteSpace(autores.Description))
            {
                Mensaje = "La descripcion del Autor no puede estar vacia";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(autores, out Mensaje);
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