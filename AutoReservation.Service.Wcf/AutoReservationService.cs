using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;

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
            AutoManager.Update(auto.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto kunde)
        {
            KundeManager.Update(kunde.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto reservation)
        {
            if (reservation.Auto == null || reservation.Kunde == null)
            {
                throw new ArgumentException("Reservation muss ein Auto und ein Kunde besitzen um angepasst zu werden.");
            }
            if (IsCarAvailable(reservation.Auto, reservation))
            {
                ReservationsManager.Update(reservation.ConvertToEntity());
            }
            else
            {
                throw new ArgumentException("Das Auto ist in dieser Zeitspanne nicht verfügbar.");
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
            return AutoManager.GetById(id).ConvertToDto();
        }

        public KundeDto GetKundeById(int id)
        {
            return KundeManager.GetById(id).ConvertToDto();
        }

        public ReservationDto GetReservationById(int id)
        {
            return ReservationsManager.GetById(id).ConvertToDto();
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