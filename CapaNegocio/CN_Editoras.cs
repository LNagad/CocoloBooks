using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Editoras
    {

        private CD_Editoras objCapaDato = new CD_Editoras();

        public List<Editoras> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Editoras editoras, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(editoras.Name) || string.IsNullOrWhiteSpace(editoras.Name))
            {
                Mensaje = "El nombre de la bibliografia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(editoras.Description) || string.IsNullOrWhiteSpace(editoras.Description))
            {
                Mensaje = "La descripcion de la bibliografia no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(editoras, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Editoras editoras, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(editoras.Name) || string.IsNullOrWhiteSpace(editoras.Name))
            {
                Mensaje = "El nombre de la bibliografia no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(editoras.Description) || string.IsNullOrWhiteSpace(editoras.Description))
            {
                Mensaje = "La descripcion de la bibliografia no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(editoras, out Mensaje);
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
