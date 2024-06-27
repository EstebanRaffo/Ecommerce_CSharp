using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public class ProductoData
    {
        public static Producto GetProducto(int id)
        {
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
                        return new Producto(prodId, descripcion, costo, precio, stock, idUsuario);
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
        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
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
                                Producto producto = new Producto();
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
        public static bool CrearProducto(Producto producto)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarProducto(int id, Producto producto)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarProducto(int id)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<Producto> GetProductosPorIdUsuario(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Producto WHERE IdUsuario = @idUsuario";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("idUsuario", idUsuario);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
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
    }
}
