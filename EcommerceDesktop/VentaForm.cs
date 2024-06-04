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
using static System.Net.Mime.MediaTypeNames;

namespace EcommerceDesktop
{
    public partial class VentaForm : Form
    {
        public VentaForm()
        {
            InitializeComponent();
        }

        private void VentaForm_Load(object sender, EventArgs e)
        {
            int idVenta = Program.form1.idVenta;
            if (idVenta > 0)
            {
                VentaData venta = GestorDB.ObtenerVenta(idVenta);
                txtId.Text = venta.Id.ToString();
                txtComentarios.Text = venta.Comentarios;
                txtIdUsuario.Text = venta.IdUsuario.ToString();
            }
            else
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtId.Text = "";
            txtComentarios.Text = "";
            txtIdUsuario.Text = "";
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarVentas();
            Program.form1.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string comentarios = txtComentarios.Text;
            string idUsuario = txtIdUsuario.Text;
            int idVenta = Program.form1.id;

            if (idVenta > 0)
            {
                VentaData ventaEdit = GestorDB.ObtenerVenta(idVenta);
                ventaEdit.Comentarios = comentarios;
                ventaEdit.IdUsuario = int.Parse(idUsuario);
                if (GestorDB.ModificarVenta(idVenta, ventaEdit))
                    MessageBox.Show("Venta actualizada");
                else
                    MessageBox.Show("No se pudo actualizar la venta");
            }
            else
            {
                VentaData newVenta = new VentaData();
                newVenta.Comentarios = comentarios;
                newVenta.IdUsuario = int.Parse(idUsuario);
                if (GestorDB.CrearVenta(newVenta))
                    MessageBox.Show("Venta guardada");
                else
                    MessageBox.Show("No se pudo guardar la venta");
            }
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarVentas();
            Program.form1.Show();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (GestorDB.EliminarVenta(Convert.ToInt32(id)))
                MessageBox.Show("Venta eliminada");
            else
                MessageBox.Show("No se pudo borrar la venta");
            limpiar();
            Program.form1.id = 0;
            this.Close();
            Program.form1.CargarVentas();
            Program.form1.Show();
        }
    }
}
