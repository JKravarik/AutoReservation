using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto : INotifyPropertyChanged
    {
        public KundeDto()
        {
            Geburtsdatum = DateTime.Now.AddYears(-20);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private string _nachname;
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                SetProperty(ref _nachname, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                SetProperty(ref _vorname, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private DateTime _geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                SetProperty(ref _geburtsdatum, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

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
            => $"{Id}: {Nachname}, {Vorname}";
    }
}
