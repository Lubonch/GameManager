using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CrudWindowsFormsDataSet
{
    public partial class Genero : MaterialForm
    {
        public Genero()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Genero_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void Refreshbutton_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        private void RefreshTable()
        {
            dsGenreTableAdapters.dsGenreTableAdapter ta = new dsGenreTableAdapters.dsGenreTableAdapter();
            dsGenre.dsGenreDataTable dt = ta.GetData();
            GenredataGridView.DataSource = dt;

        }

        private void Crearbutton_Click(object sender, EventArgs e)
        {
            CreateGenre genre = new CreateGenre();
            genre.ShowDialog();
            RefreshTable();
        }

        private void Editarbutton_Click(object sender, EventArgs e)
        {
            int? id = GetItemId();
            if (id != null)
            {
                CreateGenre genre = new CreateGenre(id);
                genre.ShowDialog();
            }
            RefreshTable();
        }
        private int? GetItemId()
        {
            return int.Parse(GenredataGridView.Rows[GenredataGridView.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int? Id = GetItemId();
            if (Id != null)
            {
                dsGenreTableAdapters.dsGenreTableAdapter ta = new dsGenreTableAdapters.dsGenreTableAdapter();
                ta.DeleteQuery((int)Id);
                RefreshTable();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }
    }
}
