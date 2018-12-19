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

            AutoKlasseDTKey.ItemsSource = Enum.GetValues(typeof(AutoKlasse));

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
            KundenListe.IsEnabled = false;
            TabAuto.IsEnabled = false;
            TabReservation.IsEnabled = false;
            KundeHinzufügen.IsEnabled = false;
            KundeEdit.IsEnabled = false;
            Kunde = new KundeDto();
            DataContext = Kunde;
        }

        private void RemoveCustomer (object sender, RoutedEventArgs e)
        {
            DataBase.RemoveKunde(Kunde);
            DataApp.LoadCustomerData();
            KundenListe.IsEnabled = true;
            TabAuto.IsEnabled = true;
            TabReservation.IsEnabled = true;
            KundeSpeichern.IsEnabled = false;
            KundeLöschen.IsEnabled = false;
            KundenDetail.IsEnabled = false;
            KundeHinzufügen.IsEnabled = true;
            KundeEdit.IsEnabled = true;
        }

        private void EditCustomer (object sender, RoutedEventArgs e)
        {
            KundenDetail.IsEnabled = true;
            KundeSpeichern.IsEnabled = true;
            KundeLöschen.IsEnabled = true;
            KundenListe.IsEnabled = false;
            TabAuto.IsEnabled = false;
            TabReservation.IsEnabled = false;
            KundeHinzufügen.IsEnabled = false;
            KundeEdit.IsEnabled = false;
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
            KundenListe.IsEnabled = true;
            TabAuto.IsEnabled = true;
            TabReservation.IsEnabled = true;
            KundeSpeichern.IsEnabled = false;
            KundeLöschen.IsEnabled = false;
            KundenDetail.IsEnabled = false;
            KundeHinzufügen.IsEnabled = true;
            KundeEdit.IsEnabled = true;
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
            AutoListe.IsEnabled = false;
            TabKunde.IsEnabled = false;
            TabReservation.IsEnabled = false;
            AutoHinzufügen.IsEnabled = false;
            AutoEdit.IsEnabled = false;
            Auto = new AutoDto();
            DataContext = Auto;
            AutoKlasseDTKey.SelectedItem = null;
        }

        private void RemoveCar(object sender, RoutedEventArgs e)
        {
            DataBase.RemoveAuto(Auto);
            DataApp.LoadAutoData();
            AutoListe.IsEnabled = true;
            TabKunde.IsEnabled = true;
            TabReservation.IsEnabled = true;
            AutoSpeichern.IsEnabled = false;
            AutoLöschen.IsEnabled = false;
            AutoDetail.IsEnabled = false;
            AutoHinzufügen.IsEnabled = true;
            AutoEdit.IsEnabled = true;
        }

        private void EditCar(object sender, RoutedEventArgs e)
        {
            AutoDetail.IsEnabled = true;
            AutoSpeichern.IsEnabled = true;
            AutoLöschen.IsEnabled = true;
            AutoListe.IsEnabled = false;
            TabKunde.IsEnabled = false;
            TabReservation.IsEnabled = false;
            AutoHinzufügen.IsEnabled = false;
            AutoEdit.IsEnabled = false;
        }

        private void SaveCar(object sender, RoutedEventArgs e)
        {
            if (AutoKlasseDTKey.SelectedItem == null)
            {
                MessageBox.Show("Die Autoklasse muss ausgefüllt werden.");
                return;
            }
            Auto.AutoKlasse = (AutoKlasse)AutoKlasseDTKey.SelectedItem;

            if (Auto.Id > 0)
            {
                DataBase.UpdateAuto(Auto);
            }
            else
            {
                DataBase.AddAuto(Auto);
            }
            DataApp.LoadAutoData();
            AutoListe.IsEnabled = true;
            TabKunde.IsEnabled = true;
            TabReservation.IsEnabled = true;
            AutoSpeichern.IsEnabled = false;
            AutoLöschen.IsEnabled = false;
            AutoDetail.IsEnabled = false;
            AutoHinzufügen.IsEnabled = true;
            AutoEdit.IsEnabled = true;
        }

        private void AutoListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Auto = (AutoDto)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem;
                AutoKlasseDTKey.SelectedItem = Auto.AutoKlasse;
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
            ReservationListe.IsEnabled = false;
            TabKunde.IsEnabled = false;
            TabAuto.IsEnabled = false;
            ResHinzufügen.IsEnabled = false;
            ResEdit.IsEnabled = false;
            Reservation = new ReservationDto();
            DataContext = Reservation;
            ResAutoDTKey.SelectedItem = null;
            ResKundeDTKey.SelectedItem = null;
        }

        private void RemoveRes(object sender, RoutedEventArgs e)
        {
            DataBase.RemoveReservation(Reservation);
            DataApp.LoadReservationData();
            ReservationListe.IsEnabled = true;
            TabKunde.IsEnabled = true;
            TabAuto.IsEnabled = true;
            ResSpeichern.IsEnabled = false;
            ResLöschen.IsEnabled = false;
            ReservationDetail.IsEnabled = false;
            ResHinzufügen.IsEnabled = true;
            ResEdit.IsEnabled = true;
        }

        private void EditRes(object sender, RoutedEventArgs e)
        {
            ReservationDetail.IsEnabled = true;
            ResSpeichern.IsEnabled = true;
            ResLöschen.IsEnabled = true;
            ReservationListe.IsEnabled = false;
            TabKunde.IsEnabled = false;
            TabAuto.IsEnabled = false;
            ResHinzufügen.IsEnabled = false;
            ResEdit.IsEnabled = false;
        }

        private void SaveRes(object sender, RoutedEventArgs e)
        {
            if (!IsResSaveable())
            {
                MessageBox.Show("Auto und Kunde müssen angegeben werden", "Speicherfehler", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Reservation.ReservationsNr > 0)
            {
                DataBase.UpdateReservation(Reservation);
            }
            else
            {
                DataBase.AddReservation(Reservation);
            }
            DataApp.LoadReservationData();
            ReservationListe.IsEnabled = true;
            TabKunde.IsEnabled = true;
            TabAuto.IsEnabled = true;
            ResSpeichern.IsEnabled = false;
            ResLöschen.IsEnabled = false;
            ReservationDetail.IsEnabled = false;
            ResHinzufügen.IsEnabled = true;
            ResEdit.IsEnabled = true;
        }

        private bool IsResSaveable()
        {
            if (Reservation.Auto != null && Reservation.Kunde != null)
            {
                return true;
            }
            if(ResAutoDTKey.SelectedValue == null || ResKundeDTKey.SelectedValue == null)
            {
                return false;
            }
            Reservation.Auto = DataBase.GetAutoById((int)ResAutoDTKey.SelectedValue);
            Reservation.Kunde = DataBase.GetKundeById((int)ResKundeDTKey.SelectedValue);
            return true;
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
            if(Reservation.Auto != null)
            {
                ResAutoDTKey.SelectedValue = Reservation.Auto.Id;
            }
            if(Reservation.Kunde != null)
            {
                ResKundeDTKey.SelectedValue = Reservation.Kunde.Id;
            }
        }


        private bool updateItemsource = true;
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            if (tabItem == "Reservation" && updateItemsource)
            {
                ResKundeDTKey.ItemsSource = DataBase.KundenListe();
                ResAutoDTKey.ItemsSource = DataBase.AutoListe();
                updateItemsource = false;
            }
            else if(tabItem != "Reservation")
            {
                updateItemsource = true;
            }
        }
    }
}
