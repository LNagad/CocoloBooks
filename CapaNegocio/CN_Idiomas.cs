using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Idiomas
    {
        private CD_Idiomas objCapaDato = new CD_Idiomas();

        public List<Idiomas> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(Idiomas idiomas, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(idiomas.Name) || string.IsNullOrWhiteSpace(idiomas.Name))
            {
                Mensaje = "El nombre del idioma no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(idiomas.Description) || string.IsNullOrWhiteSpace(idiomas.Description))
            {
                Mensaje = "La descripcion del idioma no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(idiomas, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool Editar(Idiomas idiomas, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(idiomas.Name) || string.IsNullOrWhiteSpace(idiomas.Name))
            {
                Mensaje = "El nombre del idioma no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(idiomas.Description) || string.IsNullOrWhiteSpace(idiomas.Description))
            {
                Mensaje = "La descripcion del idioma no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(idiomas, out Mensaje);
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
