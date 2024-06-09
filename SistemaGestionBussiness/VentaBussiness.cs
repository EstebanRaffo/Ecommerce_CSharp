using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBussiness
{
    public class VentaBussiness
    {
        public static Venta ObtenerVentaPorId(int id)
        {
            return VentaData.ObtenerVenta(id);
        }
        public static List<Venta> ObtenerVentas()
        {
            return VentaData.ListarVentas();
        }
        public static bool CrearVenta(Venta venta)
        {
            return VentaData.CrearVenta(venta);
        }
        public static bool ModificarVenta(int id, Venta venta)
        {
            return VentaData.ModificarVenta(id, venta);
        }
        public static bool EliminarVenta(int id)
        {
            return VentaData.EliminarVenta(id);
        }
    }
}
