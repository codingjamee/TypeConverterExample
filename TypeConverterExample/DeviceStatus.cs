using System.ComponentModel;
using System.Windows.Media;

namespace TypeConverterExample
{
    public class DeviceStatus : INotifyPropertyChanged
    {

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(StatusBrush));
            }
        }

        [TypeConverter(typeof(StatusToColorConverter))]
        public Brush StatusBrush
        {
            get
            {
                var converter = new StatusToColorConverter();
                return (Brush)converter.ConvertFrom(Status);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}