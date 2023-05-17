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
    /// Interaction logic for InpatientBill.xaml
    /// </summary>
    public partial class InpatientBill : Window
    {
        public InpatientBill()
        {
            InitializeComponent();
            LoadInpatientidcmb();
        }

        private void PatientID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Pid = Convert.ToInt32(IpPidcmb.SelectedValue.ToString());

            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select IpName,Reg_date,Proom_no,Room_price from inpatient join room on Proom_no=Room_no where Pid="+Pid, conn);
            DataSet ds = new DataSet();


            try
            {
                da.Fill(ds, "hospital");
                DataView dv = ds.Tables[0].DefaultView;


                Ipnametxtbox.Text = ds.Tables[0].Rows[0][0].ToString();

                IpReg_Datetxt.Text = ds.Tables[0].Rows[0][1].ToString();
               
                Iproomtxt.Text = ds.Tables[0].Rows[0][2].ToString();
                Ipamounttxt.Text = ds.Tables[0].Rows[0][3].ToString();
                



            }
            catch (Exception)
            {

                throw;
            }


        }



    public void LoadInpatientidcmb()
        {

            hospitalDataSet.inpatientDataTable mjtb = new hospitalDataSet.inpatientDataTable();
            hospitalDataSetTableAdapters.inpatientTableAdapter da = new hospitalDataSetTableAdapters.inpatientTableAdapter();
            da.Fill(mjtb);
            IpPidcmb.ItemsSource = mjtb.DefaultView;
            IpPidcmb.DisplayMemberPath = mjtb.PidColumn.ToString();
            IpPidcmb.SelectedValuePath = mjtb.PidColumn.ToString();
            IpPidcmb.SelectedIndex = -1;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
