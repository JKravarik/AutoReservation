using System;
using System.ComponentModel;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        
        public byte[] RowVersion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
            => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}; {RowVersion}";
    }
}
