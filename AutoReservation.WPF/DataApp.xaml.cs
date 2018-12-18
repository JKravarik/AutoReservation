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
    public partial class DataApp : Application
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

        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadCustomerData();
            LoadAutoData();
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataApp = this;
            mainWindow.Show();
        }

        public ObservableCollection<KundeDto> Kunden { get; set; } = new ObservableCollection<KundeDto>();
        public ObservableCollection<AutoDto> Autos { get; set; } = new ObservableCollection<AutoDto>();
        public ObservableCollection<ReservationDto> Reservations { get; set; } = new ObservableCollection<ReservationDto>();

        public void LoadCustomerData()
        {
            var list = Target.KundenListe();

            this.Kunden.Clear();
            foreach (var item in list)
            {
                this.Kunden.Add(item);
            }
        }

        public void LoadAutoData()
        {
            var list = Target.AutoListe();

            this.Autos.Clear();
            foreach (var item in list)
            {
                this.Autos.Add(item);
            }
        }

        public void LoadReservationData()
        {
            var list = Target.ReservationenListe();

            this.Reservations.Clear();
            foreach (var item in list)
            {
                this.Reservations.Add(item);
            }
        }
    }
}