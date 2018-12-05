using System;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Xunit;

namespace AutoReservation.BusinessLayer.Testing
{
    public class ReservationAvailabilityTest
        : TestBase
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());

        public ReservationAvailabilityTest()
        {
            // Prepare reservation
            Reservation reservation = Target.GetById(1);
            reservation.Von = DateTime.Today;
            reservation.Bis = DateTime.Today.AddDays(1);
            Target.Update(reservation);
        }

        [Fact]
        public void ScenarioOkay01Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.False(Target.AreOverlapping(first, second));
        }

        [Fact]
        public void ScenarioOkay02Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.False(Target.AreOverlapping(second, first));
        }

        [Fact]
        public void ScenarioOkay03Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.False(Target.AreOverlapping(first, second));
        }

        [Fact]
        public void ScenarioOkay04Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.False(Target.AreOverlapping(second, first));
        }

        [Fact]
        public void ScenarioNotOkay01Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.True(Target.AreOverlapping(first, second));
        }

        [Fact]
        public void ScenarioNotOkay02Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now,
                Bis = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };
            Assert.True(Target.AreOverlapping(second, first));
        }

        [Fact]
        public void ScenarioNotOkay03Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(4, 0, 0, 0))
            };
            Assert.True(Target.AreOverlapping(first, second));
        }

        [Fact]
        public void ScenarioNotOkay04Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(3, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(4, 0, 0, 0))
            };
            Assert.True(Target.AreOverlapping(second, first));
        }

        [Fact]
        public void ScenarioNotOkay05Test()
        {
            Reservation first = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(5, 0, 0, 0))
            };

            Reservation second = new Reservation
            {
                Von = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0)),
                Bis = DateTime.Now.Add(new TimeSpan(4, 0, 0, 0))
            };
            Assert.True(Target.AreOverlapping(first, second));
        }
    }
}
