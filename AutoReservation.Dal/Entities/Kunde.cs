using System;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }
        public DateTime RowStamp { get; set; }

        public Kunde(int id, string vorname, string nachname, DateTime geburtstag, DateTime rowstamp)
            : this(id, vorname, nachname, geburtstag)
        {
            this.RowStamp = rowstamp;
        }

        public Kunde(int id, string vorname, string nachname, DateTime geburtstag)
        {
            this.Id = id;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtstag = geburtstag;
        }
    }
}
