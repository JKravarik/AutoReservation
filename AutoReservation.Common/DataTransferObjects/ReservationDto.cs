using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : INotifyPropertyChanged
    {
        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public AutoDto Auto { get; set; }
        public KundeDto Kunde { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
            => $"{ReservationsNr}; {Von}; {Bis}; {Auto}; {Kunde}";
    }
}
