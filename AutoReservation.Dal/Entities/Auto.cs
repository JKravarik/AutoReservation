using System;
using System.ComponentModel.DataAnnotations;

namespace AutoReservation.Dal.Entities
{
    public abstract class Auto
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Auto() { }

        public Auto(int id, string marke, int tagestarif, byte[] rowVersion)
            : this(id, marke, tagestarif)
        {
            this.RowVersion = rowVersion;
        }
        public Auto(int id, string marke, int tagestarif)
        {
            this.Id = id;
            this.Marke = marke;
            this.Tagestarif = tagestarif;
        }

    }
}
