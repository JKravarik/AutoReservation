using System;

namespace AutoReservation.Dal.Entities
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public AutoKlasse AutoKlasse { get; set; }
        public int Basistarif { get; set; }

        public DateTime RowStamp { get; set; }

        public Auto(int id, string marke, int tagestarif, AutoKlasse autoKlasse, int basistarif, DateTime rowStamp)
            : this(id, marke, tagestarif, autoKlasse, basistarif)
        {
            this.RowStamp = rowStamp;
        }
        public Auto(int id, string marke, int tagestarif, AutoKlasse autoKlasse, int basistarif = 0)
        {
            if (autoKlasse == AutoKlasse.Luxusklasse && basistarif == 0)
            {
                throw new ArgumentException("Der Basistarif muss festgelegt werden wenn die Luxusklasse ausgewählt ist.");
            }
            this.Id = id;
            this.Marke = marke;
            this.Tagestarif = tagestarif;
            this.AutoKlasse = autoKlasse;
            this.Basistarif = basistarif;
        }

    }

    public enum AutoKlasse
    {
        Luxusklasse, Mittelklasse, Standard
    }
}
