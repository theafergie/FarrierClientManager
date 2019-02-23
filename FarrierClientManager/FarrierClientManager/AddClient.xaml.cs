using FarrierClientManager.Persistence;
using SQLite;
using System;
using Xamarin.Forms;

namespace FarrierClientManager
{
    public partial class AddClient : ContentPage
    {
        public event EventHandler<Client> ClientAdded;
        public event EventHandler<Client> ClientUpdated;

        private SQLiteAsyncConnection _connection;

        public AddClient()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async void OnSave(object sender, EventArgs e)
        {
            Client client = new Client
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Address = Address.Text,
                City = City.Text,
                Zip = Zip.Text,
                County = County.Text,
                PhoneNumber = PhoneNumber.Text
            };

            BindingContext = new Client
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
        }
    }
}