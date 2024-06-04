namespace EcommerceDesktop
{
    partial class ProductoVendidoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonBorrar = new Button();
            buttonGuardar = new Button();
            buttonVolver = new Button();
            txtIdVenta = new TextBox();
            label6 = new Label();
            txtStock = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            txtIdProducto = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonBorrar
            // 
            buttonBorrar.Location = new Point(218, 261);
            buttonBorrar.Name = "buttonBorrar";
            buttonBorrar.Size = new Size(75, 23);
            buttonBorrar.TabIndex = 32;
            buttonBorrar.Text = "Borrar";
            buttonBorrar.UseVisualStyleBackColor = true;
            buttonBorrar.Click += buttonBorrar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(123, 261);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 31;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.TextAlign = ContentAlignment.BottomCenter;
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(26, 261);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 30;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // txtIdVenta
            // 
            txtIdVenta.Location = new Point(151, 199);
            txtIdVenta.Name = "txtIdVenta";
            txtIdVenta.Size = new Size(100, 23);
            txtIdVenta.TabIndex = 29;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 201);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 28;
            label6.Text = "Id Venta";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(151, 96);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 96);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 26;
            label2.Text = "Stock";
            // 
            // txtId
            // 
            txtId.Location = new Point(151, 48);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 48);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 24;
            label1.Text = "Id";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(150, 144);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.Size = new Size(100, 23);
            txtIdProducto.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 146);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 33;
            label3.Text = "Id Producto";
            // 
            // ProductoVendidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 311);
            Controls.Add(txtIdProducto);
            Controls.Add(label3);
            Controls.Add(buttonBorrar);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonVolver);
            Controls.Add(txtIdVenta);
            Controls.Add(label6);
            Controls.Add(txtStock);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "ProductoVendidoForm";
            Text = "ProductoVendidoForm";
            Load += ProductoVendidoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBorrar;
        private Button buttonGuardar;
        private Button buttonVolver;
        private TextBox txtIdVenta;
        private Label label6;
        private TextBox txtStock;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox txtIdProducto;
        private Label label3;
    }
}