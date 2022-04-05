using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Usuario usuario, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(usuario.Apellido) || string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                Mensaje = "El Apellido del usuario no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Correo))
            {
                Mensaje = "El Correo del usuario no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";
                usuario.Clave = CN_Recursos.ConvertirSha256(clave);


                return objCapaDato.Registrar(usuario, out Mensaje);
            }
            else
            {
                return 0;
            }
        }



        public bool Editar(Usuario usuario, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(usuario.Apellido) || string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                Mensaje = "El Apellido del usuario no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Correo))
            {
                Mensaje = "El Correo del usuario no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                //usuario.Clave = CN_Recursos.ConvertirSha256(usuario.Clave);

                return objCapaDato.Editar(usuario, out Mensaje);
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
