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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DocReg.xaml
    /// </summary>
    public partial class DocReg : Window
    {
        public DocReg()
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
            deptcmb.SelectedValuePath = mjtb.Dept_numColumn.ToString();
            deptcmb.SelectedIndex = 0;
        }



        private void dAddbtn_click(object sender, RoutedEventArgs e)
        {
            string Dname = dname.Text;
            string Dept_no = deptcmb.SelectedValue.ToString();
            string Cons_day = dCons_daycmb.Text;
            string Ph_no = dPhno.Text;
            string Address = dAddr.Text;
            string Gender = ((bool)dmale.IsChecked) ? "Male" : "Female";
            string fCons_time = dTfrom.Text + cmb1.Text;
            string tCos_time = dTto.Text + cmb2.Text;
            string Cons_fee = dFee.Text;
            string reg_date = DateTime.Now.ToString();



            MessageBox.Show(Dname);

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



                c1 = conn.CreateCommand();

                c1.CommandText = string.Format("select Ph_no,Dname from doctor");

                rdr = c1.ExecuteReader();

                while (rdr.Read())
                {
                    if (Ph_no.Equals(rdr[0]) && Dname.Equals(rdr[1]))
                    {

                        throw new Exception();


                    }
                }


                rdr.Close();

                cmd = conn.CreateCommand();

                cmd.CommandText = "insert into hospital.doctor (Dname,Dept_no,Gender,Address,Ph_no,Cons_day,fCons_time,tCos_time,Cons_fee,reg_date) values(@Dname,@Dept_no,@Gender,@Address,@Ph_no,@Cons_day,@fCons_time,@tCos_time,@Cons_fee,@reg_date) ";

                cmd.Parameters.AddWithValue("@Dname", Dname);
                cmd.Parameters.AddWithValue("@Dept_no", Dept_no);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Ph_no", Ph_no);
                cmd.Parameters.AddWithValue("@Cons_day", Cons_day);
                cmd.Parameters.AddWithValue("@fCons_time", fCons_time);
                cmd.Parameters.AddWithValue("@tCos_time", tCos_time);
                cmd.Parameters.AddWithValue("@Cons_fee", Cons_fee);
                cmd.Parameters.AddWithValue("@reg_date", reg_date);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully inserted!!!", "Info");



            }
            catch (Exception)
            {
                MessageBox.Show("Your Registration already exit");

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void docCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
