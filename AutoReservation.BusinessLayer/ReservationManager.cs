using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer
{
    public class ReservationManager
        : ManagerBase
    {
        public List<Reservation> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext)
                {
                    return new List<Reservation>(context.Reservationen);
                }
            }
        }
    }
}