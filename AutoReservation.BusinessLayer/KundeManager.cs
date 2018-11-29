﻿using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public Kunde GetById(int id)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                return List.Where(k => k.Id == id).First();

            }
        }

        public void Add(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Add(kunde);
                context.SaveChanges();
            }
        }

        public void Remove(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Remove(kunde);
                context.SaveChanges();
            }
        }

        public void Update(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Update(kunde);
                context.SaveChanges();
            }
        }

    }
}