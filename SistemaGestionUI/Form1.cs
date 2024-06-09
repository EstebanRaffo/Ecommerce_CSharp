using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class Form1 : Form
    {
        public int id;
        public int idProducto;
        public int idUsuario;
        public int idVenta;
        public int idProductoVendido;
        public string datosCargados;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        public void CargarProductos()
        {
            comboBox1.SelectedIndex = 0;
            idProducto = 0;
            dgvEntidad.AutoGenerateColumns = true;
            dgvEntidad.DataSource = ProductoBussiness.GetProductos();
            datosCargados = "Productos";
        }
        /*
        public void CargarUsuarios()
        {
            comboBox1.SelectedIndex = 1;
            idUsuario = 0;
            dgvEntidad.AutoGenerateColumns = true;
            dgvEntidad.DataSource = GestorDB.ListarUsuarios();
            datosCargados = "Usuarios";
        }

        public void CargarVentas()
        {
            comboBox1.SelectedIndex = 2;
            idVenta = 0;
            dgvEntidad.AutoGenerateColumns = true;
            dgvEntidad.DataSource = GestorDB.ListarVentas();
            datosCargados = "Ventas";
        }

        public void CargarProductosVendidos()
        {
            comboBox1.SelectedIndex = 3;
            idProductoVendido = 0;
            dgvEntidad.AutoGenerateColumns = true;
            dgvEntidad.DataSource = GestorDB.ListarProductosVendidos();
            datosCargados = "ProductosVendidos";
        }
        */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            switch (selectedValue)
            {
                case "Productos":
                    CargarProductos();
                    break;
                /*case "Usuarios":
                    CargarUsuarios();
                    break;
                case "Ventas":
                    CargarVentas();
                    break;
                case "ProductosVendidos":
                    CargarProductosVendidos();
                    break;*/
                default:
                    CargarProductos();
                    break;
            }
        }

        private void dgvEntidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int filaSeleccionada = (int)e.RowIndex;
                id = int.Parse(dgvEntidad[0, filaSeleccionada].Value.ToString());
                switch(datosCargados)
                {
                    case "Productos":
                        idProducto = id;
                        break;
                    case "Usuarios":
                        idUsuario = id;
                        break;
                    case "Ventas":
                        idVenta = id;
                        break;
                    case "ProductosVendidos":
                        idProductoVendido = id;
                        break;
                }
            }
            cargarForm();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            cargarForm();
        }

        private void cargarForm()
        {
            switch (datosCargados)
            {
                case "Productos":
                    ProductoForm productoForm = new ProductoForm();
                    Program.form1.Hide();
                    productoForm.Show();
                    break;
                /* case "Usuarios":
                    UsuarioForm usuarioForm = new UsuarioForm();
                    Program.form1.Hide();
                    usuarioForm.Show();
                    break;
                case "Ventas":
                    VentaForm ventaForm = new VentaForm();
                    Program.form1.Hide();
                    ventaForm.Show();
                    break;
                case "ProductosVendidos":
                    ProductoVendidoForm productoVendidoForm = new ProductoVendidoForm();
                    Program.form1.Hide();
                    productoVendidoForm.Show();
                    break;*/
            }
        }
    }
}
