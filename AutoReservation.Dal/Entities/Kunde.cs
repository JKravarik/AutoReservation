using System;
using System.ComponentModel.DataAnnotations;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Kunde() { }

        public Kunde(int id, string vorname, string nachname, DateTime geburtstag, byte[] rowstamp)
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
