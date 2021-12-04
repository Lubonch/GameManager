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
    public partial class Register : MaterialForm
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public Register()
        {
            InitializeComponent();

            this.cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CrudWindowsFormsDataSet.Properties.Settings.CrudWindowsFormConnectionString"].ConnectionString);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            pwdbox.PasswordChar = '*';
            pwd2box.PasswordChar = '*';
            cn.Open();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            if (pwd2box.Text != string.Empty && pwdbox.Text != string.Empty && UserBox.Text != string.Empty)
            {
                if (pwdbox.Text == pwd2box.Text)
                {
                    cmd = new SqlCommand("select * from LoginTable where username='" + UserBox.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("El nombre de usuario ya existe! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                        cmd.Parameters.AddWithValue("username", UserBox.Text);
                        cmd.Parameters.AddWithValue("password", pwdbox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("La cuenta fue creada. Ya puede hacer el Login", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas deben ser iguales ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese los datos en todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
