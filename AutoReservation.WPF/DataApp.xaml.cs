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
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataApp = this;
            mainWindow.Show();
        }

        public ObservableCollection<KundeDto> Kunden { get; set; } = new ObservableCollection<KundeDto>();

        public void LoadCustomerData()
        {
            var list = Target.KundenListe();

            this.Kunden.Clear();
            foreach (var item in list)
            {
                this.Kunden.Add(item);
            }
        }

    }
}