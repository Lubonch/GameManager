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
    public partial class Console : MaterialForm
    {
        public Console()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void Console_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            dsConsoleTableAdapters.dsConsoleTableAdapter ta = new dsConsoleTableAdapters.dsConsoleTableAdapter();
            dsConsole.dsConsoleDataTable dt = ta.GetData();
            ConsoledataGridView.DataSource = dt;
        }

        private void Crearbutton_Click(object sender, EventArgs e)
        {
            CreateConsole console = new CreateConsole();
            console.ShowDialog();
            RefreshTable();
        }

        private void Editarbutton_Click(object sender, EventArgs e)
        {
            int? id = GetItemId();
            if (id != null)
            {
                CreateConsole console = new CreateConsole();
                console.ShowDialog();
            }
            RefreshTable();
        }
        private int? GetItemId()
        {
            return int.Parse(ConsoledataGridView.Rows[ConsoledataGridView.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int? Id = GetItemId();
            if (Id != null)
            {
                dsConsoleTableAdapters.dsConsoleTableAdapter ta = new dsConsoleTableAdapters.dsConsoleTableAdapter();
                ta.DeleteQuery((int)Id);
                RefreshTable();
            }
        }

        private void ConsoledataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
