using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcommerceDesktop.Database;
using EcommerceDesktop.Models;

namespace EcommerceDesktop
{
    public partial class ProductoForm : Form
    {
        public ProductoForm()
        {
            InitializeComponent();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            int idProducto = Program.form1.idProducto;
            if (idProducto > 0) { 
                ProductoData producto = GestorDB.ObtenerProducto(idProducto);
                textId.Text = producto.Id.ToString();
                textCosto.Text = producto.Costo.ToString();
                textDescripcion.Text = producto.Descripcion;
                textStock.Text = producto.Stock.ToString();
                textIdUsuario.Text = producto.IdUsuario.ToString();
                textPrecio.Text = producto.PrecioVenta.ToString();
            }
            else {                 
                limpiar();
            }
        }

        private void limpiar()
        {
            textId.Text = "";
            textCosto.Text = "";
            textDescripcion.Text = "";
            textStock.Text = "";
            textIdUsuario.Text = "";
            textPrecio.Text = "";
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarProductos();
            Program.form1.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string costo = textCosto.Text;
            string descripcion = textDescripcion.Text;
            string stock = textStock.Text;
            string idUsuario = textIdUsuario.Text;
            string precioVenta = textPrecio.Text;

            int idProducto = Program.form1.id;

            if (idProducto > 0)
            {
                ProductoData productoEdit = GestorDB.ObtenerProducto(idProducto);

                productoEdit.PrecioVenta = double.Parse(precioVenta);
                productoEdit.Descripcion = descripcion;
                productoEdit.Costo = double.Parse(costo);
                productoEdit.IdUsuario = int.Parse(idUsuario);
                productoEdit.Stock = int.Parse(stock);

                if (GestorDB.ModificarProducto(idProducto, productoEdit))
                    MessageBox.Show("Producto actualizado");
                else
                    MessageBox.Show("No se pudo actualizar el producto");
            }
            else
            {
                ProductoData newProducto = new ProductoData();

                newProducto.PrecioVenta = double.Parse(precioVenta);
                newProducto.Descripcion = descripcion;
                newProducto.Costo = double.Parse(costo);
                newProducto.Stock = int.Parse(stock);
                newProducto.IdUsuario = int.Parse(idUsuario);

                if (GestorDB.CrearProducto(newProducto))
                    MessageBox.Show("Producto creado");
                else
                    MessageBox.Show("No se pudo crear el producto");
            }
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarProductos();
            Program.form1.Show();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string id = textId.Text;

            if (GestorDB.EliminarProducto(Convert.ToInt32(id)))
                MessageBox.Show("Producto eliminado");
            else
                MessageBox.Show("No se pudo borrar el Producto");
            limpiar();
            Program.form1.id = 0;
            this.Close();
            Program.form1.CargarProductos();
            Program.form1.Show();
        }
    }
}
