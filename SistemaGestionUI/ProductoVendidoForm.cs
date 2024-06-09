using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class ProductoVendidoForm : Form
    {
        public ProductoVendidoForm()
        {
            InitializeComponent();
        }

        private void ProductoVendidoForm_Load(object sender, EventArgs e)
        {
            int idProductoVendido = Program.form1.idProductoVendido;
            if (idProductoVendido > 0)
            {
                ProductoVendido productoVendido = ProductoVendidoBussiness.ObtenerProductoVendidoPorId(idProductoVendido);
                txtId.Text = productoVendido.Id.ToString();
                txtStock.Text = productoVendido.Stock.ToString();
                txtIdProducto.Text = productoVendido.IdProducto.ToString();
                txtIdVenta.Text = productoVendido.IdVenta.ToString();
            }
            else
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtId.Text = "";
            txtStock.Text = "";
            txtIdProducto.Text = "";
            txtIdVenta.Text = "";
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarProductosVendidos();
            Program.form1.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string stock = txtStock.Text;
            string idProducto = txtIdProducto.Text;
            string idVenta = txtIdVenta.Text;
            int idProductoVendido = Program.form1.id;

            if (idProductoVendido > 0)
            {
                ProductoVendido productoVendidoEdit = ProductoVendidoBussiness.ObtenerProductoVendidoPorId(idProductoVendido);
                productoVendidoEdit.Stock = int.Parse(stock);
                productoVendidoEdit.IdProducto = int.Parse(idProducto);
                productoVendidoEdit.IdVenta = int.Parse(idVenta);

                if (ProductoVendidoBussiness.ModificarProductoVendido(idProductoVendido, productoVendidoEdit))
                {
                    MessageBox.Show("Producto vendido actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el producto vendido");
                }
            }
            else
            {
                ProductoVendido newProductoVendido = new ProductoVendido();
                newProductoVendido.Stock = int.Parse(stock);
                newProductoVendido.IdProducto = int.Parse(idProducto);
                newProductoVendido.IdVenta = int.Parse(idVenta);

                if (ProductoVendidoBussiness.CrearProductoVendido(newProductoVendido))
                {
                    MessageBox.Show("Producto vendido agregado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el producto vendido");
                }
            }
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarProductosVendidos();
            Program.form1.Show();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (ProductoVendidoBussiness.EliminarProductoVendido(Convert.ToInt32(id)))
                MessageBox.Show("Producto vendido eliminado");
            else
                MessageBox.Show("No se pudo borrar el Producto vendido");
            limpiar();
            Program.form1.id = 0;
            this.Close();
            Program.form1.CargarProductosVendidos();
            Program.form1.Show();
        }
    }
}
