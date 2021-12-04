namespace CrudWindowsFormsDataSet
{
    partial class Login
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
            this.Usuario = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.inicio = new System.Windows.Forms.Button();
            this.Registro = new System.Windows.Forms.Button();
            this.UsuarioText = new System.Windows.Forms.TextBox();
            this.pwdText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(70, 85);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(43, 13);
            this.Usuario.TabIndex = 0;
            this.Usuario.Text = "Usuario";
            this.Usuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(52, 132);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(61, 13);
            this.Password.TabIndex = 1;
            this.Password.Text = "Contraseña";
            this.Password.Click += new System.EventHandler(this.label2_Click);
            // 
            // inicio
            // 
            this.inicio.Location = new System.Drawing.Point(143, 181);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(75, 23);
            this.inicio.TabIndex = 2;
            this.inicio.Text = "Login";
            this.inicio.UseVisualStyleBackColor = true;
            this.inicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // Registro
            // 
            this.Registro.Location = new System.Drawing.Point(143, 228);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(75, 23);
            this.Registro.TabIndex = 3;
            this.Registro.Text = "Registro";
            this.Registro.UseVisualStyleBackColor = true;
            this.Registro.Click += new System.EventHandler(this.button2_Click);
            // 
            // UsuarioText
            // 
            this.UsuarioText.Location = new System.Drawing.Point(134, 82);
            this.UsuarioText.Name = "UsuarioText";
            this.UsuarioText.Size = new System.Drawing.Size(100, 20);
            this.UsuarioText.TabIndex = 4;
            this.UsuarioText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pwdText
            // 
            this.pwdText.Location = new System.Drawing.Point(134, 129);
            this.pwdText.Name = "pwdText";
            this.pwdText.Size = new System.Drawing.Size(100, 20);
            this.pwdText.TabIndex = 5;
            this.pwdText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 265);
            this.Controls.Add(this.pwdText);
            this.Controls.Add(this.UsuarioText);
            this.Controls.Add(this.Registro);
            this.Controls.Add(this.inicio);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Usuario);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.Button Registro;
        private System.Windows.Forms.TextBox UsuarioText;
        private System.Windows.Forms.TextBox pwdText;
    }
}