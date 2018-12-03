using System;
using System.Collections.Generic;
using System.Linq;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.EntityFrameworkCore;
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
            Assert.Throws<InvalidOperationException>(() => Target.GetAutoById(-1));
        }

        [Fact]
        public void GetKundeByIdWithIllegalIdTest()
        {
            Assert.Throws<InvalidOperationException>(() => Target.GetKundeById(-1));
        }

        [Fact]
        public void GetReservationByNrWithIllegalIdTest()
        {
            Assert.Throws<InvalidOperationException>(() => Target.GetReservationById(-1));
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
            var target = new AutoReservationService();
            var auto1 = Target.AutoListe().First();
            var auto2 = target.AutoListe().First();
            auto1.Marke = "fdsa123";
            auto2.Marke = "v dja156";
            Target.UpdateAuto(auto1);
            Assert.Throws<DbUpdateConcurrencyException>(() => { target.UpdateAuto(auto2); }); 
        }

        [Fact]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            var target = new AutoReservationService();
            var kunde1 = Target.KundenListe().First();
            var kunde2 = target.KundenListe().First();
            kunde1.Nachname = "fdsa123";
            kunde2.Nachname = "v dja156";
            Target.UpdateKunde(kunde1);
            Assert.Throws<DbUpdateConcurrencyException>(() => { target.UpdateKunde(kunde2); });
        }

        [Fact]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            var target = new AutoReservationService();
            var res1 = Target.ReservationenListe().First();
            var res2 = target.ReservationenListe().First();
            res1.Von = DateTime.MinValue;
            res2.Von = DateTime.MinValue.AddDays(1);
            Target.UpdateReservation(res1);
            Assert.Throws<DbUpdateConcurrencyException>(() => { target.UpdateReservation(res2); });
        }

        #endregion

        #region Insert / update invalid time range

        [Fact]
        public void InsertReservationWithInvalidDateRangeTest()
        {
            var res = new ReservationDto
            {
                Bis = DateTime.Now,
                Von = DateTime.Now.AddDays(1),
                Auto = new AutoDto(),
                Kunde = new KundeDto()
            };
            Assert.Throws<ArgumentException>(() => { Target.AddReservation(res); });
        }

        [Fact]
        public void InsertReservationWithAutoNotAvailableTest()
        {
            var auto = Target.AutoListe().First();
            var reservation = Target.ReservationenListeWhereAuto(auto).First();
            var newReservation = new ReservationDto
            {
                Auto = auto,
                Von = reservation.Von,
                Bis = reservation.Bis,
                Kunde = reservation.Kunde
            };
            Assert.Throws<ArgumentException>(() => { Target.AddReservation(newReservation); });
        }

        [Fact]
        public void UpdateReservationWithInvalidDateRangeTest()
        {
            var res = Target.ReservationenListe().First();
            res.Von = res.Bis.AddDays(1);
            Assert.Throws<ArgumentException>(() => { Target.UpdateReservation(res); });
        }

        [Fact]
        public void UpdateReservationWithAutoNotAvailableTest()
        {
            var updateRes = Target.ReservationenListe().First();
            var kunde = Target.KundenListeWhereReservation(updateRes).First();
            var auto = Target.AutoListeWhereReservation(updateRes).First();

            var res = new ReservationDto
            {
                Auto = auto,
                Von = new DateTime(1980,12,13),
                Bis = new DateTime(1980, 12, 14),
                Kunde = kunde
            };
            Target.AddReservation(res);

            updateRes.Von = new DateTime(1980, 12, 13);
            updateRes.Bis = new DateTime(1980, 12, 14);

            Assert.Throws<ArgumentException>(() => { Target.UpdateReservation(updateRes); });
        }
        #endregion

        #region Check Availability
        [Fact]
        public void CheckAvailabilityIsTrueTest()
        {
            var auto = Target.AutoListe().First();
            var reservation = new ReservationDto
            {
                Bis = new DateTime(1990, 12, 8),
                Von = new DateTime(1990, 12, 6),
                Auto = new AutoDto { Id = auto.Id },
                Kunde = new KundeDto { Id = 2 }
            };

            Assert.True(Target.IsCarAvailable(auto, reservation));
        }

        [Fact]
        public void CheckAvailabilityIsFalseTest()
        {
            var auto = Target.AutoListe().First();
            var reservation = Target.ReservationenListeWhereAuto(auto).First();
            var newReservation = new ReservationDto
            {
                Auto = auto,
                Von = reservation.Von,
                Bis = reservation.Bis,
                Kunde = reservation.Kunde
            };

            Assert.False(Target.IsCarAvailable(auto, newReservation));
        }

        #endregion
    }
}
