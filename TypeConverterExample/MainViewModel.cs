using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TypeConverterExample
{
    public class MainViewModel
    {
        public ObservableCollection<DeviceStatus> Devices { get; set; }

        public MainViewModel()
        {
            Devices = new ObservableCollection<DeviceStatus>
            {
                new DeviceStatus {Status = "Online"},
                new DeviceStatus {Status = "Offline"},
                new DeviceStatus {Status = "Warning"}
            };
        }

    }
}
