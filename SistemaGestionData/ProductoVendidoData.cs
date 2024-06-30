using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
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
                        return new ProductoVendido(prodId, stock, idProducto, idVenta);
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
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
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
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                return productosVendidos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool ModificarProductoVendido(int id, ProductoVendido productoVendido)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarProductoVendido(int id)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static List<ProductoVendido> ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT pv.* FROM ProductoVendido pv INNER JOIN Venta v ON pv.IdVenta = v.Id WHERE v.IdUsuario = @idUsuario";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("idUsuario", idUsuario);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                return productosVendidos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
