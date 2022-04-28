using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Libros
    {

        private CD_Libros objCapaDato = new CD_Libros();


        public List<Libros> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<Libros> ListarSelected()
        {
            int id = LibroDetalleSelect.idLibro;
            CapaEntidad.LibroDetalleSelect.idLibro = 0;
            return objCapaDato.ListarSelected(id);
        }

        public int Registrar(Libros libro, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(libro.Nombre) || string.IsNullOrWhiteSpace(libro.Nombre))
            {
                Mensaje = "El nombre del libro no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(libro.Descripcion) || string.IsNullOrWhiteSpace(libro.Descripcion))
            {
                Mensaje = "La descripcion del libro no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(libro, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Libros libro, out string Mensaje)
        {
            Mensaje = String.Empty;

            //if (string.IsNullOrEmpty(bibliografia.Name) || string.IsNullOrWhiteSpace(bibliografia.Name))
            //{
            //    Mensaje = "El nombre de la bibliografia no puede estar vacio";
            //}

            //else if (string.IsNullOrEmpty(bibliografia.Description) || string.IsNullOrWhiteSpace(bibliografia.Description))
            //{
            //    Mensaje = "La descripcion de la bibliografia no puede estar vacio";
            //}

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(libro, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool GuardarDatosImagen(Libros libro, out string Mensaje)
        {

            return objCapaDato.GuardarDatosImagen(libro, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }


    }
}
