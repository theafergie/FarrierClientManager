using FarrierClientManager.Persistence;
using FarrierClientManager.ViewModels;
using SQLite;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FarrierClientManager
{
    public partial class AddClient : ContentPage
    {
        public event EventHandler<ClientViewModel> ClientAdded;
        public event EventHandler<ClientViewModel> ClientUpdated;

        private ClientViewModel _clientViewModel;
        private SQLiteAsyncConnection _connection;

        public AddClient(ClientViewModel client)
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
            _clientViewModel = client;
        }

        async void OnSave(object sender, EventArgs e)
        {
            ClientViewModel client = new ClientViewModel
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Address = Address.Text,
                City = City.Text,
                Zip = Zip.Text,
                County = County.Text,
                PhoneNumber = PhoneNumber.Text
            };

            BindingContext = new ClientViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                City = client.City,
                Zip = client.Zip,
                County = client.County,
                PhoneNumber = client.PhoneNumber
            };

            if(client.Id == 0)
            {
                await _connection.InsertAsync(client);

                ClientAdded?.Invoke(this, client);
            }
            else
            {
                await _connection.UpdateAsync(client);
                ClientUpdated?.Invoke(this, client);
            }
            await Navigation.PopAsync();
            //OnPropertyChanged("client");

        }
        //public event PropertyChangedEventHandler PropertyChanged;

    }
}