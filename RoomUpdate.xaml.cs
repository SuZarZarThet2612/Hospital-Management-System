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
    /// Interaction logic for RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        public RoomUpdate()
        {
            InitializeComponent();
        }
        public void roomStatusUpdate()
        {
         
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string Room_status = ((bool)freerb.IsChecked) ? "Free" : "Not free";
           



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
                int Rno = Convert.ToInt32(RoomNo_txt.Text.ToString());
                cmd.CommandText = "update room set Room_status=@Room_status where Room_no="+Rno;
                cmd.Parameters.AddWithValue("@Room_status",Room_status.ToString());





                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully updated!!!", "Info");

                
                
                else
                { MessageBox.Show("Error in updating"); }

                this.Hide();


            }
            catch
            {
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

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
