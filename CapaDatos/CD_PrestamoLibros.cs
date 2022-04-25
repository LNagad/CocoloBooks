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
    public class CD_PrestamoLibros
    {
        public List<Usuario> ListarUsuariosClientes()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from USUARIOS where TipoUsuario = 1";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    TipoUsuario = Convert.ToInt32(dr["TipoUsuario"]),
                                    Cedula = dr["Cedula"].ToString(),
                                    NCarnet = Convert.ToInt32(dr["NCarnet"]),
                                    TipoPersona = Convert.ToInt32(dr["TipoPersona"]),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }

                                );
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                lista = new List<Usuario>();
            }

            return lista;
        }


        public List<Libros> ListarLibrosActivos()
        {
            List<Libros> lista = new List<Libros>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = $"select * from vw_libros WHERE Estado = 1";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(

                                new Libros()
                                {
                                    Id = Convert.ToInt32(DR["Id"]),
                                    SignaturaTopografica = DR["SignaturaTopografica"].ToString(),
                                    Nombre = DR["Nombre"].ToString(),
                                    ISBN = Convert.ToDecimal(DR["ISBN"]),
                                    Descripcion = DR["Descripcion"].ToString(),
                                    BibliografiaId = Convert.ToInt32(DR["BibliografiaId"]), //fk
                                    Bibliografia = DR["Bibliografia"].ToString(),
                                    CienciaId = Convert.ToInt32(DR["CienciaId"]), // fk
                                    Ciencia = DR["Ciencia"].ToString(),
                                    AutorId = Convert.ToInt32(DR["AutorId"]), // fk
                                    Autores = DR["Autor"].ToString(),
                                    EditoraId = Convert.ToInt32(DR["EditoraId"]), // fk
                                    Editora = DR["Editora"].ToString(),
                                    IdiomaId = Convert.ToInt32(DR["IdiomaId"]), // fk
                                    Idioma = DR["Idioma"].ToString(),
                                    year = DR["year"].ToString(),
                                    Estado = Convert.ToBoolean(DR["Estado"]),

                                }

                                ); ;
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                lista = new List<Libros>();
            }
            return lista;
        }

    }

    
}
