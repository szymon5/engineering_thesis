using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Authorization
{
    public static class DataBase
    {
        public static string connectionString = "Server=serwer1954159.home.pl;" +
                                                "Database=31582762_authorization;" +
                                                "Uid=31582762_authorization;" +
                                                "Pwd=Mrozinski5.";
        public static void AddUser(List<string> newUser)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand user = new MySqlCommand("insert into users(user_name,user_surname,user_fingerprint,user_exit_password,availability)" +
                                                        "values('" + newUser[0] + "','" + newUser[1] + "',null,'" + newUser[2] + "', true)", connection);
                user.ExecuteNonQuery();


                MySqlCommand get_user_id = new MySqlCommand("select max(user_id) from users", connection);
                int user_id = Convert.ToInt16(get_user_id.ExecuteScalar());

                MySqlCommand usercode = new MySqlCommand("insert into usercode(user_id,create_acc_code,generate_time,expire_date)" +
                                                         " values(" + user_id + ",'" + newUser[3] + "','" + Global.GENERATED_TIME + "','" + Global.EXPIRE_TIME + "')", connection);

                usercode.ExecuteNonQuery();

                MySqlCommand usertime = new MySqlCommand("insert into usertime(user_id) values(" + user_id + ")", connection);
                usertime.ExecuteNonQuery();

                Global.USER_ADDED = true;
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
        public static void DeleteUser(List<string> deleteUser)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand set_availability_to_false = new MySqlCommand("update users set availability = false where user_id = " + Convert.ToInt16(deleteUser[0]) +
                                                        " and user_name = '" + deleteUser[1] + "'" +
                                                        " and user_surname = '" + deleteUser[2] + "'", connection);
                set_availability_to_false.ExecuteNonQuery();

                MySqlCommand delete_acc_code = new MySqlCommand("update usercode set usercode.delete_acc_code = '" + deleteUser[3] + "'" +
                                                        " where usercode.user_id = (select users.user_id from users where users.user_id = " + Convert.ToInt16(deleteUser[0])+")", connection);
                
                delete_acc_code.ExecuteNonQuery();
                Global.USER_DELETED = true;
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
        public static void AdministratorLogin(List<string> administrator)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand check_administrator = new MySqlCommand("select count(admin_id) as quantity from administrator " +
                                                            "where admin_login = '" + administrator[0] + "' and admin_password = '" + administrator[1] + "'", connection);



                int quantity = Convert.ToInt16(check_administrator.ExecuteScalar());
                if (quantity == 1) Global.ADMINISTRATOR_LOGIN = true;
                else Global.ADMINISTRATOR_LOGIN = false;
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
        public static void YourOwnSQL(string sql)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                MySqlCommand own_sql = new MySqlCommand(sql, connection);

                own_sql.ExecuteNonQuery();
                Global.OWN_SQL_IS_DONE = true;
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
    }
}
