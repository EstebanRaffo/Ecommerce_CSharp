using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public class ProductoVendidoBussiness
    {
        public static ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }
        public static List<ProductoVendido> ObtenerProductosVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }
        public static bool CrearProductoVendido(ProductoVendido productoVendido) 
        { 
            return ProductoVendidoData.CrearProductoVendido(productoVendido);
        }
        public static bool ModificarProductoVendido(int id, ProductoVendido productoVendido) 
        { 
            return ProductoVendidoData.ModificarProductoVendido(id, productoVendido);
        }
        public static bool EliminarProductoVendido(int id) 
        { 
            return ProductoVendidoData.EliminarProductoVendido(id);
        }
    }
}
