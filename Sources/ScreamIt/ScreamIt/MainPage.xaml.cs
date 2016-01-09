using Windows.UI.Xaml;
using ScreamIt.Client.Data.Contracts;
using ScreamIt.Client.Data.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScreamIt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private readonly ILocationService _locationService = new LocationService();

        public MainPage()
        {
            InitializeComponent();
        }


        public ILocationService LocationService => _locationService;

        private async void MainPage_OnLoading(FrameworkElement sender, object args)
        {
            await _locationService.InitializeLocationServiceAsync();
            DataContext = this;
        }
    }
}
