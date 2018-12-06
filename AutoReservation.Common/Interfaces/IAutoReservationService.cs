using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        List<AutoDto> AutoListe();
        [OperationContract]
        List<KundeDto> KundenListe();
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        List<ReservationDto> ReservationenListe();

        [OperationContract]
        List<AutoDto> AutoListeWhereReservation(ReservationDto reservation);
        [OperationContract]
        List<KundeDto> KundenListeWhereReservation(ReservationDto reservation);
        [OperationContract]
        List<ReservationDto> ReservationenListeWhereKunde(KundeDto kunde);
        [OperationContract]
        List<ReservationDto> ReservationenListeWhereAuto(AutoDto auto);

        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        AutoDto GetAutoById(int id);
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        KundeDto GetKundeById(int id);
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        ReservationDto GetReservationById(int id);

        [OperationContract]
        void UpdateAuto(AutoDto auto);
        [OperationContract]
        void UpdateKunde(KundeDto kunde);
        [OperationContract]
        void UpdateReservation(ReservationDto reservation);

        [OperationContract]
        void RemoveAuto(AutoDto auto);
        [OperationContract]
        void RemoveKunde(KundeDto kunde);
        [OperationContract]
        void RemoveReservation(ReservationDto reservation);

        [OperationContract]
        void AddAuto(AutoDto auto);
        [OperationContract]
        void AddKunde(KundeDto kunde);
        [OperationContract]
        void AddReservation(ReservationDto reservation);

        [OperationContract]
        bool IsCarAvailable(AutoDto auto, ReservationDto reservation);
    }
}
