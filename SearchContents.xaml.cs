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
    /// Interaction logic for SearchContents.xaml
    /// </summary>
    public partial class SearchContents : Page
    {
        public SearchContents()
        {
            InitializeComponent();
        }

        private void Search_doctor_Click(object sender, RoutedEventArgs e)
        {
            new SearchDoctor().Show();
        }

        private void Search_inpatient_Click(object sender, RoutedEventArgs e)
        {
            new InpatientSearch().Show();
        }

        private void Search_outpatient_Click(object sender, RoutedEventArgs e)
        {
            new OutpatientSearch().Show();
        }
    }
}
