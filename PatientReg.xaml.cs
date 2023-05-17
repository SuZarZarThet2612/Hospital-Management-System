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
    /// Interaction logic for PatientReg.xaml
    /// </summary>
    public partial class PatientReg : Window
    {
        public PatientReg()
        {
            InitializeComponent();
            LoadComboBoxItems();
            IpViewRoomdgr.UpdateLayout();
        }





        public void LoadComboBoxItems()
        {
            hospitalDataSet.doctorDataTable ipdid = new hospitalDataSet.doctorDataTable();
            hospitalDataSetTableAdapters.doctorTableAdapter da = new hospitalDataSetTableAdapters.doctorTableAdapter();
            da.Fill(ipdid);

            IpDrIdcmb.ItemsSource = ipdid.DefaultView;
            IpDrIdcmb.DisplayMemberPath = ipdid.DnameColumn.ToString();
            IpDrIdcmb.SelectedValuePath = ipdid.DridColumn.ToString();
            IpDrIdcmb.SelectedIndex = 0;
        }

        public void pregbtn1_Click(object sender, RoutedEventArgs e)
        {

          
            string Ipname =pname.Text;
            string  Age=page.Text;
            string Ph_no =pphone.Text;
            string Address = padd.Text;
            string Gender = ((bool)pmalerbtn.IsChecked) ? "Male" : "Female";
            string Disease =pdisease.Text;
            int Dr_id =Convert.ToInt16(IpDrIdcmb.SelectedValue.ToString());
            string Proom_no = ProomNotxtbox.Text;
            string Reg_date = DateTime.Now.ToString();



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
                cmd.CommandText = "insert into hospital.inpatient (Ipname,Gender,Age,Ph_no,Address,Disease,Proom_no,Dr_id,Reg_date) values (@Ipname,@Gender,@Age,@Ph_no,@Address,@Disease,@Proom_no,@Dr_id,@Reg_date)";
                cmd.Parameters.AddWithValue("@Ipname",Ipname);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Ph_no", Ph_no);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Disease", Disease);
                cmd.Parameters.AddWithValue("@Proom_no", Proom_no);
                cmd.Parameters.AddWithValue("@Dr_id", Dr_id);
                cmd.Parameters.AddWithValue("@Reg_date", Reg_date);


                
                


                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully inserted!!!", "Info");

                new RoomUpdate().Show();
               

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

        private void pregbtn2_Click(object sender, RoutedEventArgs e)
        {

            hospitalDataSet.roomDataTable room = new hospitalDataSet.roomDataTable();
            hospitalDataSetTableAdapters.roomTableAdapter da = new hospitalDataSetTableAdapters.roomTableAdapter();
            da.Fill(room);

           
        }

        private void pregbtn3_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
