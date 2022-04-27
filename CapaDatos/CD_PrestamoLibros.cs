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

        public List<RentasLibros> ListarRentas()
        {
            List<RentasLibros> lista = new List<RentasLibros>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from vw_rentas";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            lista.Add(new RentasLibros()
                            {
                                    IdRenta = Convert.ToInt32(DR["IdRenta"]),
                                    IdLibro = Convert.ToInt32(DR["IdLibro"]),
                                    LibroNombre = DR["LibroNombre"].ToString(),
                                    IdUsuario = Convert.ToInt32(DR["IdUsuario"]),
                                    UsuarioNombre = DR["UsuarioNombre"].ToString(),
                                    FechaEntrega = DR["FechaEntrega"].ToString(),
                                    ComisionEntregaTardia = Convert.ToInt32(DR["ComisionEntregaTardia"]),
                                    fechaRenta = DR["FechaRenta"].ToString(),
                                    Estado = Convert.ToBoolean(DR["Estado"]),
                            }); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                lista = new List<RentasLibros>();
            }
            return lista;
        }



        public int RegistrarRenta(RentasLibros datosRenta, out string mensaje)
        {
            mensaje = string.Empty;
            int trans = 0;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_registrarRenta", oConexion);
                    cmd.Parameters.AddWithValue("@IdLibro", datosRenta.IdLibro);
                    cmd.Parameters.AddWithValue("@IdUsuario", datosRenta.IdUsuario);
                    cmd.Parameters.AddWithValue("@FechaEntrega", datosRenta.FechaEntrega);
                    cmd.Parameters.AddWithValue("@ComisionEntregaTardia", datosRenta.ComisionEntregaTardia);
                    cmd.Parameters.AddWithValue("@Estado", 1);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@Mensaje"].Value.ToString() == "Este libro ya se encuentra rentado")
                    {
                        trans = 0;
                        mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    } else
                    {
                        trans = 1;
                        mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return trans;
        }


        public int ActualizarRenta(RentasLibros datosRenta, out string mensaje)
        {
            mensaje = string.Empty;
            int trans = 0;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarRenta", oConexion);
                    cmd.Parameters.AddWithValue("@IdRenta", datosRenta.IdRenta);
                    cmd.Parameters.AddWithValue("@IdLibro", datosRenta.IdLibro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                }
                    mensaje = "Renta actualizada correctamente";
                    trans = 1;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return trans;
        }
    }
}
