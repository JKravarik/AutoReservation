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

        public List<Auto> ListWhere(Reservation reservation)
        {
                var myList = List.Where(a => a.Id == reservation.AutoId);
                return new List<Auto>(myList);
        }

        public Auto GetById(int id)
        {
            return List.Where(a => a.Id == id).First();
        }

        public void Add(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Add(auto);
                context.SaveChanges();
            }
        }

        public void Remove(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Remove(auto);
                context.SaveChanges();
            }
        }

        public void Update(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Update(auto);
                context.SaveChanges();
            }
        }

    }
}