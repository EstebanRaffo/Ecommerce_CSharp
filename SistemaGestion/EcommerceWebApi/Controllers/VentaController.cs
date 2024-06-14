using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        [HttpGet (Name = "GetVentas")]
        public IEnumerable<Venta> Ventas()
        {
            return VentaBussiness.ObtenerVentas();
        }

        [HttpPost (Name = "CargarVenta")]
        public bool Post([FromBody] List<Producto> productos, [FromBody] int usuario_id)
        {
            Venta nueva_venta = new Venta("venta", usuario_id);
            if (VentaBussiness.CrearVenta(nueva_venta))
            {
                List<Venta> ventas = VentaBussiness.ObtenerVentas();
                Venta ultima = ventas[ventas.Count - 1];
                int venta_id = ultima.Id;
                foreach (Producto producto in productos)
                {
                    ProductoVendido producto_vendido = new ProductoVendido(producto.Id, producto.Stock, venta_id);
                    ProductoVendidoBussiness.CrearProductoVendido(producto_vendido);
                    Producto productoToEdit = ProductoBussiness.ObtenerProductoPorId(producto.Id);
                    productoToEdit.Stock -= producto.Stock;
                    ProductoBussiness.ModificarProducto(producto.Id, productoToEdit);
                }
                return true;
            }
            return false;
        }
    }
}
