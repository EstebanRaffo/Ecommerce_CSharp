using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionData;
using SistemaGestionEntities;
using System.Net;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet (Name = "GetUsuarios")]
        public IEnumerable<Usuario> Usuarios()
        {
            return UsuarioBussiness.ListarUsuarios();
        }

        [HttpGet ("{id}", Name = "GetUsuario")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = UsuarioBussiness.ObtenerUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpGet("{id}/nombre", Name = "GetNombreUsuario")]
        public IActionResult ObtenerNombreUsuarioPorId(int id) 
        {
            Usuario usuario = UsuarioBussiness.ObtenerUsuarioPorId(id);
            return Ok(usuario.Nombre);
        }

        [HttpPost (Name = "CrearUsuario")]
        public bool Post([FromBody] Usuario usuario)
        {
            return UsuarioBussiness.CrearUsuario(usuario);
        }

        [HttpPut (Name = "ModificarUsuario")]
        public bool Put([FromBody] Usuario usuario)
        {
            int id = usuario.Id;
            return UsuarioBussiness.ModificarUsuario(id, usuario);
        }

        [HttpDelete (Name = "EliminarUsuario")]
        public string Delete([FromBody] int id)
        {
            // Buscar las ventas del usuario y eliminarlas
            List<Venta> ventas = VentaBussiness.ObtenerVentas();
            List<Venta> ventas_del_usuario = ventas.FindAll(x => x.IdUsuario == id);
            if(ventas_del_usuario.Count > 0)
            {
                foreach (Venta venta in ventas_del_usuario)
                {
                    List<ProductoVendido> producto_vendidos = ProductoVendidoBussiness.ObtenerProductosVendidos();
                    List<ProductoVendido> items_de_la_venta = producto_vendidos.FindAll(x => x.IdVenta == venta.Id);
                    if(items_de_la_venta.Count > 0)
                    {
                        foreach (ProductoVendido item in items_de_la_venta)
                        {
                            if (ProductoVendidoBussiness.EliminarProductoVendido(item.Id))
                            {
                                Producto producto = ProductoBussiness.ObtenerProductoPorId(item.IdProducto);
                                if(producto.IdUsuario == id)
                                {
                                    ProductoBussiness.EliminarProducto(item.IdProducto);
                                }
                                else
                                {
                                    producto.Stock += item.Stock;
                                    ProductoBussiness.ModificarProducto(item.IdProducto, producto);
                                }
                            }
                        }
                    }
                    VentaBussiness.EliminarVenta(venta.Id);
                }
            }

            if (UsuarioBussiness.EliminarUsuario(id))
            {
                return "Usuario eliminado";
            }
            else
            {
                return "No se pudo eliminar el usuario";
            }
        }

        [HttpGet("{usuario}/{password}")]
        public ActionResult<Usuario> ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                return base.BadRequest(new { message = "El usuario o el password no puede ser una cadena de caracteres vacia o con espacios", status = HttpStatusCode.BadRequest });
            }

            try
            {
                return UsuarioBussiness.ObtenerUsuarioPorUsuarioYPassword(usuario, password);
            }
            catch
            {
                return base.Unauthorized(new { message = "No se pudo obtener un usuario en base a los datos proporcionados", status = HttpStatusCode.Unauthorized });
            }

        }
    }
}
