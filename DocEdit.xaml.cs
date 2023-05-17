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
    /// Interaction logic for DocEdit.xaml
    /// </summary>
    public partial class DocEdit : Window
    {
        public DocEdit()
        {
            InitializeComponent();
            LoadDidComboBoxItem();
        }

        public void LoadDidComboBoxItem()
        {
            hospitalDataSet.doctorDataTable mjtb = new hospitalDataSet.doctorDataTable();
            hospitalDataSetTableAdapters.doctorTableAdapter drda = new hospitalDataSetTableAdapters.doctorTableAdapter();
            drda.Fill(mjtb);

            edNamecmb.ItemsSource = mjtb.DefaultView;
            edNamecmb.DisplayMemberPath = mjtb.DnameColumn.ToString();
            edNamecmb.SelectedValuePath = mjtb.DridColumn.ToString();
            edNamecmb.SelectedIndex = -1;
        }

        private void edNamecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnName = edNamecmb.Text;
            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd;

            MySqlDataReader rdr;
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("select fCons_time,tCos_time,Address,Ph_no from doctor");
                rdr = cmd.ExecuteReader();
                rdr.Read();
                edTFrom.Text = rdr[0].ToString();
                edTTo.Text = rdr[1].ToString();
                edAddr.Text = rdr[2].ToString();
                edPhno.Text = rdr[3].ToString();
                rdr.Close();



            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }

        }

        private void edUpdatebtn_Click(object sender, RoutedEventArgs e)
        {
            string fCons_time = edTFrom.Text;
            string tCos_time= edTTo.Text;
            string Address = edAddr.Text;
            string Ph_no= edPhno.Text;



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
                int Drid = Convert.ToInt32(edNamecmb.SelectedValue.ToString());
                cmd.CommandText = "update doctor set fCons_time=@fCons_time,tCos_time=@tCos_time,Address=@Address,Ph_no=@Ph_no where Drid=@Drid";
                cmd.Parameters.AddWithValue("@fCons_time", fCons_time);
                cmd.Parameters.AddWithValue("@tCos_time", tCos_time);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Ph_no", Ph_no);



                cmd.Parameters.AddWithValue("@Drid", Drid.ToString());





                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully updated!!!", "Info");
                else
                { MessageBox.Show("Error in updating"); }




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

        private void edCancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
