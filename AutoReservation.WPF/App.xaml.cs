using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.WPF
{
    public partial class App : Application
    {

        private ObservableCollection<KundeDto> kunde = new ObservableCollection<KundeDto>();

        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadCustomerData();
            AutoReservation.WPF.MainWindow mainWindow = new AutoReservation.WPF.MainWindow();
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

            #region Add Persons to customers
            KundeDto kunde1 = new KundeDto();
            this.Kunden.Add(kunde1);

            #endregion
        }

    }
}