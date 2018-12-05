using System;
using System.Collections.Generic;
using System.Linq;
using AutoReservation.TestEnvironment;
using Xunit;

namespace AutoReservation.BusinessLayer.Testing
{
    public class ReservationUpdateTest
        : TestBase
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());

        [Fact]
        public void UpdateReservationTest()
        {
            var res = Target.List.First();
            res.Von = DateTime.Now;
            res.Bis = DateTime.Now.AddDays(1);

            Target.Update(res);
            var newRes = Target.GetById(res.ReservationsNr);

            Assert.Equal(res.Von, newRes.Von);
        }
    }
}
