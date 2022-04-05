using CapaEntidad;
using System.Data.SqlClient; //agregar
using System.Data; //agregar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn) )
                {
                    string query = "select Id, Nombre, Apellido, Correo, Clave, TipoUsuario, Cedula, NCarnet, TipoPersona, Estado, FechaRegistro  from USUARIOS";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader() )
                    {
                        while (dr.Read() )
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
                                    TipoPersona = Convert.ToInt32(dr["TipoUsuario"]),
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


        public int Registrar(Usuario usuario, out string Mensaje)
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
                    sb.Append("INSERT INTO Usuarios ( Nombre, Apellido, Correo, Clave, TipoUsuario, Cedula, NCarnet, TipoPersona, Estado) ");
                    sb.Append("VALUES ( @Nombre, @Apellido, @Correo, @Clave, @TipoUsuario, @Cedula, @NCarnet, @TipoPersona, @Estado)");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                        cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                        cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                        cmd.Parameters.AddWithValue("@NCarnet", usuario.NCarnet);
                        cmd.Parameters.AddWithValue("@TipoPersona", usuario.TipoPersona);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        idAutoGenerado = 1;
                        Mensaje = "Registro insertado exitosamente";
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

        public bool Editar(Usuario usuario, out string Mensaje)
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
                    sb.Append("UPDATE USUARIOS SET ");
                    sb.Append("Nombre = @Nombre,");
                    sb.Append("Apellido = @Apellido,");
                    sb.Append("Correo = @Correo,");
                    sb.Append("TipoUsuario = @TipoUsuario,");
                    sb.Append("Cedula = @Cedula,");
                    sb.Append("NCarnet = @NCarnet,");
                    sb.Append("TipoPersona = @TipoPersona,");
                    sb.Append("Estado = @Estado ");
                    sb.Append("WHERE Id = @Id");

                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                        cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                        cmd.Parameters.AddWithValue("@NCarnet", usuario.NCarnet);
                        cmd.Parameters.AddWithValue("@TipoPersona", usuario.TipoPersona);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);

                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        oConexion.Close();

                        resultado = true;
                    }
                }
                Mensaje = "Registro actualizado exitosamente";
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
                    SqlCommand cmd = new SqlCommand("delete top (1) from usuarios where Id = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    // EXECUTE NON QUERY DEVUELVE EL TOTAL DE FILAS AFECTADAS
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                Mensaje = "Registro eliminado exitosamente";
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
