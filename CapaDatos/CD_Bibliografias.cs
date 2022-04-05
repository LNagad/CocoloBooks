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
    public class CD_Bibliografias
    {
        public List<Bibliografias> Listar()
        {
            List<Bibliografias> lista = new List<Bibliografias>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select Id, Name, Description, Estado from Bibliografias";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new Bibliografias()
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
                lista = new List<Bibliografias>();
            }
            return lista;
        }


        public int Registrar(Bibliografias bibliografia, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_registrarBiibliografia", oConexion);
                    cmd.Parameters.AddWithValue("Name", bibliografia.Name);
                    cmd.Parameters.AddWithValue("Description", bibliografia.Description);
                    cmd.Parameters.AddWithValue("Estado", bibliografia.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;

                Mensaje = ex.Message;
            }

            return idAutoGenerado;
        }


        public bool Editar(Bibliografias bibliografia, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_editarBibliografia", oConexion);
                    cmd.Parameters.AddWithValue("IdBibliografia", bibliografia.Id);
                    cmd.Parameters.AddWithValue("Name", bibliografia.Name);
                    cmd.Parameters.AddWithValue("Description", bibliografia.Description);
                    cmd.Parameters.AddWithValue("Estado", bibliografia.Estado);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
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
                    SqlCommand cmd = new SqlCommand("sp_eliminarBibliografia", oConexion);
                    cmd.Parameters.AddWithValue("IdBibliografia", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;


                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    // EXECUTE NON QUERY DEVUELVE EL TOTAL DE FILAS AFECTADAS
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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

   