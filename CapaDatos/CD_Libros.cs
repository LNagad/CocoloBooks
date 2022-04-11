using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class CD_Libros
    {
        public List<Libros> Listar()
        {
            List<Libros> lista = new List<Libros>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection (Conexion.cn) )
                {
                    string query = "select Id,SignaturaTopografica,Nombre,ISB,BibliografiaId,Bibliografia,Autores,Descripcion,Ciencia,Editora,Estado,Idioma,year from vw_libros";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader() )
                    {
                        while (DR.Read() )
                        {
                            lista.Add(

                                new Libros()
                                {
                                    Id = Convert.ToInt32(DR["Id"]),
                                    SignaturaTopografica = DR["SignaturaTopografica"].ToString(),
                                    Nombre = DR["Nombre"].ToString(),
                                    ISB = Convert.ToDecimal(DR["ISB"]),
                                    BibliografiaId = Convert.ToInt32(DR["BibliografiaId"]),
                                    Bibliografia = DR["Bibliografia"].ToString(),
                                    Autores = DR["Autores"].ToString(),
                                    Descripcion = DR["Descripcion"].ToString(),
                                    Ciencia = DR["Ciencia"].ToString(),
                                    Editora = DR["Editora"].ToString(),
                                    Estado = Convert.ToBoolean(DR["Estado"]),
                                    Idioma = DR["Idioma"].ToString(),
                                    year = DR["year"].ToString(),

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


        public List<Libros> ListarSelected(int id)
        {
            List<Libros> lista = new List<Libros>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = $"select * from vw_libros WHERE Id = {id}";
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
                                    ISB = Convert.ToDecimal(DR["ISB"]),
                                    BibliografiaId = Convert.ToInt32(DR["BibliografiaId"]),
                                    Bibliografia = DR["Bibliografia"].ToString(),
                                    Autores = DR["Autores"].ToString(),
                                    Descripcion = DR["Descripcion"].ToString(),
                                    Ciencia = DR["Ciencia"].ToString(),
                                    Editora = DR["Editora"].ToString(),
                                    Estado = Convert.ToBoolean(DR["Estado"]),
                                    Idioma = DR["Idioma"].ToString(),
                                    year = DR["year"].ToString(),

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



        public int Registrar(Libros libro, out string Mensaje)
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
                     sb.Append("INSERT INTO Libros (SignaturaTopografica, Nombre, ISB, BibliografiaId, Autores, Descripcion, Ciencia, Editora, Estado,Idioma, year) ");
                     sb.Append("VALUES ( @SignaturaTopografica, @Nombre, @ISB, @BibliografiaId, @Autores, @Descripcion, @Ciencia, @Editora, @Estado, @Idioma, @year)");
                    
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@SignaturaTopografica", libro.SignaturaTopografica);
                        cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                        cmd.Parameters.AddWithValue("@ISB", libro.ISB);
                        cmd.Parameters.AddWithValue("@BibliografiaId", libro.BibliografiaId);
                        cmd.Parameters.AddWithValue("@Autores", libro.Autores);
                        cmd.Parameters.AddWithValue("@Descripcion", libro.Descripcion);
                        cmd.Parameters.AddWithValue("@Ciencia", libro.Ciencia);
                        cmd.Parameters.AddWithValue("@Editora", libro.Editora);
                        cmd.Parameters.AddWithValue("@Estado", libro.Estado);
                        cmd.Parameters.AddWithValue("@Idioma", libro.Idioma);
                        cmd.Parameters.AddWithValue("@year", libro.year);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        idAutoGenerado = 1;
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


        public bool Editar(Libros libro, out string Mensaje)
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
                    sb.Append("UPDATE Libros SET "); 
                    sb.Append("SignaturaTopografica = @SignaturaTopografica,");
                    sb.Append("Nombre = @Nombre,");
                    sb.Append("ISB = @ISB,");
                    sb.Append("BibliografiaId = @BibliografiaId,");
                    sb.Append("Autores = @Autores,");
                    sb.Append("Descripcion = @Descripcion,");
                    sb.Append("Ciencia = @Ciencia,");
                    sb.Append("Editora = @Editora,");
                    sb.Append("Estado = @Estado,");
                    sb.Append("Idioma = @Idioma,");
                    sb.Append("year = @year ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@SignaturaTopografica", libro.SignaturaTopografica);
                        cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                        cmd.Parameters.AddWithValue("@ISB", libro.ISB);
                        cmd.Parameters.AddWithValue("@BibliografiaId", libro.BibliografiaId);
                        cmd.Parameters.AddWithValue("@Autores", libro.Autores);
                        cmd.Parameters.AddWithValue("@Descripcion", libro.Descripcion);
                        cmd.Parameters.AddWithValue("@Ciencia", libro.Ciencia);
                        cmd.Parameters.AddWithValue("@Editora", libro.Editora);
                        cmd.Parameters.AddWithValue("@Estado", libro.Estado);
                        cmd.Parameters.AddWithValue("@Idioma", libro.Idioma);
                        cmd.Parameters.AddWithValue("@year", libro.year);
                        cmd.Parameters.AddWithValue("@Id", libro.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }
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
                    SqlCommand cmd = new SqlCommand($"delete from Libros where Id = {id}", oConexion);

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = true;
                    Mensaje = "Libro eliminado correctamente";

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
