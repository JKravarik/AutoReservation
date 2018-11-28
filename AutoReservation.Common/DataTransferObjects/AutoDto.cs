using System;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public int Basistarif { get; set; }
        public DateTime RowVersion { get; set; }
        public AutoKlasse AutoKlasse { get; set; }

        public override string ToString()
        {
            return $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}; {RowVersion}";
        }
    }
}
