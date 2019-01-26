using FarrierClientManager.Persistence;
using SQLite;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    //public class Client
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int ClientId { get; set; }

    //    [MaxLength(255)]
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClient : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Client> _clients;

        public event EventHandler<Client> ClientAdded;
        public event EventHandler<Client> ClientUpdated;

        public AddClient (Client client)
		{
			InitializeComponent ();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }


        //protected override async void OnAppearing()
        //{
        //    await _connection.CreateTableAsync<Client>();

        //    var clients = await _connection.Table<Client>().ToListAsync();
        //    _clients = new ObservableCollection<Client>(clients);
        //    _clientsListView.ItemsSource = _clients;


        //    base.OnAppearing();
        //}
        //async void OnAdd(object sender, System.EventArgs e)
        //{
        //    var client = new Client { FirstName = "Ashley", LastName = "Ferguson" };
        //    await _connection.InsertAsync(client);

        //    _clients.Add(client);
        //}
        async void OnAddClient(object sender, System.EventArgs e)
        {
            var page = new AddClient(new Client());

            page.ClientAdded += (source, client) =>
            {
                _clients.Add(client);
            };

            await Navigation.PushAsync(page);
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var client = BindingContext as Client;

            if (String.IsNullOrWhiteSpace(client.FullName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (client.Id == 0)
            {
                client.Id = 1;

                ClientAdded?.Invoke(this, client);
            }
            else
            {
                ClientUpdated?.Invoke(this, client);
            }

            await Navigation.PopAsync();
        }
    }
}