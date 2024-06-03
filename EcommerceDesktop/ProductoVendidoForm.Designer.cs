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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            txtIdUsuario = new TextBox();
            label6 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(199, 261);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 32;
            button3.Text = "Borrar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(118, 261);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 31;
            button2.Text = "Guardar";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(37, 261);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 30;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(151, 199);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new Size(100, 23);
            txtIdUsuario.TabIndex = 29;
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
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(151, 96);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 27;
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
            // textBox1
            // 
            textBox1.Location = new Point(150, 144);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 34;
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
            ClientSize = new Size(315, 301);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtIdUsuario);
            Controls.Add(label6);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "ProductoVendidoForm";
            Text = "ProductoVendidoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox txtIdUsuario;
        private Label label6;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
    }
}