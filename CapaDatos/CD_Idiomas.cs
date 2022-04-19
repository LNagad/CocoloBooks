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
    public class CD_Idiomas
    {
        public List<Idiomas> Listar()
        {
            List<Idiomas> lista = new List<Idiomas>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select Id, Name, Description, Estado from Idiomas";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Idiomas()
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
                lista = new List<Idiomas>();
            }
            return lista;
        }
        public int Registrar(Idiomas idiomas, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand($"Insert Idiomas(Name,Description, Estado) values ('{idiomas.Name}','{idiomas.Description}', '{idiomas.Estado}' )", oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idAutoGenerado = 1;

                    Mensaje = "Se ha registrado el idioma correctamente";

                }
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }
        public bool Editar(Idiomas idiomas, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Idiomas SET ");

                    sb.Append("Name = @Name,");
                    sb.Append("Description = @Description,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Name", idiomas.Name);
                        cmd.Parameters.AddWithValue("@Description", idiomas.Description);
                        cmd.Parameters.AddWithValue("@Estado", idiomas.Estado);
                        cmd.Parameters.AddWithValue("@Id", idiomas.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }

                }
                Mensaje = "Idioma actualizado correctamente";
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
                    SqlCommand cmd = new SqlCommand($"delete from Idiomas where Id = {id}", oConexion);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = true;
                    Mensaje = "Idioma eliminado correctamente";

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
