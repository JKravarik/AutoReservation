using System;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public int AutoId { get; set; }
        public int KundenId { get; set; }
        public DateTime Rowversion { get; set; }

        public Reservation(int reservationNr, DateTime von, DateTime bis, int autoId, int kundenId, DateTime rowversion)
            : this(reservationNr, von, bis, autoId, kundenId)
        {
            this.ReservationsNr = reservationNr;
        }

        public Reservation(int reservationNr, DateTime von, DateTime bis, int autoId, int kundenId)
        {
            this.ReservationsNr = reservationNr;
            this.Von = von;
            this.Bis = bis;
            this.AutoId = autoId;
            this.KundenId = kundenId;

        }
    }
}
