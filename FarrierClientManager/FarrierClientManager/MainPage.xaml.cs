using FarrierClientManager.Persistence;
using SQLite;
using System;
using Xamarin.Forms;

namespace FarrierClientManager
{
    public partial class MainPage : ContentPage
    {
        public SQLiteAsyncConnection _connection;
        public Client _client;

        public MainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<Client>();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }
    }
}