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

                        UsuarioData usuario = new UsuarioData(userId, nombre, apellido, nombreUsuario, password, email);

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
        public static List<UsuarioData> ListarUsuarios() {
            List<UsuarioData> listaUsuarios = new List<UsuarioData>();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearUsuario(UsuarioData usuario) {
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
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarUsuario(int id, UsuarioData usuario) {
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
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarUsuario(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try { 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Usuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static ProductoData ObtenerProducto(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Producto WHERE Id = @id";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("id", id);
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int prodId = Convert.ToInt32(reader[0]);
                        string descripcion = reader.GetString(1);
                        double costo = Convert.ToDouble(reader[2]);
                        double precio = Convert.ToDouble(reader[3]);
                        int stock = Convert.ToInt32(reader[4]);
                        int idUsuario = Convert.ToInt32(reader[5]);
                        return new ProductoData(prodId, descripcion, costo, precio, stock, idUsuario);
                    }
                    throw new Exception("Id no encontrado");
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<ProductoData> ListarProductos() {
            List<ProductoData> productos = new List<ProductoData>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Producto";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoData producto = new ProductoData();
                                producto.Id = Convert.ToInt32(reader["Id"]);
                                producto.Descripcion = reader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(reader["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                productos.Add(producto);
                            }
                        }
                    }
                }
                return productos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearProducto(ProductoData producto) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@nombre, @costo, @precio, @stock, @idUsuario)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("nombre", producto.Descripcion);
                    command.Parameters.AddWithValue("costo", producto.Costo);
                    command.Parameters.AddWithValue("precio", producto.PrecioVenta);
                    command.Parameters.AddWithValue("stock", producto.Stock);
                    command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                    conn.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarProducto(int id, ProductoData producto) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Producto SET Descripciones = @descripcion, Costo = @costo, PrecioVenta = @precio, Stock = @stock, IdUsuario = @idUsuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("costo", producto.Costo);
                    command.Parameters.AddWithValue("precio", producto.PrecioVenta);
                    command.Parameters.AddWithValue("stock", producto.Stock);
                    command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarProducto(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Producto WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static ProductoVendidoData ObtenerProductoVendido(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ProductoVendido WHERE Id = @id";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("id", id);
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int prodId = Convert.ToInt32(reader[0]);
                        int stock = Convert.ToInt32(reader[1]);
                        int idProducto = Convert.ToInt32(reader[2]);
                        int idVenta = Convert.ToInt32(reader[3]);
                        return new ProductoVendidoData(prodId, stock, idProducto, idVenta);
                    }
                    throw new Exception("Id no encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<ProductoVendidoData> ListarProductosVendidos() {
            List<ProductoVendidoData> productosVendidos = new List<ProductoVendidoData>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ProductoVendido";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoVendidoData productoVendido = new ProductoVendidoData();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                productoVendido.IdVenta= Convert.ToInt32(reader["IdVenta"]);
                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                return productosVendidos;
            }catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearProductoVendido(ProductoVendidoData productoVendido) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@stock, @idProducto, @idVenta)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);
                    conn.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarProductoVendido(int id, ProductoVendidoData productoVendido) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ProductoVendido SET Stock = @stock, IdProducto = @idProducto, IdVenta = @idVenta WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);
                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarProductoVendido(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static VentaData ObtenerVenta(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Venta WHERE Id = @id";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("id", id);
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int ventaId = Convert.ToInt32(reader[0]);
                        string comentarios = reader.GetString(1);
                        int idUsuario = Convert.ToInt32(reader[2]);
                        return new VentaData(ventaId, comentarios, idUsuario);
                    }
                    throw new Exception("Id no encontrado");
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<VentaData> ListarVentas() {
            List<VentaData> ventas = new List<VentaData>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Venta";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VentaData venta = new VentaData();
                                venta.Id = Convert.ToInt32(reader["Id"]);
                                venta.Comentarios = reader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                ventas.Add(venta);
                            }
                        }
                    }
                }
                return ventas;
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearVenta(VentaData venta) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentarios, @idUsuario)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                    conn.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarVenta(int id, VentaData venta) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Venta SET Comentarios = @comentarios, IdUsuario = @idUsuario WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarVenta(int id) {
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Venta WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
