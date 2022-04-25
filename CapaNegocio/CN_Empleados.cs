using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        private CD_Empleados objCapaDato = new CD_Empleados();

        public List<Empleados> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Empleados empleados, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(empleados.Nombre) || string.IsNullOrWhiteSpace(empleados.Nombre))
            {
                Mensaje = "El nombre del Empleado no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(empleados.Cedula) || string.IsNullOrWhiteSpace(empleados.Cedula))
            {
                Mensaje = "La Cedula del empleado no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(empleados.TandaLabor) || string.IsNullOrWhiteSpace(empleados.TandaLabor))
            {
                Mensaje = "La tanda de labor del empleado no puede estar vacia";
            }
            else if (string.IsNullOrEmpty(empleados.PorcientoComision) || string.IsNullOrWhiteSpace(empleados.PorcientoComision))
            {
                Mensaje = "El porciento de comision no puede estar vacio";
            }
            //else if (string.IsNullOrEmpty(empleados.FechaIngreso) || string.IsNullOrWhiteSpace(empleados.FechaIngreso))
            //{
            //    Mensaje = "La Fecha de ingreso no puede estar vacia";
            //}


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(empleados, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        public bool Editar(Empleados empleados, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(empleados.Nombre) || string.IsNullOrWhiteSpace(empleados.Nombre))
            {
                Mensaje = "El nombre del empleado no puede estar vacio";
            }

            else if (string.IsNullOrEmpty(empleados.Cedula) || string.IsNullOrWhiteSpace(empleados.Cedula))
            {
                Mensaje = "La Cedula del empleado no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(empleados.TandaLabor) || string.IsNullOrWhiteSpace(empleados.TandaLabor))
            {
                Mensaje = "La tanda de labor del empleado no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(empleados.PorcientoComision) || string.IsNullOrWhiteSpace(empleados.PorcientoComision))
            {
                Mensaje = "El porciento de comision del empleado no puede estar vacio";
            }
            //else if (string.IsNullOrEmpty(empleados.FechaIngreso) || string.IsNullOrWhiteSpace(empleados.FechaIngreso))
            //{
            //    Mensaje = "La Fecha de ingreso del empleado no puede estar vacio";
            //}
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(empleados, out Mensaje);
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
