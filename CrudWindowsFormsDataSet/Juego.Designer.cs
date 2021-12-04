namespace CrudWindowsFormsDataSet
{
    partial class Juego
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
            this.GamedataGridView = new System.Windows.Forms.DataGridView();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.ModifGamebutton = new System.Windows.Forms.Button();
            this.DeleteGamebutton = new System.Windows.Forms.Button();
            this.ReloadListbutton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GamedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GamedataGridView
            // 
            this.GamedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GamedataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.GamedataGridView.Location = new System.Drawing.Point(18, 147);
            this.GamedataGridView.Name = "GamedataGridView";
            this.GamedataGridView.Size = new System.Drawing.Size(474, 215);
            this.GamedataGridView.TabIndex = 0;
            this.GamedataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GamedataGridView_CellContentClick);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(18, 79);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(118, 23);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.Text = "Agregar Juego";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // ModifGamebutton
            // 
            this.ModifGamebutton.Location = new System.Drawing.Point(152, 79);
            this.ModifGamebutton.Name = "ModifGamebutton";
            this.ModifGamebutton.Size = new System.Drawing.Size(75, 23);
            this.ModifGamebutton.TabIndex = 2;
            this.ModifGamebutton.Text = "Editar Juego";
            this.ModifGamebutton.UseVisualStyleBackColor = true;
            this.ModifGamebutton.Click += new System.EventHandler(this.ModifGamebutton_Click);
            // 
            // DeleteGamebutton
            // 
            this.DeleteGamebutton.Location = new System.Drawing.Point(240, 79);
            this.DeleteGamebutton.Name = "DeleteGamebutton";
            this.DeleteGamebutton.Size = new System.Drawing.Size(75, 23);
            this.DeleteGamebutton.TabIndex = 3;
            this.DeleteGamebutton.Text = "Eliminar Juego";
            this.DeleteGamebutton.UseVisualStyleBackColor = true;
            this.DeleteGamebutton.Click += new System.EventHandler(this.DeleteGamebutton_Click);
            // 
            // ReloadListbutton
            // 
            this.ReloadListbutton.Location = new System.Drawing.Point(417, 79);
            this.ReloadListbutton.Name = "ReloadListbutton";
            this.ReloadListbutton.Size = new System.Drawing.Size(75, 23);
            this.ReloadListbutton.TabIndex = 4;
            this.ReloadListbutton.Text = "Recargar Lista";
            this.ReloadListbutton.UseVisualStyleBackColor = true;
            this.ReloadListbutton.Click += new System.EventHandler(this.ReloadListbutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(417, 368);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Volver";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 408);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ReloadListbutton);
            this.Controls.Add(this.DeleteGamebutton);
            this.Controls.Add(this.ModifGamebutton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.GamedataGridView);
            this.Name = "Juego";
            this.Text = "Juego";
            this.Load += new System.EventHandler(this.Juego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GamedataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GamedataGridView;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button ModifGamebutton;
        private System.Windows.Forms.Button DeleteGamebutton;
        private System.Windows.Forms.Button ReloadListbutton;
        private System.Windows.Forms.Button button4;
    }
}