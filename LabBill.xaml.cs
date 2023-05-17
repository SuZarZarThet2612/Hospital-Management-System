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
    /// Interaction logic for LabBill.xaml
    /// </summary>
    public partial class LabBill : Window
    {
        public LabBill()
        {
            InitializeComponent();
            LoadLabNamecmb();

        }


        public void LoadLabNamecmb()
        {

            hospitalDataSet.labDataTable mjtb = new hospitalDataSet.labDataTable();
            hospitalDataSetTableAdapters.labTableAdapter da = new hospitalDataSetTableAdapters.labTableAdapter();
            da.Fill(mjtb);
            lbLabnamecmb.ItemsSource = mjtb.DefaultView;
            lbLabnamecmb.DisplayMemberPath = mjtb.Lab_testColumn.ToString();
            lbLabnamecmb.SelectedValuePath = mjtb.Lab_noColumn.ToString();
            lbLabnamecmb.SelectedIndex = -1;
        }

        private void lbLabnamecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
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


                cmd = conn.CreateCommand();
                int lbno = Convert.ToInt32(lbLabnamecmb.SelectedValue.ToString());
                cmd.CommandText = string.Format("select Lab_test,Charge from lab where Lab_no=" + lbno);

                rdr = cmd.ExecuteReader();
                int total = 0;
                while (rdr.Read())
                {

                    lbnamelb.Items.Add(rdr[0].ToString());
                    lbpricelb.Items.Add(rdr[1].ToString());



                }

                for (int i = 0; i < lbpricelb.Items.Count; i++)
                {
                    total = total + Convert.ToInt32(lbpricelb.Items[i]);
                }


                lbtotal.Text = total.ToString();

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

        private void LbillSavebtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

    
  
