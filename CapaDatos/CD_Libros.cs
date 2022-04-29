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
                    string query = "select * from vw_libros";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader DR = cmd.ExecuteReader() )
                    {
                        while (DR.Read() )
                        {
                            lista.Add
                                (
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
                                        RutaImagen = DR["RutaImagen"].ToString(),
                                        NombreImagen = DR ["NombreImagen"].ToString()
                                    }
                                ); 
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
                                    RutaImagen = DR["RutaImagen"].ToString(),
                                    NombreImagen = DR["NombreImagen"].ToString()

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

                    StringBuilder sb = new StringBuilder(); // (SignaturaTopografica, Nombre, ISB, BibliografiaId, Autores, Descripcion, Ciencia, Editora, Estado,Idioma, year) 
                    sb.Append("INSERT INTO Libros ( SignaturaTopografica, Nombre, ISBN, Descripcion, AutorId , ");
                    sb.Append("BibliografiaId, CienciaId, EditoraId, IdiomaId, year, Estado)");
                    sb.Append("VALUES ( @SignaturaTopografica, @Nombre, @ISBN, @Descripcion, @AutorId" +
                         ", @BibliografiaId, @CienciaId, @EditoraId, @IdiomaId, @year, @Estado); ");
                    sb.Append("SELECT  CAST(scope_identity() AS int);");

                    //sb.Append("DECLARE @ID INT OUTPUT; SET @ID=SCOPE_IDENTITY()");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@SignaturaTopografica", libro.SignaturaTopografica);
                        cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                        cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                        cmd.Parameters.AddWithValue("@Descripcion", libro.Descripcion);
                        cmd.Parameters.AddWithValue("@AutorId", libro.AutorId); //FK
                        cmd.Parameters.AddWithValue("@BibliografiaId", libro.BibliografiaId); //FK
                        cmd.Parameters.AddWithValue("@CienciaId", libro.CienciaId); //FK
                        cmd.Parameters.AddWithValue("@EditoraId", libro.EditoraId); //FK
                        cmd.Parameters.AddWithValue("@IdiomaId", libro.IdiomaId); //FK
                        cmd.Parameters.AddWithValue("@year", libro.year);
                        cmd.Parameters.AddWithValue("@Estado", libro.Estado);

                        oConexion.Open();
                        idAutoGenerado = (int) cmd.ExecuteScalar();
                        //cmd.ExecuteNonQuery();
                        oConexion.Close();

                    }

                    //oConexion.Open();

                    //cmd.ExecuteNonQuery();

                    //idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = "Registro insertado exitosamente!";

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
                    sb.Append("ISBN = @ISBN,");
                    sb.Append("Descripcion = @Descripcion,");
                    sb.Append("AutorId = @AutorId,");
                    sb.Append("BibliografiaId = @BibliografiaId,");
                    sb.Append("CienciaId = @CienciaId,");
                    sb.Append("EditoraId = @EditoraId,");
                    sb.Append("IdiomaId = @IdiomaId,");
                    sb.Append("year = @year, ");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@SignaturaTopografica", libro.SignaturaTopografica);
                        cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                        cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                        cmd.Parameters.AddWithValue("@Descripcion", libro.Descripcion);
                        cmd.Parameters.AddWithValue("@AutorId", libro.AutorId);
                        cmd.Parameters.AddWithValue("@BibliografiaId", libro.BibliografiaId);
                        cmd.Parameters.AddWithValue("@CienciaId", libro.CienciaId);
                        cmd.Parameters.AddWithValue("@EditoraId", libro.EditoraId);
                        cmd.Parameters.AddWithValue("@IdiomaId", libro.IdiomaId);
                        cmd.Parameters.AddWithValue("@year", libro.year);
                        cmd.Parameters.AddWithValue("@Estado", libro.Estado);
                        cmd.Parameters.AddWithValue("@Id", libro.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }
                }

                Mensaje = "Registro actualizado exitosamente!";
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }

            return resultado;
        }


        public bool GuardarDatosImagen(Libros libro, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "update libros SET RutaImagen = @RutaImagen, NombreImagen = @NombreImagen WHERE Id = @Id";
                    
                    SqlCommand cmd = new SqlCommand(query, oConexion);

                    cmd.Parameters.AddWithValue("@RutaImagen", libro.RutaImagen);
                    cmd.Parameters.AddWithValue("@NombreImagen", libro.NombreImagen);
                    cmd.Parameters.AddWithValue("@Id", libro.Id);
                    
                    oConexion.Open();

                    if (cmd.ExecuteNonQuery() > 0 )
                    {
                        resultado = true;
                        Mensaje = "Registro insertado exitosamente!";
                    } 
                    else
                    {
                        Mensaje = "No se pudo cargar la imagen";
                    }
                   
                    oConexion.Close();
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
                    Mensaje = "Registro eliminado correctamente";

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
