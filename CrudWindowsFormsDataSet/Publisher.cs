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
    public partial class Publisher : MaterialForm
    {
        public Publisher()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Refreshbutton_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            dsPublisherTableAdapters.dsPublisherTableAdapter ta = new dsPublisherTableAdapters.dsPublisherTableAdapter();
            dsPublisher.dsPublisherDataTable dt = ta.GetData();
            PublisherdataGridView.DataSource = dt;

        }

        private void Crearbutton_Click(object sender, EventArgs e)
        {
            CreatePublisher publisher = new CreatePublisher();
            publisher.ShowDialog();
            RefreshTable();
        }

        private void Editarbutton_Click(object sender, EventArgs e)
        {
            int? id = GetItemId();
            if(id != null)
            {
                CreatePublisher publisher = new CreatePublisher(id);
                publisher.ShowDialog();
            }
            RefreshTable();
            
        }

        private int? GetItemId() 
        {
            return int.Parse(PublisherdataGridView.Rows[PublisherdataGridView.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int? Id = GetItemId();
            if (Id != null)
            {
                dsPublisherTableAdapters.dsPublisherTableAdapter ta = new dsPublisherTableAdapters.dsPublisherTableAdapter();
                ta.DeleteQuery((int)Id);
                RefreshTable();
            }
        }
    }
}
