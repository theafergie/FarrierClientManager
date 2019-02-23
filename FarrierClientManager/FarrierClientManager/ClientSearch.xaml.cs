﻿using FarrierClientManager.Persistence;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientSearch : ContentPage
	{
        private ObservableCollection<Client> _clients;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        public ClientSearch()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            await _connection.CreateTableAsync<Client>();

            var clients = await _connection.Table<Client>().ToListAsync();
            _clients = new ObservableCollection<Client>(clients);
            clientDetail.ItemsSource = _clients;
        }

        async void OnClientSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (clientDetail.SelectedItem == null)
                return;

            var selectedClient = e.SelectedItem as Client;
            clientDetail.SelectedItem = null;

            var page = new ClientDetail(selectedClient);
            page.ClientUpdated += (source, client) =>
            {
                selectedClient.Id = client.Id;
                selectedClient.FirstName = client.FirstName;
                selectedClient.LastName = client.LastName;
                selectedClient.Address = client.Address;
                selectedClient.City = client.City;
                selectedClient.County = client.County;
                selectedClient.Zip = client.Zip;
                selectedClient.PhoneNumber = client.PhoneNumber;
            };
            await Navigation.PushAsync(page);
        }

        async void OnPlusSignClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClient());
        }
    }
}