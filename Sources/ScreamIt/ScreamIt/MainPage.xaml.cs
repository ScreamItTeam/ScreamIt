using System;
using System.Globalization;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScreamIt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator ();
            var gps = await geolocator.GetGeopositionAsync();
            
            Latitude.Text = gps.Coordinate.Latitude.ToString(CultureInfo.CurrentCulture);
            Longitude.Text = gps.Coordinate.Longitude.ToString(CultureInfo.CurrentCulture);

            // Subscribe to the StatusChanged event to get updates of location status changes.

        }
    }
}
