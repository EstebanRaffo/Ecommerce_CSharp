namespace SistemaGestionUI
{
    partial class VentaForm
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
            txtIdUsuario = new TextBox();
            label6 = new Label();
            txtComentarios = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            buttonBorrar = new Button();
            buttonGuardar = new Button();
            buttonVolver = new Button();
            SuspendLayout();
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(140, 135);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new Size(100, 23);
            txtIdUsuario.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 135);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 19;
            label6.Text = "Id Usuario";
            // 
            // txtComentarios
            // 
            txtComentarios.Location = new Point(140, 78);
            txtComentarios.Name = "txtComentarios";
            txtComentarios.Size = new Size(100, 23);
            txtComentarios.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 78);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 17;
            label2.Text = "Comentarios";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 30);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 15;
            label1.Text = "Id";
            // 
            // buttonBorrar
            // 
            buttonBorrar.Location = new Point(188, 192);
            buttonBorrar.Name = "buttonBorrar";
            buttonBorrar.Size = new Size(75, 23);
            buttonBorrar.TabIndex = 23;
            buttonBorrar.Text = "Borrar";
            buttonBorrar.UseVisualStyleBackColor = true;
            buttonBorrar.Click += buttonBorrar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(107, 192);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 22;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.TextAlign = ContentAlignment.BottomCenter;
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(26, 192);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 21;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // VentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 258);
            Controls.Add(buttonBorrar);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonVolver);
            Controls.Add(txtIdUsuario);
            Controls.Add(label6);
            Controls.Add(txtComentarios);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "VentaForm";
            Text = "VentaForm";
            Load += VentaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdUsuario;
        private Label label6;
        private TextBox txtComentarios;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button buttonBorrar;
        private Button buttonGuardar;
        private Button buttonVolver;
    }
}