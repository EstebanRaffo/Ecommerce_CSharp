using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : Controller
    {
        [HttpGet (Name = "GetProductosVendidos")]
        public IEnumerable<ProductoVendido> ProductosVendidos()
        {
            return ProductoVendidoBussiness.ObtenerProductosVendidos();
        }

        [HttpPost(Name = "CrearVenta")]
        public bool Post([FromBody] ProductoVendido productoVendido)
        {
            return ProductoVendidoBussiness.CrearProductoVendido(productoVendido);
        }
    }
}
