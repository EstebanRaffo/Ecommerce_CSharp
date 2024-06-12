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
        public bool Post([FromBody] Venta venta)
        {
            return VentaBussiness.CrearVenta(venta);
        }
    }
}
