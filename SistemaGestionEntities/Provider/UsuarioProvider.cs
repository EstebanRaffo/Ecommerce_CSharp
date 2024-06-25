using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Provider
{
    public class UsuarioProvider : AbstractProvider
    {
        private string _recurso;

        public UsuarioProvider() : base()
        {
            _recurso = "Usuario";
        }

        public Usuario ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            try
            {
                return base.GetJson<Usuario>($"{_recurso}/{usuario}/{password}");

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo authenticar el usuario", ex);
            }
        }
    }
}
