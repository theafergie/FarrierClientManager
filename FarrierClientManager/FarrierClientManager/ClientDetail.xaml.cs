using FarrierClientManager.Persistence;
using FarrierClientManager.ViewModels;
using SQLite;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetail : ContentPage
    {
        public event EventHandler<ClientViewModel> ClientAdded;
        public event EventHandler<ClientViewModel> ClientUpdated;
        private ObservableCollection<ClientViewModel> _client = new ObservableCollection<ClientViewModel>();

        ClientViewModel myClient;

        private SQLiteAsyncConnection _connection;

        public ClientDetail(ClientViewModel client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new ClientViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                City = client.City,
                Zip = client.Zip,
                County = client.County,
                PhoneNumber = client.PhoneNumber,
            };
            myClient = client;
            //clientDetail.ItemsSource = _client;
        }

        async void OnEdit(object sender, EventArgs e)
        {
            var client = myClient;
            await Navigation.PushAsync(new ClientEditPage(client));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var client = myClient;   

            await _connection.DeleteAsync(client);

            _client.Remove(client);

            //TODO deletes contact but not reflecting change in ui until navigating
            //away from page and then navigating back
            OnPropertyChanged();
            await Navigation.PopAsync();
        }

        private void NotesBox_Completed(object sender, EventArgs e)
        {

        }

        async void EquineButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EquineListPage(myClient));
        }
    }
}
