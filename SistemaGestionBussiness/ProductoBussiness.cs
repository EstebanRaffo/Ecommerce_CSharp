using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoBussiness
    {
        public static Producto ObtenerProductoPorId(int id)
        {
            return ProductoData.GetProducto(id);
        }
        public static List<Producto> ObtenerProductos()
        {
            return ProductoData.GetProductos();
        }
        public static bool CrearProducto(Producto producto)
        {
            return ProductoData.CrearProducto(producto);
        }
        public static bool ModificarProducto(int id, Producto producto)
        {
            return ProductoData.ModificarProducto(id, producto);
        }
        public static bool EliminarProducto(int id)
        {
            return ProductoData.EliminarProducto(id);
        }
    }
}
