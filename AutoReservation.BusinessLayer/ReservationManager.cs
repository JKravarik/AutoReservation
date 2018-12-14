using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AutoReservation.BusinessLayer
{
    public class ReservationManager
        : ManagerBase
    {
        public List<Reservation> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    //var res = context
                    //    .Reservationen
                    //    .Include(r => r.Auto)
                    //    .Include(r => r.Kunde)
                    //    .ToList();

                    //return res;

                    var kundenManager = new KundeManager();
                    var autoManager = new AutoManager();
                    var list = new List<Reservation>(context.Reservationen);
                    foreach (var item in list)
                    {
                        item.Auto = autoManager.GetById(item.AutoId);
                        item.Kunde = kundenManager.GetById(item.KundeId);
                    }
                    return list;
                }
            }
        }

        public List<Reservation> ListWhere(Auto auto)
        {
            var list = List.Where(r => r.AutoId == auto.Id);
            return new List<Reservation>(list);
        }

        public List<Reservation> ListWhere(Kunde kunde)
        {
            var list = List.Where(r => r.KundeId == kunde.Id);
            return new List<Reservation>(list);
        }

        public Reservation GetById(int Id)
        {
            return List.Where(r => r.ReservationsNr == Id).First();
        }

        public void Add(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Add(reservation);
                //context.Entry(reservation).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public bool AreOverlapping(Reservation res1, Reservation res2)
        {
            return !((res1.Von < res2.Von && res1.Bis <= res2.Von)
                                       || (res2.Von < res1.Von && res2.Bis <= res1.Von));
        }

        public void Remove(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Remove(reservation);
                context.SaveChanges();
            }
        }

        public void Update(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Update(reservation);
                context.SaveChanges();
            }
        }
    }
}