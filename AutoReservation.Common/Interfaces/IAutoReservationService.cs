using System.Collections.Generic;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        List<AutoDto> AutoListe();
        List<KundeDto> KundenListe();
        List<ReservationDto> ReservationenListe();

        List<AutoDto> AutoListeWhereReservation(ReservationDto reservation);
        List<KundeDto> KundenListeWhereReservation(ReservationDto reservation);
        List<ReservationDto> ReservationenListeWhereKunde(KundeDto kunde);
        List<ReservationDto> ReservationenListeWhereAuto(AutoDto auto);

        AutoDto GetAutoById(int id);
        KundeDto GetKundeById(int id);
        ReservationDto GetReservationById(int id);

        void UpdateAuto(AutoDto auto);
        void UpdateKunde(KundeDto kunde);
        void UpdateReservation(ReservationDto reservation);

        void RemoveAuto(AutoDto auto);
        void RemoveKunde(KundeDto kunde);
        void RemoveReservation(ReservationDto reservation);

        void AddAuto(AutoDto auto);
        void AddKunde(KundeDto kunde);
        void AddReservation(ReservationDto reservation);
    }
}
