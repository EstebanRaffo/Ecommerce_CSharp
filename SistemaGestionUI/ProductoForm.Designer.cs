namespace SistemaGestionUI
{
    partial class ProductoForm
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
            label1 = new Label();
            textId = new TextBox();
            textDescripcion = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textCosto = new TextBox();
            label4 = new Label();
            textPrecio = new TextBox();
            label5 = new Label();
            textStock = new TextBox();
            label6 = new Label();
            textIdUsuario = new TextBox();
            buttonVolver = new Button();
            buttonGuardar = new Button();
            buttonBorrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 54);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // textId
            // 
            textId.Location = new Point(158, 51);
            textId.Name = "textId";
            textId.ReadOnly = true;
            textId.Size = new Size(100, 23);
            textId.TabIndex = 1;
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(158, 102);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(100, 23);
            textDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 102);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 148);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "Costo";
            // 
            // textCosto
            // 
            textCosto.Location = new Point(158, 148);
            textCosto.Name = "textCosto";
            textCosto.Size = new Size(100, 23);
            textCosto.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 199);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "Precio";
            // 
            // textPrecio
            // 
            textPrecio.Location = new Point(158, 199);
            textPrecio.Name = "textPrecio";
            textPrecio.Size = new Size(100, 23);
            textPrecio.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 253);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 9;
            label5.Text = "Stock";
            // 
            // textStock
            // 
            textStock.Location = new Point(158, 253);
            textStock.Name = "textStock";
            textStock.Size = new Size(100, 23);
            textStock.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 307);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 11;
            label6.Text = "Id Usuario";
            // 
            // textIdUsuario
            // 
            textIdUsuario.Location = new Point(158, 307);
            textIdUsuario.Name = "textIdUsuario";
            textIdUsuario.Size = new Size(100, 23);
            textIdUsuario.TabIndex = 10;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(26, 374);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 12;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(121, 374);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 13;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonBorrar
            // 
            buttonBorrar.Location = new Point(219, 374);
            buttonBorrar.Name = "buttonBorrar";
            buttonBorrar.Size = new Size(75, 23);
            buttonBorrar.TabIndex = 14;
            buttonBorrar.Text = "Borrar";
            buttonBorrar.UseVisualStyleBackColor = true;
            buttonBorrar.Click += buttonBorrar_Click;
            // 
            // ProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 450);
            Controls.Add(buttonBorrar);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonVolver);
            Controls.Add(label6);
            Controls.Add(textIdUsuario);
            Controls.Add(label5);
            Controls.Add(textStock);
            Controls.Add(label4);
            Controls.Add(textPrecio);
            Controls.Add(label3);
            Controls.Add(textCosto);
            Controls.Add(label2);
            Controls.Add(textDescripcion);
            Controls.Add(textId);
            Controls.Add(label1);
            Name = "ProductoForm";
            Text = "ProductoForm";
            Load += ProductoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textId;
        private TextBox textDescripcion;
        private Label label2;
        private Label label3;
        private TextBox textCosto;
        private Label label4;
        private TextBox textPrecio;
        private Label label5;
        private TextBox textStock;
        private Label label6;
        private TextBox textIdUsuario;
        private Button buttonVolver;
        private Button buttonGuardar;
        private Button buttonBorrar;
    }
}