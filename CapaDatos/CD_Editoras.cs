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
    public class CD_Editoras
    {
        public List<Editoras> Listar()
        {
            List<Editoras> lista = new List<Editoras>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select Id, Name, Description, Estado from Editoras";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Editoras()
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
                lista = new List<Editoras>();
            }
            return lista;
        }

        public int Registrar(Editoras editoras, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand($"Insert Editoras(Name,Description, Estado) values ('{editoras.Name}','{editoras.Description}', '{editoras.Estado}' )", oConexion);      
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idAutoGenerado = 1;

                    Mensaje = "Se ha registrado la editora correctamente";

                }
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }


        public bool Editar(Editoras editoras, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE Editoras SET ");

                    sb.Append("Name = @Name,");
                    sb.Append("Description = @Description,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Name", editoras.Name);
                        cmd.Parameters.AddWithValue("@Description", editoras.Description);
                        cmd.Parameters.AddWithValue("@Estado", editoras.Estado);
                        cmd.Parameters.AddWithValue("@Id", editoras.Id);
                       
                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }

                }
                Mensaje = "Editora actualizada correctamente";
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
                    SqlCommand cmd = new SqlCommand($"delete from Editoras where Id = {id}", oConexion);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = true;
                    Mensaje = "Editora eliminado correctamente";

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
