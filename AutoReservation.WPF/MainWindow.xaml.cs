using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private IAutoReservationService dataBase;
        protected IAutoReservationService DataBase => dataBase ?? (dataBase = new AutoReservationService());

        public DataApp DataApp { get; set; }

        CollectionViewSource listingKundenDataView;
        KundeDto Kunde { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            listingKundenDataView = (CollectionViewSource)(this.Resources["listingKundenDataView"]);
            this.DataContext = Kunde;
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            KundenDetail.IsEnabled = true;
            NachnameDTKey.Text = "";
            VornameDTKey.Text = "";
            GeburtsdatumDTKey.Text = "";
            KundeSpeichern.IsEnabled = true;
            IdDTKey.Text = "";
        }

        private void RemoveCustomer (object sender, RoutedEventArgs e)
        {
            DataBase.RemoveKunde(Kunde);
            DataApp.LoadCustomerData();
        }

        private void EditCustomer (object sender, RoutedEventArgs e)
        {
            KundenDetail.IsEnabled = true;
            KundeSpeichern.IsEnabled = true;
        }

        private void SaveCustomer(object sender, RoutedEventArgs e)
        {
            if(Kunde.Id > 0)
            {
                DataBase.UpdateKunde(Kunde);
            }
            else
            {
                DataBase.AddKunde(Kunde);
            }
            DataApp.LoadCustomerData();
            KundeSpeichern.IsEnabled = false;
        }

        private void KundenListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Kunde = (KundeDto)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem;
            }
            catch
            {
                Kunde = new KundeDto();
            }
            DataContext = Kunde;
        }
    }
}
