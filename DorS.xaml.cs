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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DorS.xaml
    /// </summary>
    public partial class DorS : Page
    {
        public DorS()
        {
            InitializeComponent();
        }

        private void docbutton_Click(object sender, RoutedEventArgs e)
        {
            new Changepwd().Show();
        }

        private void staffbtn_Click(object sender, RoutedEventArgs e)
        {
            new Schangepwd().Show();
        }

    }
}
