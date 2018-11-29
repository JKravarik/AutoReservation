using System;
using System.ComponentModel.DataAnnotations;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        public Auto Auto { get; set; }
        public Kunde Kunde { get; set; }

        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public int AutoId { get; set; }
        public int KundeId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Reservation() { }

        public Reservation(int reservationNr, DateTime von, DateTime bis, int autoId, int kundenId, byte[] rowversion)
            : this(reservationNr, von, bis, autoId, kundenId)
        {
            this.RowVersion = rowversion;
        }

        public Reservation(int reservationNr, DateTime von, DateTime bis, int autoId, int kundenId)
        {
            this.ReservationsNr = reservationNr;
            this.Von = von;
            this.Bis = bis;
            this.AutoId = autoId;
            this.KundeId = kundenId;

        }
    }
}
