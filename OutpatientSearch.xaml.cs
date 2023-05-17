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
    /// Interaction logic for OutpatientSearch.xaml
    /// </summary>
    public partial class OutpatientSearch : Window
    {
        public OutpatientSearch()
        {
            InitializeComponent();
            LoadOpName();



        }

        private void LoadOpName()
        {
            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select Opname,Opid from outpatient", conn);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "outpatient");

                OpsnameCmb.ItemsSource = ds.Tables[0].DefaultView;
                OpsnameCmb.DisplayMemberPath = ds.Tables[0].Columns[0].ToString();
                OpsnameCmb.SelectedValuePath = ds.Tables[0].Columns[1].ToString();
                OpsnameCmb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }

        }



        private void OpClosebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpsnameCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int OpId = Convert.ToInt32(OpsnameCmb.SelectedValue.ToString());

            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from outpatient join doctor on Dr_id=Drid where Opid=" + OpId, conn);
            DataSet ds = new DataSet();


            try
            {
                da.Fill(ds, "hospital");
                DataView dv = ds.Tables[0].DefaultView;
                OpSPname.Text = ds.Tables[0].Rows[0][1].ToString();

                OpSAdr.Text = ds.Tables[0].Rows[0][5].ToString();
                OpSPname.Text = ds.Tables[0].Rows[0][1].ToString();
                OpSAge.Text = ds.Tables[0].Rows[0][2].ToString();
                OpSPno.Text = ds.Tables[0].Rows[0][4].ToString();
                OpSDisease.Text = ds.Tables[0].Rows[0][6].ToString();

                OpSDname.Text = ds.Tables[0].Rows[0][10].ToString();
                OpSGender.Text = ds.Tables[0].Rows[0][3].ToString();
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
        }
    }
}
