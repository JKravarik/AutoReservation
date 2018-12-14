using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;
using AutoReservation.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        #region Add
        public void AddAuto(AutoDto auto)
        {
            AutoManager.Add(auto.ConvertToEntity());
        }

        public void AddKunde(KundeDto kunde)
        {
            KundeManager.Add(kunde.ConvertToEntity());
        }

        public void AddReservation(ReservationDto reservation)
        {
            if (reservation.Auto == null || reservation.Kunde == null)
            {
                throw new ArgumentException("Reservation muss ein Auto und ein Kunde besitzen um gespeichert zu werden.");
            }
            if (IsCarAvailable(reservation.Auto, reservation))
            {
                ReservationsManager.Add(reservation.ConvertToEntity());
            }
            else
            {
                throw new ArgumentException("Das Auto ist in dieser Zeitspanne nicht verfügbar.");
            }
        }
        #endregion

        #region Lists
        public List<AutoDto> AutoListe()
        {
            return AutoManager.List.ConvertToDtos();
        }

        public List<KundeDto> KundenListe()
        {
            return KundeManager.List.ConvertToDtos();
        }

        public List<ReservationDto> ReservationenListe()
        {
            return ReservationsManager.List.ConvertToDtos();
        }
        #endregion

        #region Remove
        public void RemoveAuto(AutoDto auto)
        {
            AutoManager.Remove(auto.ConvertToEntity());
        }

        public void RemoveKunde(KundeDto kunde)
        {
            KundeManager.Remove(kunde.ConvertToEntity());
        }

        public void RemoveReservation(ReservationDto reservation)
        {
            ReservationsManager.Remove(reservation.ConvertToEntity());
        }
        #endregion

        #region Update
        public void UpdateAuto(AutoDto auto)
        {
            try
            {
                AutoManager.Update(auto.ConvertToEntity());
            }
            catch (DbUpdateConcurrencyException)
            {
                var fault = new GenericFault("Update Concurrency Exception");
                throw new FaultException<GenericFault>(fault);
            }
        }

        public void UpdateKunde(KundeDto kunde)
        {
            try
            {
                KundeManager.Update(kunde.ConvertToEntity());
            }
            catch (DbUpdateConcurrencyException)
            {
                var fault = new GenericFault("Update Concurrency Exception");
                throw new FaultException<GenericFault>(fault);
            }
        }

        public void UpdateReservation(ReservationDto reservation)
        {
            if (reservation.Auto == null || reservation.Kunde == null)
            {
                var fault = new GenericFault("Reservation muss ein Auto und ein Kunde besitzen um angepasst zu werden.");
                throw new FaultException<GenericFault>(fault);
            }
            if (IsCarAvailable(reservation.Auto, reservation))
            {
                try
                {
                    ReservationsManager.Update(reservation.ConvertToEntity());
                }
                catch (DbUpdateConcurrencyException)
                {
                    var fault = new GenericFault("Update Concurrency Exception");
                    throw new FaultException<GenericFault>(fault);
                }
            }
            else
            {
                var fault = new GenericFault("Das Auto ist in dieser Zeitspanne nicht verfügbar.");
                throw new FaultException<GenericFault>(fault);
            }
        }
        #endregion

        #region ListWhere
        public List<AutoDto> AutoListeWhereReservation(ReservationDto reservation)
        {
            return AutoManager.ListWhere(reservation.ConvertToEntity()).ConvertToDtos();
        }

        public List<KundeDto> KundenListeWhereReservation(ReservationDto reservation)
        {
            return KundeManager.ListWhere(reservation.ConvertToEntity()).ConvertToDtos();
        }

        public List<ReservationDto> ReservationenListeWhereKunde(KundeDto kunde)
        {
            return ReservationsManager.ListWhere(kunde.ConvertToEntity()).ConvertToDtos();
        }

        public List<ReservationDto> ReservationenListeWhereAuto(AutoDto auto)
        {
            return ReservationsManager.ListWhere(auto.ConvertToEntity()).ConvertToDtos();
        }

        public AutoDto GetAutoById(int id)
        {
            try
            {
                return AutoManager.GetById(id).ConvertToDto();
            }
            catch (InvalidOperationException)
            {
                var fault = new GenericFault("Keine Gültige ID");
                throw new FaultException<GenericFault>(fault);
            }
        }

        public KundeDto GetKundeById(int id)
        {
            try
            {
                return KundeManager.GetById(id).ConvertToDto();
            }
            catch (InvalidOperationException)
            {
                var fault = new GenericFault("Keine Gültige ID");
                throw new FaultException<GenericFault>(fault);
            }
        }

        public ReservationDto GetReservationById(int id)
        {
            try
            {
                return ReservationsManager.GetById(id).ConvertToDto();
            }
            catch (InvalidOperationException)
            {
                var fault = new GenericFault("Keine Gültige ID");
                throw new FaultException<GenericFault>(fault);
            }
        }

        #endregion

        public bool IsCarAvailable(AutoDto auto, ReservationDto reservation)
        {
            var list = ReservationsManager.ListWhere(auto.ConvertToEntity());
            foreach (var item in list)
            {
                if (reservation.ReservationsNr != item.ReservationsNr && ReservationsManager.AreOverlapping(item,
                    reservation.ConvertToEntity()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}