using System;
using System.Collections.Generic;
using System.Linq;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Xunit;

namespace AutoReservation.Service.Wcf.Testing
{
    public abstract class ServiceTestBase
        : TestBase
    {
        //private AutoReservationService target;
        protected abstract IAutoReservationService Target { get; }
        #region Read all entities

        [Fact]
        public void GetAutosTest()
        {
            var list = Target.AutoListe();
            Assert.True(list.Count != 0);
        }

        [Fact]
        public void GetKundenTest()
        {
            var list = Target.KundenListe();
            Assert.True(list.Count != 0);
        }

        [Fact]
        public void GetReservationenTest()
        {
            var list = Target.ReservationenListe();
            Assert.True(list.Count != 0);
        }

        #endregion

        #region Get by existing ID

        [Fact]
        public void GetAutoByIdTest()
        {
            var firstCar = Target.AutoListe().First();
            var CarById = Target.GetAutoById(firstCar.Id);
            Assert.Equal(firstCar.Id, CarById.Id);
        }

        [Fact]
        public void GetKundeByIdTest()
        {
            var firstCustomer = Target.KundenListe().First();
            var CustomerById = Target.GetKundeById(firstCustomer.Id);
            Assert.Equal(firstCustomer.Id, CustomerById.Id);
        }

        [Fact]
        public void GetReservationByNrTest()
        {
            var firstReservation = Target.ReservationenListe().First();
            var ReservationById = Target.GetReservationById(firstReservation.ReservationsNr);
            Assert.Equal(firstReservation.ReservationsNr, ReservationById.ReservationsNr);
        }

        #endregion

        #region Get by not existing ID

        [Fact]
        public void GetAutoByIdWithIllegalIdTest()
        {
            Assert.Throws<ArgumentException>(() => Target.GetAutoById(-1));
        }

        [Fact]
        public void GetKundeByIdWithIllegalIdTest()
        {
            Assert.Throws<ArgumentException>(() => Target.GetKundeById(-1));
        }

        [Fact]
        public void GetReservationByNrWithIllegalIdTest()
        {
            Assert.Throws<ArgumentException>(() => Target.GetReservationById(-1));
        }

        #endregion

        #region Insert

        [Fact]
        public void InsertAutoTest()
        {
            int listCountBefor = Target.AutoListe().Count;
            var auto = new AutoDto
            {
                AutoKlasse = AutoKlasse.Luxusklasse,
                Basistarif = 20,
                Marke = "BMW",
                Tagestarif = 50
            };
            Target.AddAuto(auto);

            int listCountAfter = Target.AutoListe().Count;

            Assert.Equal(listCountBefor + 1, listCountAfter);
        }

        [Fact]
        public void InsertKundeTest()
        {
            int listCountBefor = Target.KundenListe().Count;
            var kunde = new KundeDto
            {
                Geburtsdatum = DateTime.Now.Subtract(new TimeSpan(8760, 5, 20, 3)),
                Nachname = "fdsankj",
                Vorname = "vdbajkvbao"
            };
            Target.AddKunde(kunde);

            int listCountAfter = Target.KundenListe().Count;

            Assert.Equal(listCountBefor + 1, listCountAfter);
        }

        [Fact]
        public void InsertReservationTest()
        {
            int listCountBefor = Target.ReservationenListe().Count;
            var reservation = new ReservationDto
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.AddDays(5),
                Kunde = Target.KundenListe().First(),
                Auto = Target.AutoListe().First()
            };
            Target.AddReservation(reservation);

            int listCountAfter = Target.ReservationenListe().Count;

            Assert.Equal(listCountBefor + 1, listCountAfter);
        }

        #endregion

        #region Delete  

        [Fact]
        public void DeleteAutoTest()
        {
            int listCountBefor = Target.AutoListe().Count;
            Target.RemoveAuto(Target.AutoListe().First());

            int listCountAfter = Target.AutoListe().Count;

            Assert.Equal(listCountBefor - 1, listCountAfter);
        }

        [Fact]
        public void DeleteKundeTest()
        {
            int listCountBefor = Target.KundenListe().Count;
            Target.RemoveKunde(Target.KundenListe().First());

            int listCountAfter = Target.KundenListe().Count;

            Assert.Equal(listCountBefor - 1, listCountAfter);
        }

        [Fact]
        public void DeleteReservationTest()
        {
            int listCountBefor = Target.ReservationenListe().Count;
            Target.RemoveReservation(Target.ReservationenListe().First());

            int listCountAfter = Target.ReservationenListe().Count;

            Assert.Equal(listCountBefor - 1, listCountAfter);
        }

        #endregion

        #region Update

        [Fact]
        public void UpdateAutoTest()
        {
            var car = Target.AutoListe().First();
            car.Marke = car.Marke == "BMW" ? "Fiat Punot" : "BMW";
            Target.UpdateAuto(car);
            var updatedCar = Target.GetAutoById(car.Id);

            Assert.Equal(car.Marke, updatedCar.Marke);
        }

        [Fact]
        public void UpdateKundeTest()
        {
            var kunde = Target.KundenListe().First();
            kunde.Nachname = kunde.Nachname == "Muster" ? "Muster2" : "Muster";
            Target.UpdateKunde(kunde);
            var updatedKunde = Target.GetKundeById(kunde.Id);

            Assert.Equal(kunde.Nachname, updatedKunde.Nachname);
        }

        [Fact]
        public void UpdateReservationTest()
        {
            var reservation = Target.ReservationenListe().First();
            reservation.Bis = reservation.Bis == reservation.Von.AddDays(1)
                ? reservation.Von.AddDays(2) : reservation.Von.AddDays(1);
            Target.UpdateReservation(reservation);
            var updatedCar = Target.GetReservationById(reservation.ReservationsNr);

            Assert.Equal(reservation.Bis, updatedCar.Bis);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [Fact]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        #endregion

        #region Insert / update invalid time range

        [Fact]
        public void InsertReservationWithInvalidDateRangeTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void InsertReservationWithAutoNotAvailableTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void UpdateReservationWithInvalidDateRangeTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void UpdateReservationWithAutoNotAvailableTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        #endregion

        #region Check Availability

        [Fact]
        public void CheckAvailabilityIsTrueTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        [Fact]
        public void CheckAvailabilityIsFalseTest()
        {
            throw new NotImplementedException("Test not implemented.");
        }

        #endregion
    }
}
