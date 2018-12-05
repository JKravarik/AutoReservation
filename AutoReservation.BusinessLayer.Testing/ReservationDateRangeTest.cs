using System;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Xunit;
using Xunit.Sdk;

namespace AutoReservation.BusinessLayer.Testing
{
    public class ReservationDateRangeTest
        : TestBase
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());

        [Fact]
        public void ScenarioOkay01Test()
        {
            Reservation r = new Reservation();
            try
            {
                r.Bis = DateTime.Now.AddDays(1);
                r.Von = DateTime.Now;
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ScenarioOkay02Test()
        {
            Reservation r = new Reservation();
            try
            {
                r.Von = DateTime.Now;
                r.Bis = DateTime.Now.AddDays(1);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ScenarioNotOkay01Test()
        {
            Reservation r = new Reservation();
            try
            {
                r.Von = DateTime.Now.AddDays(1);
                r.Bis = DateTime.Now;
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void ScenarioNotOkay02Test()
        {
            Reservation r = new Reservation();
            try
            {
                r.Bis = DateTime.Now;
                r.Von = DateTime.Now.AddDays(1);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
