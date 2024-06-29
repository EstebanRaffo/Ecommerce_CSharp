using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionData;
using SistemaGestionEntities;
using System.Net;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        [HttpGet (Name = "GetProductos")]
        public IEnumerable<Producto> Productos()
        {
            return ProductoBussiness.ObtenerProductos();
        }

        [HttpPost (Name = "CrearProducto")]
        public bool Post([FromBody] Producto producto)
        {
            return ProductoBussiness.CrearProducto(producto);
        }

        [HttpPut (Name = "ModificarProducto")]
        public bool Put([FromBody] Producto producto)
        {
            int id = producto.Id;
            return ProductoBussiness.ModificarProducto(id, producto);
        }

        [HttpDelete("{idProducto}")]
        public IActionResult BorrarProductoPorId(int idProducto)
        {
            if (idProducto < 0)
            {
                return base.BadRequest(new { message = "el id no puede ser negativo", status = HttpStatusCode.BadRequest });
            }
            try
            {
                List<ProductoVendido> producto_vendidos = ProductoVendidoBussiness.ObtenerProductosVendidos();
                List<ProductoVendido> items_vendidos = producto_vendidos.FindAll(x => x.IdProducto == idProducto);
                if (items_vendidos.Count > 0)
                {
                    foreach (ProductoVendido item in items_vendidos)
                    {
                        ProductoVendidoBussiness.EliminarProductoVendido(item.Id);
                    }
                }
                ProductoBussiness.EliminarProducto(idProducto);
                IActionResult result = base.Accepted(new { mensaje = "Producto eliminado con exito", status = HttpStatusCode.Accepted });
                return result;  
            }
            catch (Exception ex)
            {
                return base.Conflict(new { message = ex.Message, status = HttpStatusCode.Conflict });
            }
        }

        [HttpDelete (Name = "EliminarProducto")]
        public string Delete([FromBody] int id)
        {
            List<ProductoVendido> producto_vendidos = ProductoVendidoBussiness.ObtenerProductosVendidos();
            List<ProductoVendido> items_vendidos = producto_vendidos.FindAll(x => x.IdProducto == id);
            if(items_vendidos.Count > 0)
            {
                foreach (ProductoVendido item in items_vendidos)
                {
                    ProductoVendidoBussiness.EliminarProductoVendido(item.Id);
                }
            }
            if (ProductoBussiness.EliminarProducto(id))
            {
                return "Producto eliminado";
            }
            else
            {
                return "No se pudo eliminar el producto";
            }
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<Producto>> ObtenerProductosPorIdDeUsuario(int idUsuario)
        {
            if (idUsuario < 0)
            {
                return base.BadRequest(new { message = "el id no puede ser negativo", status = HttpStatusCode.BadRequest });
            }
            try
            {
                return ProductoBussiness.ObtenerProductosPorIdDeUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                return base.Conflict(new { message = ex.Message, status = HttpStatusCode.Conflict });
            }
        }
    }
}
