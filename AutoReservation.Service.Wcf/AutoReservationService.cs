using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal.Entities;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoManager AutoManager { get; set; }
        private KundeManager KundeManager { get; set; }
        private ReservationManager ReservationsManager { get; set; }


        public AutoReservationService()
        {
            KundeManager = new KundeManager();
            AutoManager = new AutoManager();
            ReservationsManager = new ReservationManager();
        }


        private static void WriteActualMethod()
            => Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");

        public void AddAuto(Auto auto)
        {
            AutoManager.Add(auto);
        }

        public void AddKunde(KundeDto kunde)
        {
            KundeManager.Add(kunde.ConvertToEntity());
        }

        public void AddReservation(Reservation reservation)
        {
            ReservationsManager.Add(reservation);
        }

        public List<Auto> AutoListe()
        {
            return AutoManager.List;
        }

        public List<Kunde> KundenListe()
        {
            return KundeManager.List;
        }

        public List<Reservation> ReservationenListe()
        {
            return ReservationsManager.List;
        }

        public void RemoveAuto(Auto auto)
        {
            AutoManager.Remove(auto);
        }

        public void RemoveKunde(Kunde kunde)
        {
            KundeManager.Remove(kunde);
        }

        public void RemoveReservation(Reservation reservation)
        {
            ReservationsManager.Remove(reservation);
        }

        public void UpdateAuto(Auto auto)
        {
            AutoManager.Update(auto);
        }

        public void UpdateKunde(Kunde kunde)
        {
            KundeManager.Update(kunde);
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Auto> AutoListeWhereReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Kunde> KundenListeWhereReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> ReservationenListeWhereKunde(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> ReservationenListeWhereAuto(Auto auto)
        {
            throw new NotImplementedException();
        }
    }
}