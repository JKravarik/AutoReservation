using System;
using System.Linq;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Xunit;

namespace AutoReservation.BusinessLayer.Testing
{
    public class AutoUpdateTests
        : TestBase
    {
        private AutoManager target;
        private AutoManager Target => target ?? (target = new AutoManager());

        [Fact]
        public void UpdateAutoTest()
        {
            Auto auto = Target.List.First();
            auto.Marke = "BMW";
            Target.Update(auto);

            var newAuto = Target.GetById(auto.Id);

            Assert.Equal(auto.Marke, newAuto.Marke);
        }
    }
}
