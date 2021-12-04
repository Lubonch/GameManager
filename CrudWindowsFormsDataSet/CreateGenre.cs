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
    public partial class CreateGenre : MaterialForm
    {
        private int? id;
        private SqlConnection cn;

        public CreateGenre(int? id= null)
        {
            InitializeComponent();
            this.id = id;

            this.cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CrudWindowsFormsDataSet.Properties.Settings.CrudWindowsFormConnectionString"].ConnectionString);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            dsGenreTableAdapters.dsGenreTableAdapter datosGenre = new dsGenreTableAdapters.dsGenreTableAdapter();
            if (id == null)
            {
                datosGenre.CreateGenre(NombretextBox.Text.Trim());
            }
            else
            {
                datosGenre.ModifyGenre(NombretextBox.Text.Trim(), (int)id);
            }
            this.Close();
        }

        private void CreateGenre_Load(object sender, EventArgs e)
        {
            cn.Open();
            if (id != null)
            {
                LoadFields(id);
            }
        }

        private void LoadFields(int? id)
        {
            dsGenreTableAdapters.dsGenreTableAdapter datosGenre = new dsGenreTableAdapters.dsGenreTableAdapter();
            dsGenre.dsGenreDataTable dtGenre = datosGenre.GetDataById((int)id);
            dsGenre.dsGenreRow dato = (dsGenre.dsGenreRow)dtGenre.Rows[0];

            NombretextBox.Text = dato.Nombre;
        }
    }
}
