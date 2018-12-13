using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;

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
        [FaultContract(typeof(GenericFault))]
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
        [FaultContract(typeof(GenericFault))]
        AutoDto GetAutoById(int id);
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        KundeDto GetKundeById(int id);
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ReservationDto GetReservationById(int id);

        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateAuto(AutoDto auto);
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        void UpdateKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
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
