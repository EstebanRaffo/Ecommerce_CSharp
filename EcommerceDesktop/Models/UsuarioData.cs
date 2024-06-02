using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDesktop.Models
{
    public class UsuarioData
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _password;
        private string _mail;

        public UsuarioData(int id, string nombre, string apellido, string nombreUsuario, string password, string mail)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._password = password;
            this._mail = mail;
        }

        public UsuarioData() { }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public string Apellido { get {  return this._apellido; } set { this._apellido = value; } }
        public string NombreUsuario { get { return this._nombreUsuario; } set { this._nombreUsuario = value; } }
        public string Password { get { return this._password; } set { this._password = value; } }
        public string Email { get { return this._mail; } set { this._mail = value; } }
    }
}
