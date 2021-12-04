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
    public partial class CreatePublisher : MaterialForm
    {
        private int? id;
        private SqlConnection cn;

        public CreatePublisher(int? id= null)
        {
            InitializeComponent();
            this.id = id;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            dsPublisherTableAdapters.dsPublisherTableAdapter datosPublisher = new dsPublisherTableAdapters.dsPublisherTableAdapter();
            if (id == null)
            {
                datosPublisher.CreatePublisher(NombretextBox.Text.Trim());
            }
            else
            {
                datosPublisher.ModifyPublisher(NombretextBox.Text.Trim(), (int)id);
            }
            this.Close();
        }

        private void CreatePublisher_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-G66G3V0;Initial Catalog=CrudWindowsForm;Integrated Security=SSPI");
            cn.Open();
            if(id != null) 
            {
                LoadFields(id);
            }
        }

        private void LoadFields(int? id) 
        {
            dsPublisherTableAdapters.dsPublisherTableAdapter datosPublisher = new dsPublisherTableAdapters.dsPublisherTableAdapter();
            dsPublisher.dsPublisherDataTable dtPublisher = datosPublisher.GetDataById((int)id);
            dsPublisher.dsPublisherRow dato = (dsPublisher.dsPublisherRow)dtPublisher.Rows[0];

            NombretextBox.Text = dato.Nombre;
        }
    }
}
