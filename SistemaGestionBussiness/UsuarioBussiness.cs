using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public class UsuarioBussiness
    {
        public static Usuario ObtenerUsuarioPorId(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static bool CrearUsuario(Usuario usuario)
        {
            return UsuarioData.CrearUsuario(usuario);
        }
        public static bool ModificarUsuario(int id, Usuario usuario)
        {
            return UsuarioData.ModificarUsuario(id, usuario);
        }
        public static bool EliminarUsuario(int id)
        {
            return UsuarioData.EliminarUsuario(id);
        }
    }
}
