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
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for nurseReg.xaml
    /// </summary>
    public partial class nurseReg : Window
    {
        public nurseReg()
        {
            InitializeComponent();
        }

        private void staffRegAddbtn_Click(object sender, RoutedEventArgs e)
        {
            string Reg_date = N_date.Text;
            string Name = N_name.Text;
            string Age = N_age.Text;
            string Ph_no = N_phno.Text;
            string Address = N_address.Text;
            string Gender = ((bool)N_male.IsChecked) ? "Male" : "Female";

            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "insert into hospital.nurse(Reg_date,Name,Age,Ph_no,Address,Gender) values (@Reg_date,@Name,@Age,@Ph_no,@Address,@Gender)";
                cmd.Parameters.AddWithValue("@Reg_date", Reg_date);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Ph_no", Ph_no);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Gender", Gender);



                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully inserted!!!", "Info");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void staffRegClosebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
