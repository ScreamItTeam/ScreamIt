using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Contacts;
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
        private readonly ILocalDataService _localDataService = new LocalDataService();
        private ObservableCollection<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();
        }


        public ILocationService LocationService { get; } = new LocationService();

        public ObservableCollection<Contact> Contacts => _contacts ?? (_contacts = new ObservableCollection<Contact>());

        private async void MainPage_OnLoading(FrameworkElement sender, object args)
        {
            await LocationService.InitializeLocationServiceAsync();
            DataContext = this;
        }

        private async void PickContacts()
        {
            var contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

            var contacts = await contactPicker.PickContactsAsync();
            
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void OnPickContact(object sender, RoutedEventArgs e)
        {
            PickContacts();
        }
    }
}
