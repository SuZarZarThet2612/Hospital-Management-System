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
    /// Interaction logic for RegContents.xaml
    /// </summary>
    public partial class RegContents : Page
    {
        public RegContents()
        {
            InitializeComponent();
        }

        private void doctor_Click(object sender, RoutedEventArgs e)
        {
            new DocReg().Show();
        
            
        }

        private void staff_Click(object sender, RoutedEventArgs e)
        {
            new staffReg().Show();
        }

        private void inpatient_Click(object sender, RoutedEventArgs e)
        {
            new PatientReg().Show();
        }

        private void outpatient_Click(object sender, RoutedEventArgs e)
        {
            new OutpatientReg().Show();
        }

        private void nurse_click(object sender, RoutedEventArgs e)
        {
            new nurseReg().Show();
        }
    }
}
