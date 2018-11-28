using System;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public DateTime RowVersion { get; set; }

        public Kunde() { }

        public Kunde(int id, string vorname, string nachname, DateTime geburtstag, DateTime rowstamp)
            : this(id, vorname, nachname, geburtstag)
        {
            this.RowVersion = rowstamp;
        }

        public Kunde(int id, string vorname, string nachname, DateTime geburtstag)
        {
            this.Id = id;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtstag;
        }
    }
}
