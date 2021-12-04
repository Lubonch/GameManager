namespace CrudWindowsFormsDataSet
{
    partial class Register
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
            this.User = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.Label();
            this.pwd2 = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.pwdbox = new System.Windows.Forms.TextBox();
            this.pwd2box = new System.Windows.Forms.TextBox();
            this.Registrarse = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(39, 85);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(43, 13);
            this.User.TabIndex = 0;
            this.User.Text = "Usuario";
            this.User.Click += new System.EventHandler(this.label1_Click);
            // 
            // pwd
            // 
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(39, 114);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(61, 13);
            this.pwd.TabIndex = 1;
            this.pwd.Text = "Contraseña";
            // 
            // pwd2
            // 
            this.pwd2.AutoSize = true;
            this.pwd2.Location = new System.Drawing.Point(39, 141);
            this.pwd2.Name = "pwd2";
            this.pwd2.Size = new System.Drawing.Size(61, 13);
            this.pwd2.TabIndex = 2;
            this.pwd2.Text = "Contraseña";
            // 
            // UserBox
            // 
            this.UserBox.Location = new System.Drawing.Point(107, 85);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(100, 20);
            this.UserBox.TabIndex = 3;
            this.UserBox.TextChanged += new System.EventHandler(this.UserBox_TextChanged);
            // 
            // pwdbox
            // 
            this.pwdbox.Location = new System.Drawing.Point(107, 111);
            this.pwdbox.Name = "pwdbox";
            this.pwdbox.Size = new System.Drawing.Size(100, 20);
            this.pwdbox.TabIndex = 4;
            // 
            // pwd2box
            // 
            this.pwd2box.Location = new System.Drawing.Point(107, 141);
            this.pwd2box.Name = "pwd2box";
            this.pwd2box.Size = new System.Drawing.Size(100, 20);
            this.pwd2box.TabIndex = 5;
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(117, 179);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(75, 23);
            this.Registrarse.TabIndex = 6;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(117, 208);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(75, 23);
            this.Atras.TabIndex = 7;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 249);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.pwd2box);
            this.Controls.Add(this.pwdbox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.pwd2);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.User);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.Label pwd2;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.TextBox pwdbox;
        private System.Windows.Forms.TextBox pwd2box;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button Atras;
    }
}