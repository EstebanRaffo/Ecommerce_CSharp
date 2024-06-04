namespace EcommerceDesktop
{
    partial class UsuarioForm
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
            txtNombre = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            buttonBorrar = new Button();
            buttonGuardar = new Button();
            buttonVolver = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtNombreUsuario = new TextBox();
            label6 = new Label();
            txtApellido = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(142, 91);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 94);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 12;
            label2.Text = "Nombre";
            // 
            // txtId
            // 
            txtId.Location = new Point(142, 46);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // buttonBorrar
            // 
            buttonBorrar.Location = new Point(201, 382);
            buttonBorrar.Name = "buttonBorrar";
            buttonBorrar.Size = new Size(75, 23);
            buttonBorrar.TabIndex = 9;
            buttonBorrar.Text = "Borrar";
            buttonBorrar.UseVisualStyleBackColor = true;
            buttonBorrar.Click += buttonBorrar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(108, 382);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(75, 23);
            buttonGuardar.TabIndex = 8;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.TextAlign = ContentAlignment.BottomCenter;
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(15, 382);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(75, 23);
            buttonVolver.TabIndex = 7;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(142, 223);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 223);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 14;
            label3.Text = "Contraseña";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(143, 265);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 265);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 16;
            label4.Text = "Email";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(143, 177);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 177);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 20;
            label6.Text = "NombreUsuario";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(142, 132);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 138);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 22;
            label7.Text = "Apellido";
            // 
            // UsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 450);
            Controls.Add(txtApellido);
            Controls.Add(label7);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(buttonBorrar);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonVolver);
            Name = "UsuarioForm";
            Text = "UsuarioForm";
            Load += UsuarioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button buttonBorrar;
        private Button buttonGuardar;
        private Button buttonVolver;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtNombreUsuario;
        private Label label6;
        private TextBox txtApellido;
        private Label label7;
    }
}