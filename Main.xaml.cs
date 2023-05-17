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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void RegBtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new RegContents();
        }

        private void SearchBtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new SearchContents();
        }

        private void updatebtnc(object sender, RoutedEventArgs e)
        {

        }

        private void updatebtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new UpdateContents();
        }

        private void apmBtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new ApmContents();
        }

        private void billBtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new BillContents();

        }

        

        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void chBtnClick(object sender, RoutedEventArgs e)
        {
            frame1.Content = new DorS();
        }
    }
}
