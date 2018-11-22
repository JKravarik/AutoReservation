using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer
{
    public class KundeManager
        : ManagerBase
    {
        public List<Kunde> List
        {
            get
            {
                using(AutoReservationContext context = new AutoReservationContext())
                {
                    return new List<Kunde>(context.Kunden);
                }
            }
        }

    }
}