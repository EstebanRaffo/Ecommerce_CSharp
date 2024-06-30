using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionData;
using SistemaGestionEntities;
using System.Net;

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

        [HttpPost(Name = "CrearProductoVendido")]
        public bool Post([FromBody] ProductoVendido productoVendido)
        {
            return ProductoVendidoBussiness.CrearProductoVendido(productoVendido);
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendido>> ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            if (idUsuario < 0)
            {
                return base.BadRequest(new { message = "el id no puede ser negativo", status = HttpStatusCode.BadRequest });
            }
            try
            {
                return ProductoVendidoBussiness.ObtenerProductosVendidosPorIdUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                return base.Conflict(new { message = ex.Message, status = HttpStatusCode.Conflict });
            }
        }
    }
}
