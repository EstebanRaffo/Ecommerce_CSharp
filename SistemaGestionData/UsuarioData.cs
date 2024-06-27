using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        public static Usuario ObtenerUsuario(int id)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Usuario WHERE id = @id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader[0]);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string nombreUsuario = reader.GetString(3);
                        string password = reader.GetString(4);
                        string email = reader.GetString(5);

                        Usuario usuario = new Usuario(userId, nombre, apellido, nombreUsuario, password, email);

                        return usuario;
                    }
                    throw new Exception("Id no fue encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Usuario";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Password = dataReader["Contraseña"].ToString();
                                usuario.Email = dataReader["Mail"].ToString();

                                listaUsuarios.Add(usuario);
                            }
                        }
                    }
                }
                return listaUsuarios;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearUsuario(Usuario usuario)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Usuario(nombre, apellido,nombreUsuario,contraseña,mail) values(@nombre, @apellido,@nombreUsuario,@password,@email)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("password", usuario.Password);
                    command.Parameters.AddWithValue("email", usuario.Email);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarUsuario(int id, Usuario usuario)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Usuario SET nombre = @nombre, apellido = @apellido, nombreUsuario= @nombreUsuario, contraseña = @password, mail = @email WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("password", usuario.Password);
                    command.Parameters.AddWithValue("email", usuario.Email);
                    //Id que esta en el WHERE
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarUsuario(int id)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Usuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static Usuario ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Usuario WHERE NombreUsuario = @usuario AND Contraseña = @password";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("usuario", usuario);
                    command.Parameters.AddWithValue("password", password);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader[0]);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string nombreUsuario = reader.GetString(3);
                        string pass = reader.GetString(4);
                        string email = reader.GetString(5);

                        Usuario user = new Usuario(userId, nombre, apellido, nombreUsuario, pass, email);

                        return user;
                    }
                    throw new Exception("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static Usuario ObtenerUsuarioPorNombreDeUsuario(string usuario)
        {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Usuario WHERE NombreUsuario = @usuario";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("usuario", usuario);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader[0]);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        string nombreUsuario = reader.GetString(3);
                        string pass = reader.GetString(4);
                        string email = reader.GetString(5);

                        Usuario user = new Usuario(userId, nombre, apellido, nombreUsuario, pass, email);

                        return user;
                    }
                    throw new Exception("Usuario no encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
