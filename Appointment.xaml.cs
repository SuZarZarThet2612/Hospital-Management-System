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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }

        public void LoadComboBoxItems()
        {
            hospitalDataSet.departmentDataTable mjtb = new hospitalDataSet.departmentDataTable();
            hospitalDataSetTableAdapters.departmentTableAdapter da = new hospitalDataSetTableAdapters.departmentTableAdapter();
            da.Fill(mjtb);

            deptcmb.ItemsSource = mjtb.DefaultView;
            deptcmb.DisplayMemberPath = mjtb.Dept_nameColumn.ToString();
            deptcmb.SelectedValuePath = mjtb.Dept_noColumn.ToString();
            deptcmb.SelectedIndex = -1;
        }

        private void deptcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                int deptno = Convert.ToInt32(deptcmb.SelectedValue.ToString());

                cmd.CommandText = string.Format("select Drid,Dname,Cons_day,fCons_time,tCos_time from doctor where Dept_no=" + deptno);

                MySqlDataAdapter docAdap = new MySqlDataAdapter(cmd);
                DataSet docDset = new DataSet();
                docAdap.Fill(docDset);
                docDgrid.ItemsSource = docDset.Tables[0].DefaultView;

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

        private void confirmbtn_Click(object sender, RoutedEventArgs e)
        {
            int Dr_id = Convert.ToInt16(didtxt.Text.ToString());
            string Pname = appNametxt.Text;
            string Date = appdate.Text;



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
                cmd.CommandText = "insert into hospital.appointment (Dr_id,Pname,Date) values (@Dr_id,@Pname,@Date)";
                cmd.Parameters.AddWithValue("@Dr_id", Dr_id);
                cmd.Parameters.AddWithValue("@Pname", Pname);
                cmd.Parameters.AddWithValue("@Date", Date);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully inserted!!!", "Info");

            }
            catch (Exception)
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

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

