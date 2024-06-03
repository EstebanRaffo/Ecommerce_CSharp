using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDesktop.Models
{
    public class VentaData
    {
        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public VentaData(int id, string comentarios, int idUsuario)
        {
            this._id = id;
            this._comentarios = comentarios;
            this._idUsuario = idUsuario;
        }

        public VentaData() { }

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Comentarios { get {  return this._comentarios; } set { this._comentarios = value; } }
        public int IdUsuario { get {  return this._idUsuario; } set { this._idUsuario = value; } }
    }
}
