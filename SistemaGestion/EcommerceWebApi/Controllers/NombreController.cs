using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public ActionResult<string> ObtenerNombreDelAlumno()
        {
            return "Esteban Raffo";
        }
    }
}
