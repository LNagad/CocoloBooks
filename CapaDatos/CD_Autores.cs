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
    public class CD_Autores
    {
        public List<Autores> Listar()
        {
            List<Autores> lista = new List<Autores>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select Id, Name, Description, Estado, paisOrigen, IdiomaNativo from Autores";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Autores()
                            {
                                Id = Convert.ToInt32(DR["Id"]),
                                Name = DR["Name"].ToString(),
                                Description = DR["Description"].ToString(),
                                Estado = Convert.ToBoolean(DR["Estado"]),
                                paisOrigen = DR["paisOrigen"].ToString(),
                                IdiomaNativo = DR["IdiomaNativo"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Autores>();
            }
            return lista;
        }

        public int Registrar(Autores autor, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Insert autores (Name,Description, Estado, paisOrigen, IdiomaNativo) ");
                    sb.Append("VALUES ( @Name, @Description, @Estado, @paisOrigen, @IdiomaNativo)");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Name", autor.Name);
                        cmd.Parameters.AddWithValue("@Description", autor.Description);
                        cmd.Parameters.AddWithValue("@Estado", autor.Estado);
                        cmd.Parameters.AddWithValue("@paisOrigen", autor.paisOrigen);
                        cmd.Parameters.AddWithValue("@IdiomaNativo", autor.IdiomaNativo);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        idAutoGenerado = 1;
                        Mensaje = "Se ha registrado el autor correctamente";
                    }
                }

            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }
        public bool Editar(Autores autores, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Autores SET ");

                    sb.Append("Name = @Name,");
                    sb.Append("Description = @Description,");
                    sb.Append("paisOrigen = @paisOrigen,");
                    sb.Append("IdiomaNativo = @IdiomaNativo,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Name", autores.Name);
                        cmd.Parameters.AddWithValue("@Description", autores.Description);
                        cmd.Parameters.AddWithValue("@paisOrigen", autores.paisOrigen);
                        cmd.Parameters.AddWithValue("@IdiomaNativo", autores.IdiomaNativo);
                        cmd.Parameters.AddWithValue("@Estado", autores.Estado);
                        cmd.Parameters.AddWithValue("@Id", autores.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }

                }
                Mensaje = "Autor actualizado correctamente";
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
                    SqlCommand cmd = new SqlCommand($"delete from Autores where Id = {id}", oConexion);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = true;
                    Mensaje = "Autor eliminado correctamente";

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