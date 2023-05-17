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
    /// Interaction logic for SearchDoctor.xaml
    /// </summary>
    public partial class SearchDoctor : Window
    {
        public SearchDoctor()
        {
            InitializeComponent();
            LoadDrName();
            
        }
        private void LoadDrName()
        {
            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select Drid,Dname from doctor", conn);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "doctor");

                SdrNamecmb.ItemsSource = ds.Tables[0].DefaultView;
                SdrNamecmb.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
                SdrNamecmb.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
                SdrNamecmb.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }

        }

        private void SdrNamecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int drid = Convert.ToInt32(SdrNamecmb.SelectedValue.ToString());

            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from doctor where Drid=" + drid, conn);
            DataSet ds = new DataSet();


            try
            {
                da.Fill(ds, "hospital");
                DataView dv = ds.Tables[0].DefaultView;


                sdrName.Text = ds.Tables[0].Rows[0][1].ToString();
            
                sdrGender.Text = ds.Tables[0].Rows[0][3].ToString();
                sdrAddr.Text = ds.Tables[0].Rows[0][4].ToString();
                sdrPhno.Text = ds.Tables[0].Rows[0][5].ToString();
                sdrfCons_T.Text = ds.Tables[0].Rows[0][7].ToString();
                sdrtCons_T.Text = ds.Tables[0].Rows[0][8].ToString();
                sdrDept.Text = ds.Tables[0].Rows[0][2].ToString();



            }
            catch(Exception)
            {
                
                throw;
            }


        }

        private void sdocbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
