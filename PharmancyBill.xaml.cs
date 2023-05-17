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
    /// Interaction logic for PharmancyBill.xaml
    /// </summary>
    public partial class PharmancyBill : Window
    {
        public PharmancyBill()
        {
            InitializeComponent();
            loadpharmbillcmbItem();
        }
        public void loadpharmbillcmbItem()
        {
            hospitalDataSet.medicineDataTable mjtb = new hospitalDataSet.medicineDataTable();
            hospitalDataSetTableAdapters.medicineTableAdapter da = new hospitalDataSetTableAdapters.medicineTableAdapter();
            da.Fill(mjtb);
            pharcmb.ItemsSource = mjtb.DefaultView;
            pharcmb.DisplayMemberPath = mjtb.Med_nameColumn.ToString();
            pharcmb.SelectedValuePath = mjtb.Med_idColumn.ToString();
            pharcmb.SelectedIndex = -1;

        }


        private void phsavebtn_Click(object sender, RoutedEventArgs e)
        {
            string Phar_charge = phartotaltxtbox.Text;
            string P_id = phPidtxtbox.Text;

            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd, c1;
            MySqlDataReader rdr;

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();

                c1 = conn.CreateCommand();

                c1.CommandText = string.Format("select P_id from bill");

                rdr = c1.ExecuteReader();

                while (rdr.Read())
                {
                    if (P_id.Equals(rdr[0]))
                    {

                        cmd.CommandText = "update hospital.bill set Phar_charge=@Phar_charge where P_id=" + P_id;

                       
                        cmd.Parameters.AddWithValue("@Phar_charge", Phar_charge);

                        

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Successfully inserted!!!", "Info");


                    }
                    
                    else
                    {
                        cmd.CommandText = "insert into hospital.bill (Phar_charge) values (@Phar_charge)";

                        cmd.Parameters.AddWithValue("@Phar_charge", Phar_charge);



                        int j= cmd.ExecuteNonQuery();
                        if (j > 0)
                            MessageBox.Show("Successfully inserted!!!", "Info");


                    }
                    rdr.Close();
                }

               






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

        public void pharcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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


                cmd =conn.CreateCommand();
                int medid = Convert.ToInt32(pharcmb.SelectedValue.ToString());
                cmd.CommandText = string.Format("select Med_name,price from medicine where Med_id="+medid);

                rdr = cmd.ExecuteReader();
                int total = 0; 
                while (rdr.Read())
                {
                    
                    mednameLb.Items.Add(rdr[0].ToString());
                    medpricelb.Items.Add(rdr[1].ToString());
                    
                    

                }

                for(int i=0;i<medpricelb.Items.Count; i++)
                {
                    total = total + Convert.ToInt32(medpricelb.Items[i]);
                }
               
              
            phartotaltxtbox.Text= total.ToString();

            rdr.Close();
               

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void pharCancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}