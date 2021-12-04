namespace CrudWindowsFormsDataSet
{
    partial class Publisher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PublisherdataGridView = new System.Windows.Forms.DataGridView();
            this.Crearbutton = new System.Windows.Forms.Button();
            this.Editarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Refreshbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PublisherdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PublisherdataGridView
            // 
            this.PublisherdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PublisherdataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.PublisherdataGridView.Location = new System.Drawing.Point(15, 123);
            this.PublisherdataGridView.Name = "PublisherdataGridView";
            this.PublisherdataGridView.Size = new System.Drawing.Size(415, 150);
            this.PublisherdataGridView.TabIndex = 0;
            // 
            // Crearbutton
            // 
            this.Crearbutton.Location = new System.Drawing.Point(15, 76);
            this.Crearbutton.Name = "Crearbutton";
            this.Crearbutton.Size = new System.Drawing.Size(75, 23);
            this.Crearbutton.TabIndex = 1;
            this.Crearbutton.Text = "Crear";
            this.Crearbutton.UseVisualStyleBackColor = true;
            this.Crearbutton.Click += new System.EventHandler(this.Crearbutton_Click);
            // 
            // Editarbutton
            // 
            this.Editarbutton.Location = new System.Drawing.Point(109, 76);
            this.Editarbutton.Name = "Editarbutton";
            this.Editarbutton.Size = new System.Drawing.Size(75, 23);
            this.Editarbutton.TabIndex = 2;
            this.Editarbutton.Text = "Editar";
            this.Editarbutton.UseVisualStyleBackColor = true;
            this.Editarbutton.Click += new System.EventHandler(this.Editarbutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Location = new System.Drawing.Point(224, 76);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 23);
            this.Eliminarbutton.TabIndex = 3;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(355, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Volver";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Refreshbutton
            // 
            this.Refreshbutton.Location = new System.Drawing.Point(340, 76);
            this.Refreshbutton.Name = "Refreshbutton";
            this.Refreshbutton.Size = new System.Drawing.Size(90, 23);
            this.Refreshbutton.TabIndex = 5;
            this.Refreshbutton.Text = "Refrescar Lista";
            this.Refreshbutton.UseVisualStyleBackColor = true;
            this.Refreshbutton.Click += new System.EventHandler(this.Refreshbutton_Click);
            // 
            // Publisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 329);
            this.Controls.Add(this.Refreshbutton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Editarbutton);
            this.Controls.Add(this.Crearbutton);
            this.Controls.Add(this.PublisherdataGridView);
            this.Name = "Publisher";
            this.Text = "Publisher";
            this.Load += new System.EventHandler(this.Publisher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PublisherdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PublisherdataGridView;
        private System.Windows.Forms.Button Crearbutton;
        private System.Windows.Forms.Button Editarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Refreshbutton;
    }
}