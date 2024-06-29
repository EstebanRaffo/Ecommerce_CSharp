using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionData;
using SistemaGestionEntities;
using System.Net;

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
        public IActionResult Post(int IdUsuario, [FromBody] List<Producto> productos)
        {
            if (productos.Count == 0)
            {
                return base.BadRequest(new { message = "No se puede realizar una venta sin productos", status = HttpStatusCode.BadRequest });
            }
            try 
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
                    return base.Accepted(new { message = "Venta realizada con exito", status = HttpStatusCode.Accepted });
                }
                else
                {
                    return base.Conflict(new { message = "No se pudo realizar la venta", status = HttpStatusCode.Conflict });
                }
            }
            catch(Exception ex)
            {
                return base.Conflict(new { message = ex.Message, status = HttpStatusCode.Conflict });
            }
        }

        [HttpDelete (Name = "EliminarVenta")]
        public string Delete([FromBody] int id)
        {
            List<ProductoVendido> producto_vendidos = ProductoVendidoBussiness.ObtenerProductosVendidos();
            List<ProductoVendido> items_de_la_venta = producto_vendidos.FindAll(x => x.IdVenta == id);
            if(items_de_la_venta.Count > 0)
            {
                foreach (ProductoVendido item in items_de_la_venta)
                {
                    if (ProductoVendidoBussiness.EliminarProductoVendido(item.Id))
                    {
                        Producto productoToEdit = ProductoBussiness.ObtenerProductoPorId(item.IdProducto);
                        productoToEdit.Stock += item.Stock;
                        ProductoBussiness.ModificarProducto(item.IdProducto, productoToEdit);
                    }
                }
            }
            if (VentaBussiness.EliminarVenta(id))
            {
                return "Venta eliminada";
            }
            else
            {
                return "No se pudo eliminar la venta";
            }
        }

        [HttpGet("{idUsuario}", Name = "ObtenerVentaPorUsuario")]
        public ActionResult<List<Venta>> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            if (idUsuario < 0)
            {
                return base.BadRequest(new { mensaje = "el id no puede ser negativo", status = HttpStatusCode.BadRequest });
            }

            try
            {
                return VentaBussiness.ObtenerVentasPorIdUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                return base.Conflict(new { message = ex.Message, status = HttpStatusCode.Conflict });
            }
        }
    }
}
