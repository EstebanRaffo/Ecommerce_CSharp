using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

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

        [HttpGet("{id}", Name = "GetProducto")]
        public IActionResult ObtenerProductoPorId(int id)
        {
            Producto producto = ProductoBussiness.ObtenerProductoPorId(id);
            return Ok(producto);
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

        [HttpDelete (Name = "EliminarProducto")]
        public string Delete(int id)
        {
            ProductoVendidoBussiness.EliminarProductoVendido(id);
            if (ProductoBussiness.EliminarProducto(id))
            {
                return "Producto eliminado";
            }
            else
            {
                return "Error al eliminar producto";
            }
        }
    }
}
