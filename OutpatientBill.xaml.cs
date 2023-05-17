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
    /// Interaction logic for OutpatientBill.xaml
    /// </summary>
    public partial class OutpatientBill : Window
    {
        public OutpatientBill()
        {
            InitializeComponent();
            LoadOpIdcmbItems();
        }

        public void LoadOpIdcmbItems()
        {
            hospitalDataSet.outpatientDataTable mjtb = new hospitalDataSet.outpatientDataTable();
            hospitalDataSetTableAdapters.outpatientTableAdapter da = new hospitalDataSetTableAdapters.outpatientTableAdapter();
            da.Fill(mjtb);
            opbidcmb.ItemsSource = mjtb.DefaultView;
            opbidcmb.DisplayMemberPath = mjtb.OpidColumn.ToString();
            opbidcmb.SelectedValuePath = mjtb.OpidColumn.ToString();
            opbidcmb.SelectedIndex = -1;
        }

        private void opbidcmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Opid = Convert.ToInt32(opbidcmb.SelectedValue.ToString());

            string dbstring = @"server=localhost;uid=root;pwd=root;database=hospital;";
            MySqlConnection conn = new MySqlConnection(dbstring);
            MySqlDataAdapter da = new MySqlDataAdapter("select Opname,Date,Phar_charge,Lab_charge from outpatient join bill on Opid=P_id where Opid=" + Opid, conn);
            DataSet ds = new DataSet();


            try
            {
                da.Fill(ds, "hospital");
                DataView dv = ds.Tables[0].DefaultView;


              opbname.Text = ds.Tables[0].Rows[0][0].ToString();
              opbdate.Text = ds.Tables[0].Rows[0][1].ToString();

              opbphar.Text = ds.Tables[0].Rows[0][2].ToString();
              opblab.Text = ds.Tables[0].Rows[0][3].ToString();
             opbtotal.Text= ds.Tables[0].Rows[0][2].ToString()+ds.Tables[0].Rows[0][3].ToString();




            }
            catch (Exception)
            {

                throw;
            }
        }

        private void opbclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    } 
}
