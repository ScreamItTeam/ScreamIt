using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Core;
using ScreamIt.Client.Data.Contracts;
using ScreamIt.Client.Data.Model.Annotations;

namespace ScreamIt.Client.Data.Model
{
    public class LocationService : ILocationService, INotifyPropertyChanged
    {
        private GeolocationAccessStatus _accessStatus;
        private Geolocator _geolocator = new Geolocator { DesiredAccuracyInMeters = 5, MovementThreshold = 100 };
        private double _latitude;
        private double _longitude;

        public async Task InitializeLocationServiceAsync()
        {
            _accessStatus = await Geolocator.RequestAccessAsync();

            await Task.Factory.StartNew(() =>
            {
                switch (_accessStatus)
                {
                    case GeolocationAccessStatus.Allowed:

                        _geolocator.StatusChanged += OnStatusChanged;
                        _geolocator.PositionChanged += OnGeolocatorPositionChanged;
                        break;

                    case GeolocationAccessStatus.Denied:
                        // TODO: Do something meaningfull here
                        break;

                    case GeolocationAccessStatus.Unspecified:
                        // TODO: Do something meaningfull here
                        break;
                }

            });
        }

        private void OnGeolocatorPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Latitude = args.Position.Coordinate.Latitude;
            Longitude = args.Position.Coordinate.Longitude;
        }

        private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

        public double Latitude
        {
            get { return _latitude; }
            private set
            {
                if (_latitude.Equals(value))
                    return;

                _latitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            private set
            {
                if (_longitude.Equals(value))
                    return;

                _longitude = value;

                OnPropertyChanged();
            }
        }

    }
}