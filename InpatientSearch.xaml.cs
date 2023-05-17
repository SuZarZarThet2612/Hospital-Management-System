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
    /// Interaction logic for InpatientSearch.xaml
    /// </summary>
    public partial class InpatientSearch : Window
    {
        public InpatientSearch()
        {
            InitializeComponent();
            LoadIpName();
        }

        private void LoadIpName()
        {
            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select Ipname,Pid from inpatient", conn);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "inpatient");

                sIpnamecmb.ItemsSource = ds.Tables[0].DefaultView;
                sIpnamecmb.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
                sIpnamecmb.SelectedValuePath = ds.Tables[0].Columns[1].ToString();
                sIpnamecmb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }

        }

        private void sIpnamecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Ipid = Convert.ToInt32(sIpnamecmb.SelectedValue.ToString());

            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from inpatient join doctor on Dr_id=Drid where Pid=" + Ipid, conn);
            DataSet ds = new DataSet();


            try
            {
                da.Fill(ds, "hospital");
                DataView dv = ds.Tables[0].DefaultView;


                IpSName.Text = ds.Tables[0].Rows[0][1].ToString();

                IpSAge.Text = ds.Tables[0].Rows[0][3].ToString();
                IpSGender.Text = ds.Tables[0].Rows[0][2].ToString();
                IpSAdr.Text = ds.Tables[0].Rows[0][5].ToString();
                IpSPno.Text = ds.Tables[0].Rows[0][4].ToString();


                IpSDname.Text = ds.Tables[0].Rows[0][10].ToString();
                
                    
                IpSDisease.Text = ds.Tables[0].Rows[0][6].ToString();
                IpSRoomNum.Text = ds.Tables[0].Rows[0][7].ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }

         }

        private void IpsClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
