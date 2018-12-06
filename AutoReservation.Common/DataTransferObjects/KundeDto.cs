using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private string _nachname { get; set; }
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                if (SetProperty(ref _nachname, value))
                {
                    OnPropertyChanged(nameof(ToString));
                }
            }
        }

        private string _vorname { get; set; }
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                SetProperty(ref _vorname, value);
                OnPropertyChanged(nameof(ToString));
            }
        }

        public DateTime Geburtsdatum { get; set; }
        
        public byte[] RowVersion { get; set; }

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
            => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}; {RowVersion}";
    }
}
