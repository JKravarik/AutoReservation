using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AutoReservation.BusinessLayer
{
    public class AutoManager
        : ManagerBase
    {
        public List<Auto> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return new List<Auto>(context.Autos);
                }
            }
        }

        public void Add(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                if (auto.AutoKlasse == AutoKlasse.Luxusklasse && auto.Basistarif == 0)
                {
                    throw new ArgumentException("Der Basistarif muss festgelegt werden wenn die Luxusklasse ausgewählt ist.");
                }
                context.Add(auto);
                context.SaveChanges();
            }
        }

    }
}