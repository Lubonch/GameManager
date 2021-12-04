using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CrudWindowsFormsDataSet
{
    public partial class Juego : MaterialForm
    {
        private SqlConnection cn;

        public Juego()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void Reload() 
        {
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            RefreshTable();
            cn = new SqlConnection(@"Data Source=DESKTOP-G66G3V0;Initial Catalog=CrudWindowsForm;Integrated Security=SSPI");
            cn.Open();
        }

        private void GamedataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            CreateGame game = new CreateGame();
            game.ShowDialog();
            RefreshTable();
        }
        private void RefreshTable()
        {
            dsGameTableAdapters.dsGameTableAdapter ta = new dsGameTableAdapters.dsGameTableAdapter();
            dsGame.dsGameDataTable dt = ta.GetData();
            GamedataGridView.DataSource = dt;
        }

        private void ReloadListbutton_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void ModifGamebutton_Click(object sender, EventArgs e)
        {
            int? id = GetItemId();
            if (id != null)
            {
                CreateGame game = new CreateGame(id);
                game.ShowDialog();
            }
            RefreshTable();
        }

        private int? GetItemId()
        {
            return int.Parse(GamedataGridView.Rows[GamedataGridView.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void DeleteGamebutton_Click(object sender, EventArgs e)
        {
            int? Id = GetItemId();
            if (Id != null)
            {
                dsGameTableAdapters.dsGameModifyTableAdapter ta = new dsGameTableAdapters.dsGameModifyTableAdapter();
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
