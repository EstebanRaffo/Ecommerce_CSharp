using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class VentaData
    {
        public static Venta ObtenerVenta(int id)
        {
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
                        return new Venta(ventaId, comentarios, idUsuario);
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

        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();
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
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(reader["Id"]);
                                venta.Comentarios = reader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                ventas.Add(venta);
                            }
                        }
                    }
                }
                return ventas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool CrearVenta(Venta venta)
        {
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
        public static bool ModificarVenta(int id, Venta venta)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static bool EliminarVenta(int id)
        {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static List<Venta> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            string connectionString = @"Server=localhost\MSSQLSERVERC#;Database=SistemaGestion_c9;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Venta WHERE IdUsuario = @idUsuario";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("idUsuario", idUsuario);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(reader["Id"]);
                                venta.Comentarios = reader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                ventas.Add(venta);
                            }
                        }
                    }
                }
                return ventas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
