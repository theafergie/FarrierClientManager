using FarrierClientManager.Persistence;
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
        public event EventHandler<Client> ClientAdded;
        public event EventHandler<Client> ClientUpdated;
        private ObservableCollection<Client> _client;

        private SQLiteAsyncConnection _connection;

        public ClientDetail(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Client
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

            clientDetail.ItemsSource = _client;
        }
    }
}
