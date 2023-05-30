using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Logintext.Text = "Login";
            passtext.Text = "Password";
        }

        private void Butlog_Click(object sender, EventArgs e)
        {
            String LoginUser = Logintext.Text;
            String PassUser = passtext.Text;

            DataBaseConnect DBconnect = new DataBaseConnect();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from users_login_pass where users = '" +LoginUser +"' and pass = '"+PassUser+"'", DBconnect.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

             if (table.Rows.Count > 0)
            {
                FormMain formmain = new FormMain();
                formmain.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Введены неверные данные ");
        }

        private void Logintext_Enter(object sender, EventArgs e)
        {
            if (Logintext.Text == "Login")
            Logintext.Text = "";
        }

        private void Logintext_Leave(object sender, EventArgs e)
        {
            if (Logintext.Text == "")
                Logintext.Text = "Login";
        }

        private void passtext_Enter(object sender, EventArgs e)
        {
            if (passtext.Text == "Password")
            {
                passtext.UseSystemPasswordChar = true; 
                passtext.Text = "";
            }
        }

        private void passtext_Leave(object sender, EventArgs e)
        {
            if (passtext.Text == "")
            {
                passtext.UseSystemPasswordChar = false;
                passtext.Text = "Password";
            }
        }
    }
}
