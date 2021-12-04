namespace CrudWindowsFormsDataSet
{
    partial class Console
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
            this.ConsoledataGridView = new System.Windows.Forms.DataGridView();
            this.Refreshbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Editarbutton = new System.Windows.Forms.Button();
            this.Crearbutton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoledataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsoledataGridView
            // 
            this.ConsoledataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ConsoledataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ConsoledataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.ConsoledataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ConsoledataGridView.Location = new System.Drawing.Point(78, 124);
            this.ConsoledataGridView.Name = "ConsoledataGridView";
            this.ConsoledataGridView.Size = new System.Drawing.Size(312, 150);
            this.ConsoledataGridView.TabIndex = 0;
            this.ConsoledataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConsoledataGridView_CellContentClick);
            // 
            // Refreshbutton
            // 
            this.Refreshbutton.Location = new System.Drawing.Point(331, 78);
            this.Refreshbutton.Name = "Refreshbutton";
            this.Refreshbutton.Size = new System.Drawing.Size(90, 23);
            this.Refreshbutton.TabIndex = 9;
            this.Refreshbutton.Text = "Refrescar Lista";
            this.Refreshbutton.UseVisualStyleBackColor = true;
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Location = new System.Drawing.Point(215, 78);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 23);
            this.Eliminarbutton.TabIndex = 8;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Editarbutton
            // 
            this.Editarbutton.Location = new System.Drawing.Point(100, 78);
            this.Editarbutton.Name = "Editarbutton";
            this.Editarbutton.Size = new System.Drawing.Size(75, 23);
            this.Editarbutton.TabIndex = 7;
            this.Editarbutton.Text = "Editar";
            this.Editarbutton.UseVisualStyleBackColor = true;
            this.Editarbutton.Click += new System.EventHandler(this.Editarbutton_Click);
            // 
            // Crearbutton
            // 
            this.Crearbutton.Location = new System.Drawing.Point(6, 78);
            this.Crearbutton.Name = "Crearbutton";
            this.Crearbutton.Size = new System.Drawing.Size(75, 23);
            this.Crearbutton.TabIndex = 6;
            this.Crearbutton.Text = "Crear";
            this.Crearbutton.UseVisualStyleBackColor = true;
            this.Crearbutton.Click += new System.EventHandler(this.Crearbutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(297, 295);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Volver";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 364);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Refreshbutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Editarbutton);
            this.Controls.Add(this.Crearbutton);
            this.Controls.Add(this.ConsoledataGridView);
            this.Name = "Console";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Console_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoledataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ConsoledataGridView;
        private System.Windows.Forms.Button Refreshbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Editarbutton;
        private System.Windows.Forms.Button Crearbutton;
        private System.Windows.Forms.Button button4;
    }
}