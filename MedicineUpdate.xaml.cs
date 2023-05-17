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
    /// Interaction logic for MedicineUpdate.xaml
    /// </summary>
    public partial class MedicineUpdate : Window
    {
        public MedicineUpdate()
        {
            InitializeComponent();
            LoadMedicineName();
            medDataGrid.UpdateLayout();
        }

        public void LoadMedicineName()
        {
            hospitalDataSet.medicineDataTable medname = new hospitalDataSet.medicineDataTable();
            hospitalDataSetTableAdapters.medicineTableAdapter da = new hospitalDataSetTableAdapters.medicineTableAdapter();
            da.Fill(medname);

            medUpcmb.ItemsSource = medname.DefaultView;
            medUpcmb.DisplayMemberPath = medname.Med_nameColumn.ToString();
            medUpcmb.SelectedValuePath = medname.Med_idColumn.ToString();
            medUpcmb.SelectedIndex = -1;

            medDataGrid.ItemsSource = medname.DefaultView;
        }

      


        private void save_Click_1(object sender, RoutedEventArgs e)
        {

            string Exp_date = medExDtxt.Text;
            string price = medPricetxt.Text;
            


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
                int medid = Convert.ToInt32(medUpcmb.SelectedValue.ToString());
                cmd.CommandText = "update medicine set Exp_date=@Exp_date,price=@price where Med_id=@medid" ;
                cmd.Parameters.AddWithValue("@Exp_date", Exp_date);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@medid", medid.ToString());
          

                


                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully updated!!!", "Info");
                else
                { MessageBox.Show("Error in updating"); }


                hospitalDataSet.medicineDataTable medname = new hospitalDataSet.medicineDataTable();
                hospitalDataSetTableAdapters.medicineTableAdapter da = new hospitalDataSetTableAdapters.medicineTableAdapter();
                da.Fill(medname);
                medDataGrid.ItemsSource = medname.DefaultView;
                medDataGrid.UpdateLayout();

            }
            catch(Exception)
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

        private void medUpcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnName = medUpcmb.Text;
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
                int medid = Convert.ToInt32(medUpcmb.SelectedValue.ToString());

                cmd.CommandText = string.Format("select Exp_date,price from medicine where med_id="+medid);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                medExDtxt.Text = rdr[0].ToString();
                medPricetxt.Text = rdr[1].ToString();
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

        private void medCacelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
