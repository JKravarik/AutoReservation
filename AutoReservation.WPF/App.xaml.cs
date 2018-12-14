using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using System.ServiceModel;

namespace AutoReservation.WPF
{
    public partial class App : Application
    {
        private IAutoReservationService target;
        protected IAutoReservationService Target
        {
            get
            {
                if (target == null)
                {
                    ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
                    target = channelFactory.CreateChannel();
                }
                return target;
            }
        }
        private ObservableCollection<KundeDto> kunde = new ObservableCollection<KundeDto>();

        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadCustomerData();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //AddProductWindow addProductWindow = new AddProductWindow();
            //addProductWindow.Show();
        }



        public ObservableCollection<KundeDto> Kunden
        {
            get { return this.kunde; }
            set { this.kunde = value; }
        }

        private void LoadCustomerData()
        {
            var list = Target.KundenListe();

            foreach (var item in list)
            {
                this.Kunden.Add(item);
            }
            //#region Add Persons to customers
            //KundeDto kunde1 = new KundeDto
            //{
            //    Nachname = "Müller",
            //    Vorname = "Lisa",
            //    Geburtsdatum = new DateTime(1994, 12, 6)
            //};
            //KundeDto kunde2 = new KundeDto
            //{
            //    Nachname = "Müller",
            //    Vorname = "Peter",
            //    Geburtsdatum = new DateTime(1994, 5, 6)
            //};
            //this.Kunden.Add(kunde1);
            //this.Kunden.Add(kunde2);
            //#endregion
        }

    }
}