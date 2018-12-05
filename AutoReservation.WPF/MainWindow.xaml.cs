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

namespace AutoReservation.WPF
{
    public partial class MainWindow : Window
    {
        CollectionViewSource listingKundenDataView;

        public MainWindow()
        {
            InitializeComponent();
            listingKundenDataView = (CollectionViewSource)(this.Resources["listingKundenDataView"]);
        }

        private void OpenAddCustomerWindow(object sender, RoutedEventArgs e)
        {
            //AddProductWindow addProductWindow = new AddProductWindow();
            //addProductWindow.ShowDialog();
        }
    }
}
