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
    /// Interaction logic for OutpatientReg.xaml
    /// </summary>
    public partial class OutpatientReg : Window
    {
        public OutpatientReg()
        {
            InitializeComponent();
            LoadDidComboBoxItem();

        }
        public void LoadDidComboBoxItem()
        {
            hospitalDataSet.doctorDataTable mjtb = new hospitalDataSet.doctorDataTable();
            hospitalDataSetTableAdapters.doctorTableAdapter drda = new hospitalDataSetTableAdapters.doctorTableAdapter();
            drda.Fill(mjtb);

            OpDidcmb.ItemsSource = mjtb.DefaultView;
            OpDidcmb.DisplayMemberPath = mjtb.DridColumn.ToString();
            OpDidcmb.SelectedValuePath = mjtb.DridColumn.ToString();
            OpDidcmb.SelectedIndex = 0;
        }




        private void OpSavebtn_Click(object sender, RoutedEventArgs e)
        {
            string Opname =ONameregtxtbox.Text;
            string Age = OAgeregtxtbox.Text;
            string Phone = OPhoneregtxtbox.Text;
            string Address =OAddrregtxtbox.Text;
            string Gender = ((bool)oPMale.IsChecked) ? "Male" : "Female";
            string Disease = ODiseaseregtxtbox.Text;
            string Date =oDateregtxtbox.Text;
            string Dr_id = dr_idtxtbox.Text;
            MessageBox.Show(Opname);



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
                cmd.CommandText = "insert into hospital.outpatient (Opname,Age,Gender,Phone,Address,Disease,Date,Dr_id) values (@Opname,@Age,@Gender,@Phone,@Address,@Disease,@Date,@Dr_id)";
                cmd.Parameters.AddWithValue("@Opname",Opname);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Phone",Phone);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Disease",Disease);
                cmd.Parameters.AddWithValue("@Date",Date);
                cmd.Parameters.AddWithValue("@Dr_id", Dr_id);


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

        private void Opcancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
