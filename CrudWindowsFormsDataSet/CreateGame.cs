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
    public partial class CreateGame : MaterialForm
    {
        private int? id;
        private SqlConnection cn;

        public CreateGame(int? id = null)
        {
            InitializeComponent();
            this.id = id;

            this.cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CrudWindowsFormsDataSet.Properties.Settings.CrudWindowsFormConnectionString"].ConnectionString);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void CreateGame_Load(object sender, EventArgs e)//localhost
        {
            cn.Open();
            YeardateTimePicker.Format = DateTimePickerFormat.Custom;
            YeardateTimePicker.CustomFormat = "dd-MM-yyyy";
            LoadComboBox();
            if (id != null)
            {
                LoadFields(id);
            }
        }

        private void LoadFields(int? id)
        {
            dsGameTableAdapters.dsGameModifyTableAdapter datosJuego = new dsGameTableAdapters.dsGameModifyTableAdapter();
            dsGame.dsGameModifyDataTable dtGame = datosJuego.GetDataBy((int)id);
            dsGame.dsGameModifyRow dato = (dsGame.dsGameModifyRow)dtGame.Rows[0];

            NombretextBox.Text = dato.Name;
            YeardateTimePicker.Value = dato.Year;
            PublishercomboBox.SelectedValue = dato.IdPublisher;
            ConsolacomboBox.SelectedValue = dato.IdConsole;
            GenerocomboBox.SelectedValue = dato.IdGenre;
            CantidadtextBox.Text = dato.Quantity.ToString();
            PreciotextBox.Text = dato.Price.ToString();
        }
        private void LoadComboBox() 
        {
            dsGenreTableAdapters.dsGenreTableAdapter combogenero = new dsGenreTableAdapters.dsGenreTableAdapter();
            dsPublisherTableAdapters.dsPublisherTableAdapter combopublisher = new dsPublisherTableAdapters.dsPublisherTableAdapter();
            dsConsoleTableAdapters.dsConsoleTableAdapter comboconsola = new dsConsoleTableAdapters.dsConsoleTableAdapter();

            dsGenre.dsGenreDataTable datosgenero = combogenero.GetData();
            dsPublisher.dsPublisherDataTable datospublisher = combopublisher.GetData();
            dsConsole.dsConsoleDataTable datosconsola = comboconsola.GetData();

            GenerocomboBox.DataSource = datosgenero;
            GenerocomboBox.DisplayMember = "Nombre";
            GenerocomboBox.ValueMember = "Id";

            PublishercomboBox.DataSource = datospublisher;
            PublishercomboBox.DisplayMember = "Nombre";
            PublishercomboBox.ValueMember = "Id";

            ConsolacomboBox.DataSource = datosconsola;
            ConsolacomboBox.DisplayMember = "Nombre";
            ConsolacomboBox.ValueMember = "Id";
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            dsGameTableAdapters.dsGameModifyTableAdapter datosJuego = new dsGameTableAdapters.dsGameModifyTableAdapter();
            if (id == null)
            {
                datosJuego.InsertQuery(NombretextBox.Text.Trim(),YeardateTimePicker.Value,(int)PublishercomboBox.SelectedValue, (int)ConsolacomboBox.SelectedValue, (int)GenerocomboBox.SelectedValue, Int32.Parse(CantidadtextBox.Text), Int32.Parse(PreciotextBox.Text));
            }
            else
            {
                datosJuego.UpdateQuery(NombretextBox.Text.Trim(), YeardateTimePicker.Value, (int)PublishercomboBox.SelectedValue, (int)ConsolacomboBox.SelectedValue, (int)GenerocomboBox.SelectedValue, Int32.Parse(CantidadtextBox.Text), Int32.Parse(PreciotextBox.Text),(int)id);
            }
            this.Close();
        }

        private void Volverbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
