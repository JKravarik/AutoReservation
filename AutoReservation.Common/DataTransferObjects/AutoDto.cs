using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto : INotifyPropertyChanged
    {
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

        private string _marke;
        public string Marke
        {
            get { return _marke; }
            set
            {
                SetProperty(ref _marke, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private int _tagestarif;
        public int Tagestarif
        {
            get { return _tagestarif; }
            set
            {
                SetProperty(ref _tagestarif, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        private int _basistarif;
        public int Basistarif
        {
            get { return _tagestarif; }
            set
            {
                SetProperty(ref _tagestarif, value);
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

        private AutoKlasse _autoKlasse;
        public AutoKlasse AutoKlasse
        {
            get { return _autoKlasse; }
            set
            {
                SetProperty(ref _autoKlasse, value);
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
        {
            return $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}; {RowVersion}";
        }
    }
}
