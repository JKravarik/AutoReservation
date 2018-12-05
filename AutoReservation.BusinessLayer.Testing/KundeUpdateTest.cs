using System;
using System.Linq;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Xunit;

namespace AutoReservation.BusinessLayer.Testing
{
    public class KundeUpdateTest
        : TestBase
    {
        private KundeManager target;
        private KundeManager Target => target ?? (target = new KundeManager());

        [Fact]
        public void UpdateKundeTest()
        {
            Kunde kunde = Target.List.First();
            kunde.Nachname = "Ueli";
            Target.Update(kunde);

            var newKunde = Target.GetById(kunde.Id);

            Assert.Equal(kunde.Nachname, newKunde.Nachname);
        }
    }
}
