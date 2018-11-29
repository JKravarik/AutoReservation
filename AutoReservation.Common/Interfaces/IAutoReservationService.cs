using AutoReservation.Dal.Entities;
using System.Collections.Generic;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        List<Auto> AutoListe();
        List<Kunde> KundenListe();
        List<Reservation> ReservationenListe();

        List<Auto> AutoListeWhereReservation(Reservation reservation);
        List<Kunde> KundenListeWhereReservation(Reservation reservation);
        List<Reservation> ReservationenListeWhereKunde(Kunde kunde);
        List<Reservation> ReservationenListeWhereAuto(Auto auto);

        void UpdateAuto(Auto auto);
        void UpdateKunde(Kunde kunde);
        void UpdateReservation(Reservation reservation);

        void RemoveAuto(Auto auto);
        void RemoveKunde(Kunde kunde);
        void RemoveReservation(Reservation reservation);

        void AddAuto(Auto auto);
        void AddKunde(Kunde kunde);
        void AddReservation(Reservation reservation);
    }
}
