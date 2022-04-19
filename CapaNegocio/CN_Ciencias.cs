using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Ciencias
    {
        private CD_Ciencias objCapaDato = new CD_Ciencias();

        public List<Ciencias> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(Ciencias ciencias, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(ciencias.Name) || string.IsNullOrWhiteSpace(ciencias.Name))
            {
                Mensaje = "El nombre de la ciencia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(ciencias.Description) || string.IsNullOrWhiteSpace(ciencias.Description))
            {
                Mensaje = "La descripcion de la ciencia no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(ciencias, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool Editar(Ciencias ciencias, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(ciencias.Name) || string.IsNullOrWhiteSpace(ciencias.Name))
            {
                Mensaje = "El nombre de la ciencia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(ciencias.Description) || string.IsNullOrWhiteSpace(ciencias.Description))
            {
                Mensaje = "La descripcion de la ciencia no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(ciencias, out Mensaje);
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
