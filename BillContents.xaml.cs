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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for BillContents.xaml
    /// </summary>
    public partial class BillContents : Page
    {
        public BillContents()
        {
            InitializeComponent();
        }

        private void labBill_Click(object sender, RoutedEventArgs e)
        {
            new LabBill().Show();
        }

        private void pharmancyBill_Click(object sender, RoutedEventArgs e)
        {
            new PharmancyBill().Show();
        }

        private void IPbtn_Click(object sender, RoutedEventArgs e)
        {
            new InpatientBill().Show();
        }

        private void Opbtn_Click(object sender, RoutedEventArgs e)
        {
            new OutpatientBill().Show();
        }
    }
}
