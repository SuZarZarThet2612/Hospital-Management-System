using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lgbtn1_Click(object sender, RoutedEventArgs e)
        {
            if (useridtxt.Text == "" || pwdbox.Password.ToString() == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }

            string Drid = useridtxt.Text;
            string Password = pwdbox.Password.ToString();

            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd;
            try
            {
                //Create SqlConnection
               
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = string.Format("Select Drid,Password from doctor where  Drid= @Drid and Password = @Password",conn);;
                cmd.Parameters.AddWithValue("@Drid",Drid);
                cmd.Parameters.AddWithValue("@Password",Password);
                
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                conn.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Main hm = new Main();
                    hm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lgbtn2_Click(object sender, RoutedEventArgs e)
        {
            if (useridtxt.Text == "" || pwdbox.Password.ToString() == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }

            string Staff_id = useridtxt.Text;
            string pwd = pwdbox.Password.ToString();

            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd;
            try
            {
                //Create SqlConnection

                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = string.Format("Select Staff_id,pwd from staff where  Staff_id= @Staff_id and pwd =@pwd", conn); ;
                cmd.Parameters.AddWithValue("@Staff_id", Staff_id);
                cmd.Parameters.AddWithValue("@pwd", pwd);

                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                conn.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Main hm = new Main();
                    hm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lgbtn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
