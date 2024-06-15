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

        [HttpPost ("{IdUsuario}", Name = "CargarVenta")]
        public bool Post([FromBody] List<Producto> productos, int IdUsuario)
        {
            Venta nueva_venta = new Venta();
            nueva_venta.IdUsuario = IdUsuario;
            nueva_venta.Comentarios = "Venta realizada";
            if (VentaBussiness.CrearVenta(nueva_venta))
            {
                List<Venta> ventas = VentaBussiness.ObtenerVentas();
                Venta ultima = ventas[ventas.Count - 1];
                int idVenta = ultima.Id;
                foreach (Producto producto in productos)
                {
                    Producto productoEncontrado = ProductoBussiness.ObtenerProductoPorId(producto.Id);
                    if(productoEncontrado != null)
                    {
                        ProductoVendido producto_vendido = new ProductoVendido(producto.Id, producto.Stock, idVenta);
                        if (ProductoVendidoBussiness.CrearProductoVendido(producto_vendido))
                        {
                            Producto productoToEdit = ProductoBussiness.ObtenerProductoPorId(producto.Id);
                            productoToEdit.Stock -= producto.Stock;
                            ProductoBussiness.ModificarProducto(producto.Id, productoToEdit);
                        }   
                    }
                }
                return true;
            }
            return false;
        }
    }
}
