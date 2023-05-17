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
    /// Interaction logic for showAppointment.xaml
    /// </summary>
    public partial class showAppointment : Window
    {
        public showAppointment()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }

        public void LoadComboBoxItems()
        {
            hospitalDataSet.doctorDataTable mjtb = new hospitalDataSet.doctorDataTable();
            hospitalDataSetTableAdapters.doctorTableAdapter da = new hospitalDataSetTableAdapters.doctorTableAdapter();
            da.Fill(mjtb);

            viewappcmb.ItemsSource = mjtb.DefaultView;
            viewappcmb.DisplayMemberPath = mjtb.DridColumn.ToString();
            viewappcmb.SelectedValuePath = mjtb.DridColumn.ToString();
            viewappcmb.SelectedIndex = -1;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
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
                string Date = vappdatep.Text;
                int did = Convert.ToInt32(viewappcmb.SelectedValue.ToString());
                cmd.CommandText = "select Pname,Date from appointment where Date = '" + Date + "' AND Dr_id = '" + did + "'";

               
                MySqlDataAdapter docAdap = new MySqlDataAdapter(cmd);
                DataSet docDset = new DataSet();
                docAdap.Fill(docDset);
                appdatagrid.ItemsSource = docDset.Tables[0].DefaultView;

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

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
