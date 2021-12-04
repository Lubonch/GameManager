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
    public partial class NewGame : MaterialForm
    {
        private SqlConnection cn;

        public NewGame()
        {
            InitializeComponent();

            this.cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CrudWindowsFormsDataSet.Properties.Settings.CrudWindowsFormConnectionString"].ConnectionString);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void PublishercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            cn.Open();

            dsPublisherTableAdapters.dsPublisherTableAdapter pta = new dsPublisherTableAdapters.dsPublisherTableAdapter();
            dsPublisher.dsPublisherDataTable dpta = pta.GetData();
            PublishercomboBox.DataSource = dpta;
            PublishercomboBox.DisplayMember = "Name";


        }
    }
}
