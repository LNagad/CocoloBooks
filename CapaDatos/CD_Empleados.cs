using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Empleados
    {
        public List<Empleados> Listar()
        {
            List<Empleados> lista = new List<Empleados>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from Empleados";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Empleados()
                            {
                                Id = Convert.ToInt32(DR["Id"]),
                                Nombre = DR["Nombre"].ToString(),
                                Cedula = DR["Cedula"].ToString(),
                                TandaLabor = DR["TandaLabor"].ToString(),
                                PorcientoComision = DR["PorcientoComision"].ToString(),
                                FechaIngreso = DR["FechaIngreso"].ToString(),
                                Estado = Convert.ToBoolean(DR["Estado"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Empleados>();
            }
            return lista;
        }
        public int Registrar(Empleados empleados, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Libros VALUES @Signa, @Nombre, @ISB, @BibliografiaId, @Autores, @Descripcion, @Ciencia, @Editora, @Estado, @Idioma, @year", oConexion);
                    //cmd.Parameters

                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO Empleados ( Nombre, Cedula, TandaLabor, PorcientoComision, FechaIngreso, Estado) ");
                    sb.Append("VALUES ( @Nombre, @Cedula, @TandaLabor, @PorcientoComision,@FechaIngreso, @Estado)");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", empleados.Nombre);
                        cmd.Parameters.AddWithValue("@Cedula", empleados.Cedula);
                        cmd.Parameters.AddWithValue("@TandaLabor", empleados.TandaLabor);
                        cmd.Parameters.AddWithValue("@PorcientoComision", empleados.PorcientoComision);
                                cmd.Parameters.AddWithValue("@FechaIngreso", empleados.FechaIngreso); 
                        cmd.Parameters.AddWithValue("@Estado", empleados.Estado); 


                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        idAutoGenerado = 1;
                        Mensaje = "Registro insertado exitosamente";
                    }

                    //oConexion.Open();

                    //cmd.ExecuteNonQuery();

                    //idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    //Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }
        public bool Editar(Empleados empleados, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Libros VALUES @Signa, @Nombre, @ISB, @BibliografiaId, @Autores, @Descripcion, @Ciencia, @Editora, @Estado, @Idioma, @year", oConexion);
                    //cmd.Parameters


                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Empleados SET ");
                    sb.Append("Nombre = @Nombre,");
                    sb.Append("Cedula = @Cedula,");
                    sb.Append("TandaLabor = @TandaLabor,");
                    sb.Append("PorcientoComision = @PorcientoComision,");
                    sb.Append("FechaIngreso = @FechaIngreso,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", empleados.Nombre);
                        cmd.Parameters.AddWithValue("@Cedula", empleados.Cedula);
                        cmd.Parameters.AddWithValue("@TandaLabor", empleados.TandaLabor);
                        cmd.Parameters.AddWithValue("@PorcientoComision", empleados.PorcientoComision);
                        cmd.Parameters.AddWithValue("@FechaIngreso", empleados.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Estado", empleados.Estado);
                        cmd.Parameters.AddWithValue("@Id", empleados.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }
                }
                Mensaje = "Registro actualizado exitosamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }

            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from Empleados where Id = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    // EXECUTE NON QUERY DEVUELVE EL TOTAL DE FILAS AFECTADAS
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                Mensaje = "Registro eliminado exitosamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

    }
}
