using System;
using System.ComponentModel.DataAnnotations;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        public Auto Auto { get; set; }
        public Kunde Kunde { get; set; }

        public int ReservationsNr { get; set; }

        private DateTime _von;
        public DateTime Von
        {
            get { return _von; }
            set
            {
                if (_bis == new DateTime() || _bis >= value)
                {
                    _von = value;
                }
                else
                {
                    throw new ArgumentException("Bis muss grösser sein als Von.");
                }
            }
        }

        private DateTime _bis;

        public DateTime Bis
        {
            get { return _bis; }
            set
            {
                if (_von == new DateTime() || _von <= value)
                {
                    _bis = value;
                }
                else
                {
                    throw new ArgumentException("Von muss kleiner sein als Bis.");
                }
            }
        }

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
