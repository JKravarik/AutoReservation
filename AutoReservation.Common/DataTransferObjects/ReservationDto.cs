using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : INotifyPropertyChanged
    {
        public ReservationDto()
        {
            Von = DateTime.Now;
            Bis = DateTime.Now.AddHours(24);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int _reservationsNr;
        public int ReservationsNr
        {
            get { return _reservationsNr; }
            set
            {
                SetProperty(ref _reservationsNr, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private DateTime _von;
        public DateTime Von
        {
            get { return _von; }
            set
            {
                SetProperty(ref _von, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private DateTime _bis;
        public DateTime Bis
        {
            get { return _von; }
            set
            {
                SetProperty(ref _bis, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private AutoDto _auto;
        public AutoDto Auto
        {
            get { return _auto; }
            set
            {
                SetProperty(ref _auto, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private KundeDto _kunde;
        public KundeDto Kunde
        {
            get { return _kunde; }
            set
            {
                SetProperty(ref _kunde, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        [Timestamp]
        private byte[] _rowVersion;
        public byte[] RowVersion
        {
            get { return _rowVersion; }
            set
            {
                SetProperty(ref _rowVersion, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
            => $"{ReservationsNr}: {Kunde} - {Auto}";
    }
}
