using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsFormsDataSet
{
    public partial class FrmPeople : Form
    {
        private int? Id;
        public FrmPeople(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsCrudTableAdapters.peopleTableAdapter ta =
                new dsCrudTableAdapters.peopleTableAdapter();
            if (Id == null)
            {
                ta.Add(txtName.Text.Trim(), (int)txtAge.Value);
            }
            else
            {
                ta.Edit(txtName.Text.Trim(), (int)txtAge.Value, (int)Id);
            }
            this.Close();
        }

        private void FrmPeople_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                dsCrudTableAdapters.peopleTableAdapter ta =
                    new dsCrudTableAdapters.peopleTableAdapter();
                dsCrud.peopleDataTable dt= ta.GetDataById((int)Id);
                dsCrud.peopleRow row = (dsCrud.peopleRow)dt.Rows[0];
                txtName.Text = row.name;
                txtAge.Value = row.age;
            }
        }

        private void txtAge_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
