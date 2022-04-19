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
    public class CD_Ciencias
    {
        public List<Ciencias> Listar()
        {
            List<Ciencias> lista = new List<Ciencias>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select Id, Name, Description, Estado from Ciencias";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Ciencias()
                            {
                                Id = Convert.ToInt32(DR["Id"]),
                                Name = DR["Name"].ToString(),
                                Description = DR["Description"].ToString(),
                                Estado = Convert.ToBoolean(DR["Estado"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Ciencias>();
            }
            return lista;
        }
        public int Registrar(Ciencias ciencias, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand($"Insert Ciencias(Name,Description, Estado) values ('{ciencias.Name}','{ciencias.Description}', '{ciencias.Estado}' )", oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idAutoGenerado = 1;

                    Mensaje = "Se ha registrado la ciencia correctamente";

                }
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }
        public bool Editar(Ciencias ciencias, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Ciencias SET ");

                    sb.Append("Name = @Name,");
                    sb.Append("Description = @Description,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Name", ciencias.Name);
                        cmd.Parameters.AddWithValue("@Description", ciencias.Description);
                        cmd.Parameters.AddWithValue("@Estado", ciencias.Estado);
                        cmd.Parameters.AddWithValue("@Id", ciencias.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }

                }
                Mensaje = "Ciencia actualizada correctamente";
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
                    SqlCommand cmd = new SqlCommand($"delete from Ciencias where Id = {id}", oConexion);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = true;
                    Mensaje = "Ciencia eliminada correctamente";

                }
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
