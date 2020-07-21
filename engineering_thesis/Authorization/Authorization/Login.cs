using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void NextForm()
        {
            Application.Run(new Authorization());
        }

        private void BTN_LOGIN_Click(object sender, KeyEventArgs e)
        {

        }
        private void LoginToAccount()
        {
            Global.ADMINISTRATOR = new List<string>()
            {
                TXT_LOGIN.Text,
                TXT_PASSWORD.Text
            };
            DataBase.AdministratorLogin(Global.ADMINISTRATOR);

            if (Global.ADMINISTRATOR_LOGIN)
            {
                Thread open = new Thread(NextForm);
                open.SetApartmentState(ApartmentState.STA);
                open.Start();
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Login Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    TXT_LOGIN.Text = "";
                    TXT_PASSWORD.Text = "";
                }
            }
        }

        private void BTN_LOGIN_Click(object sender, EventArgs e)
        {
            LoginToAccount();
        }
    }
}
