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
    /// Interaction logic for UpdateContents.xaml
    /// </summary>
    public partial class UpdateContents : Page
    {
        public UpdateContents()
        {
            InitializeComponent();
        }

        private void Med_updatebtn_Click(object sender, RoutedEventArgs e)
        {
            new MedicineUpdate().Show();
        }

        private void Doc_updatebtn_Click(object sender, RoutedEventArgs e)
        {
            new DocEdit().Show();
        }

        private void Room_updatebtn_Click(object sender, RoutedEventArgs e)
        {
            new RoomUpdate().Show();
        }
    }
}
