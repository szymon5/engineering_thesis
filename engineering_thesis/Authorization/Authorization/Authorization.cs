﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private string codeMarks = "0123456789";
        private void BTN_ADD_USER_Click(object sender, EventArgs e)
        {
            Global.NewUser = new List<string>()
            {
                TB_User_Name.Text,
                TB_User_Surname.Text,
                TB_User_Password.Text,
                TEXT_GENERATE_CODE.Text
            };
            DataBase.AddUser(Global.NewUser);


            if (Global.USER_ADDED)
            {
                DialogResult dialog = MessageBox.Show("User has been added", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    TB_User_Name.Text = "";
                    TB_User_Surname.Text = "";
                    TB_User_Password.Text = "";
                    TEXT_GENERATE_CODE.Text = "";
                }
            }
            else MessageBox.Show("Error", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BTN_Generate_CODE_Click(object sender, EventArgs e)
        {
            string generatedCode = "";

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                generatedCode += codeMarks[random.Next(0, codeMarks.Length - 1)];
            }
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime add = Convert.ToDateTime(currentTime).AddMinutes(10);
            string incrementedTime = add.ToString("yyyy-MM-dd HH:mm:ss");

            Global.GENERATED_TIME = currentTime;
            Global.EXPIRE_TIME = incrementedTime;

            TEXT_GENERATE_CODE.Text = "A*" + generatedCode + "#";
        }

        private void BTN_DELETE_USER_Click(object sender, EventArgs e)
        {
            Global.DeleteUser = new List<string>()
            {
                TEXT_UID_DELETE.Text,
                TEXT_NAME_DELETE.Text,
                TEXT_SURNAME_DELETE.Text,
                TXT_DELETE_ACC_CODE.Text
            };
            DataBase.DeleteUser(Global.DeleteUser);


            if (Global.USER_DELETED)
            {
                DialogResult dialog = MessageBox.Show("User has been blocked. To delete this user from system insert code", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    TEXT_UID_DELETE.Text = "";
                    TEXT_NAME_DELETE.Text = "";
                    TEXT_SURNAME_DELETE.Text = "";
                    TXT_DELETE_ACC_CODE.Text = "";
                }
            }
            else MessageBox.Show("Error", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BTN_CHECK_PERSONS_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(DataBase.connectionString);
            try
            {
                connection.Open();

                MySqlCommand persons_authorized = new MySqlCommand("select * from users", connection);
                MySqlDataAdapter autho = new MySqlDataAdapter(persons_authorized);
                DataTable table2 = new DataTable();
                autho.Fill(table2);
                dgvPERSONS.DataSource = table2;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BTN_ENTREACE_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(DataBase.connectionString);
            try
            {
                connection.Open();
                MySqlCommand persons_time = new MySqlCommand("select users.user_name,users.user_surname, " +
                                                      "usertime.time_in,usertime.time_out,usertime.residence_time " +
                                                      "from users,usertime where users.user_id = usertime.user_id", connection);
                MySqlDataAdapter time = new MySqlDataAdapter(persons_time);
                DataTable table = new DataTable();
                time.Fill(table);
                dgvPERSONS_TIME.DataSource = table;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void BTN_DELETE_CODE_Click(object sender, EventArgs e)
        {
            string generatedCode = "";

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                generatedCode += codeMarks[random.Next(0, codeMarks.Length - 1)];
            }
            TXT_DELETE_ACC_CODE.Text = "D*" + generatedCode + "#";
        }

        private void BTN_OWN_SQL_STM_Click(object sender, EventArgs e)
        {
            DataBase.YourOwnSQL(TB_OWN_SQL_STM.Text);

            if (Global.OWN_SQL_IS_DONE)
            {
                DialogResult dialog = MessageBox.Show("Data has been sended", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    TB_OWN_SQL_STM.Text = "";
                }
            }
            else MessageBox.Show("Error", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
