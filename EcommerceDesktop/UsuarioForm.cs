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
    public partial class UsuarioForm : Form
    {
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            int idUsuario = Program.form1.idUsuario;
            if (idUsuario > 0)
            {
                UsuarioData usuario = GestorDB.ObtenerUsuario(idUsuario);
                txtId.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtPassword.Text = usuario.Password;
                txtEmail.Text = usuario.Email;
            }
            else
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarUsuarios();
            Program.form1.Show();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            int idUsuario = Program.form1.id;

            if (idUsuario > 0)
            {
                UsuarioData usuarioEdit = GestorDB.ObtenerUsuario(idUsuario);
                usuarioEdit.Nombre = nombre;
                usuarioEdit.Apellido = apellido;
                usuarioEdit.NombreUsuario = nombreUsuario;
                usuarioEdit.Password = password;
                usuarioEdit.Email = email;

                if (GestorDB.ModificarUsuario(idUsuario, usuarioEdit))
                {
                    MessageBox.Show("Usuario modificado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el usuario");
                }
            }
            else
            {
                UsuarioData newUsuario = new UsuarioData();
                newUsuario.Nombre = nombre;
                newUsuario.Apellido = apellido;
                newUsuario.NombreUsuario = nombreUsuario;
                newUsuario.Password = password;
                newUsuario.Email = email;

                if (GestorDB.CrearUsuario(newUsuario))
                {
                    MessageBox.Show("Usuario creado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo crear el usuario");
                }
            }
            limpiar();
            this.Close();
            Program.form1.id = 0;
            Program.form1.CargarUsuarios();
            Program.form1.Show();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (GestorDB.EliminarUsuario(Convert.ToInt32(id)))
                MessageBox.Show("Usuario eliminado");
            else
                MessageBox.Show("No se pudo borrar el Usuario");
            limpiar();
            Program.form1.id = 0;
            this.Close();
            Program.form1.CargarUsuarios();
            Program.form1.Show();
        }
    }
}
