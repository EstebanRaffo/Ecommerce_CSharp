using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDesktop.Models;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace EcommerceDesktop.Database
{
    internal class GestorDB
    {
        public static UsuarioData ObtenerUsuario(int id) {
            
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

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

                    UsuarioData usuario = new UsuarioData(userId, nombre, apellido, nombreUsuario, password, email);

                    return usuario;
                }
                throw new Exception("Id no fue encontrado");
            }
        }
        public static List<UsuarioData> ListarUsuarios() {
            List<UsuarioData> listaUsuarios = new List<UsuarioData>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

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
                            UsuarioData usuario = new UsuarioData();
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
        public static bool CrearUsuario(UsuarioData usuario) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";
            
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
        public static bool ModificarUsuario(int id, UsuarioData usuario) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

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
        public static bool EliminarUsuario(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static ProductoData ObtenerProducto(int id) { }
        public static List<ProductoData> ListarProductos() { }
        public static bool CrearProducto(ProductoData producto) { }
        public static bool ModificarProducto(int id, ProductoData producto) { }
        public static bool EliminarProducto(int id) { }

        public static ProductoVendidoData ObtenerProductoVendido(int id) { }
        public static List<ProductoVendidoData> ListarProductosVendidos() { }
        public static bool CrearProductoVendido(ProductoVendidoData productoVendido) { }
        public static bool ModificarProductoVendido(int id, ProductoVendidoData productoVendido) { }
        public static bool EliminarProductoVendido(int id) { }

        public static VentaData ObtenerVenta(int id) { }
        public static List<VentaData> ListarVentas() { }
        public static bool CrearVenta(VentaData venta) { }
        public static bool ModificarVenta(int id, VentaData venta) { }
        public static bool EliminarVenta(int id) { }
    }
}
