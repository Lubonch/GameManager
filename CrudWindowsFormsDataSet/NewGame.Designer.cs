namespace CrudWindowsFormsDataSet
{
    partial class NewGame
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
            this.Createbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.YeartextBox = new System.Windows.Forms.TextBox();
            this.PublishercomboBox = new System.Windows.Forms.ComboBox();
            this.ConsolecomboBox = new System.Windows.Forms.ComboBox();
            this.GenrecomboBox = new System.Windows.Forms.ComboBox();
            this.Namelabel = new System.Windows.Forms.Label();
            this.Yearlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Consolelabel = new System.Windows.Forms.Label();
            this.Genrelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Createbutton
            // 
            this.Createbutton.Location = new System.Drawing.Point(67, 290);
            this.Createbutton.Name = "Createbutton";
            this.Createbutton.Size = new System.Drawing.Size(75, 23);
            this.Createbutton.TabIndex = 0;
            this.Createbutton.Text = "Crear";
            this.Createbutton.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(176, 290);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "Cancelar";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(122, 84);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(100, 20);
            this.NametextBox.TabIndex = 2;
            // 
            // YeartextBox
            // 
            this.YeartextBox.Location = new System.Drawing.Point(122, 121);
            this.YeartextBox.Name = "YeartextBox";
            this.YeartextBox.Size = new System.Drawing.Size(100, 20);
            this.YeartextBox.TabIndex = 3;
            // 
            // PublishercomboBox
            // 
            this.PublishercomboBox.FormattingEnabled = true;
            this.PublishercomboBox.Location = new System.Drawing.Point(122, 161);
            this.PublishercomboBox.Name = "PublishercomboBox";
            this.PublishercomboBox.Size = new System.Drawing.Size(100, 21);
            this.PublishercomboBox.TabIndex = 4;
            this.PublishercomboBox.SelectedIndexChanged += new System.EventHandler(this.PublishercomboBox_SelectedIndexChanged);
            // 
            // ConsolecomboBox
            // 
            this.ConsolecomboBox.FormattingEnabled = true;
            this.ConsolecomboBox.Location = new System.Drawing.Point(122, 200);
            this.ConsolecomboBox.Name = "ConsolecomboBox";
            this.ConsolecomboBox.Size = new System.Drawing.Size(100, 21);
            this.ConsolecomboBox.TabIndex = 5;
            // 
            // GenrecomboBox
            // 
            this.GenrecomboBox.FormattingEnabled = true;
            this.GenrecomboBox.Location = new System.Drawing.Point(122, 237);
            this.GenrecomboBox.Name = "GenrecomboBox";
            this.GenrecomboBox.Size = new System.Drawing.Size(100, 21);
            this.GenrecomboBox.TabIndex = 6;
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Location = new System.Drawing.Point(77, 87);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(44, 13);
            this.Namelabel.TabIndex = 7;
            this.Namelabel.Text = "Nombre";
            // 
            // Yearlabel
            // 
            this.Yearlabel.AutoSize = true;
            this.Yearlabel.Location = new System.Drawing.Point(81, 124);
            this.Yearlabel.Name = "Yearlabel";
            this.Yearlabel.Size = new System.Drawing.Size(26, 13);
            this.Yearlabel.TabIndex = 8;
            this.Yearlabel.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Publisher";
            // 
            // Consolelabel
            // 
            this.Consolelabel.AutoSize = true;
            this.Consolelabel.Location = new System.Drawing.Point(71, 203);
            this.Consolelabel.Name = "Consolelabel";
            this.Consolelabel.Size = new System.Drawing.Size(45, 13);
            this.Consolelabel.TabIndex = 10;
            this.Consolelabel.Text = "Consola";
            // 
            // Genrelabel
            // 
            this.Genrelabel.AutoSize = true;
            this.Genrelabel.Location = new System.Drawing.Point(79, 240);
            this.Genrelabel.Name = "Genrelabel";
            this.Genrelabel.Size = new System.Drawing.Size(42, 13);
            this.Genrelabel.TabIndex = 11;
            this.Genrelabel.Text = "Genero";
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 335);
            this.Controls.Add(this.Genrelabel);
            this.Controls.Add(this.Consolelabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Yearlabel);
            this.Controls.Add(this.Namelabel);
            this.Controls.Add(this.GenrecomboBox);
            this.Controls.Add(this.ConsolecomboBox);
            this.Controls.Add(this.PublishercomboBox);
            this.Controls.Add(this.YeartextBox);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Createbutton);
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.Load += new System.EventHandler(this.NewGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Createbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.TextBox YeartextBox;
        private System.Windows.Forms.ComboBox PublishercomboBox;
        private System.Windows.Forms.ComboBox ConsolecomboBox;
        private System.Windows.Forms.ComboBox GenrecomboBox;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.Label Yearlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Consolelabel;
        private System.Windows.Forms.Label Genrelabel;
    }
}