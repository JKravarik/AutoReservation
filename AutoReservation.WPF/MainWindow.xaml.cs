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
        CollectionViewSource listingAutoDataView;
        CollectionViewSource listingReservationDataView;
        KundeDto Kunde { get; set; }
        AutoDto Auto { get; set; }
        ReservationDto Reservation { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            listingKundenDataView = (CollectionViewSource)(this.Resources["listingKundenDataView"]);
            listingAutoDataView = (CollectionViewSource)(this.Resources["listingAutoDataView"]);
            listingReservationDataView = (CollectionViewSource)(this.Resources["listingReservationDataView"]);

            if (TabKunde.IsSelected)
            {
                this.DataContext = Kunde;
            }
            else if (TabAuto.IsSelected)
            {
                this.DataContext = Auto;
            }
            else if (TabReservation.IsSelected)
            {
                this.DataContext = Reservation;
            }
            
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            KundenDetail.IsEnabled = true;
            KundeSpeichern.IsEnabled = true;
            Kunde = new KundeDto();
            DataContext = Kunde;
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
            KundenDetail.IsEnabled = false;
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


        private void AddCar(object sender, RoutedEventArgs e)
        {
            AutoDetail.IsEnabled = true;
            AutoSpeichern.IsEnabled = true;
            Auto = new AutoDto();
            DataContext = Auto;
        }

        private void RemoveCar(object sender, RoutedEventArgs e)
        {
            DataBase.RemoveAuto(Auto);
            DataApp.LoadAutoData();
        }

        private void EditCar(object sender, RoutedEventArgs e)
        {
            AutoDetail.IsEnabled = true;
            AutoSpeichern.IsEnabled = true;
        }

        private void SaveCar(object sender, RoutedEventArgs e)
        {
            if (Auto.Id > 0)
            {
                DataBase.UpdateAuto(Auto);
            }
            else
            {
                DataBase.AddAuto(Auto);
            }
            DataApp.LoadAutoData();
            AutoSpeichern.IsEnabled = false;
            AutoDetail.IsEnabled = false;
        }

        private void AutoListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Auto = (AutoDto)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem;
            }
            catch
            {
                Auto = new AutoDto();
            }
            DataContext = Auto;
        }




        private void AddRes(object sender, RoutedEventArgs e)
        {
            ReservationDetail.IsEnabled = true;
            ResSpeichern.IsEnabled = true;
            Reservation = new ReservationDto();
            DataContext = Reservation;
        }

        private void RemoveRes(object sender, RoutedEventArgs e)
        {
            DataBase.RemoveReservation(Reservation);
            DataApp.LoadReservationData();
        }

        private void EditRes(object sender, RoutedEventArgs e)
        {
            ReservationDetail.IsEnabled = true;
            ResSpeichern.IsEnabled = true;
        }

        private void SaveRes(object sender, RoutedEventArgs e)
        {
            if (Auto.Id > 0)
            {
                DataBase.UpdateReservation(Reservation);
            }
            else
            {
                DataBase.AddReservation(Reservation);
            }
            DataApp.LoadReservationData();
            ResSpeichern.IsEnabled = false;
            ReservationDetail.IsEnabled = false;
        }

        private void ResListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Reservation = (ReservationDto)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem;
            }
            catch
            {
                Reservation = new ReservationDto();
            }
            DataContext = Reservation;
        }
    }
}
