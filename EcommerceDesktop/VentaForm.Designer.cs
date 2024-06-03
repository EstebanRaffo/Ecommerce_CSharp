namespace EcommerceDesktop
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
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
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
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(140, 78);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 18;
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
            // button3
            // 
            button3.Location = new Point(188, 192);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 23;
            button3.Text = "Borrar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(107, 192);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 22;
            button2.Text = "Guardar";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(26, 192);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 21;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            // 
            // VentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 258);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtIdUsuario);
            Controls.Add(label6);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "VentaForm";
            Text = "VentaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdUsuario;
        private Label label6;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}