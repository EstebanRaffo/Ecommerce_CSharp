using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet (Name = "GetUsuario")]
        public IEnumerable<Usuario> Usuarios()
        {
            return UsuarioBussiness.ListarUsuarios();
        }

        [HttpPut (Name = "ModificarUsuario")]
        public bool Put([FromBody] Usuario usuario)
        {
            int id = usuario.Id;
            return UsuarioBussiness.ModificarUsuario(id, usuario);
        }

    }

}
