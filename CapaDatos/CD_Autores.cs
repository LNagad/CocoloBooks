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
                    string query = "select Id, Name, Description, Estado from Autores";
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
    }
}
