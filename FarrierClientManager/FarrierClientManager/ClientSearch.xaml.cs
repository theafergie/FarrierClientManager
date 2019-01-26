using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientSearch : ContentPage
	{
        private ObservableCollection<Client> _clients;

        public ClientSearch()
        {
            InitializeComponent();

            _clients = new  ObservableCollection<Client>
            {
                new Client {Id = 1, FirstName="Ashley", LastName="Ferguson", Email="ashley@ferguson.com", Phone="501-730-2952"},
                new Client {Id = 1, FirstName="Cody", LastName="Ferguson", Email="cody@ferguson.com", Phone="501-730-1790"}
            };
            
            clients.ItemsSource = _clients;

            //GetSearchText();

        }

        public void GetSearchText(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
            {
                clients.ItemsSource = _clients;
            }
            clients.ItemsSource = _clients.Where(c => c.FullName.StartsWith(searchText));
        }

        async void OnClientSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (clients.SelectedItem == null)
                return;

            var selectedClient = e.SelectedItem as Client;

            clients.SelectedItem = null;

            var page = new ClientDetail(selectedClient);
            page.ClientUpdated += (source, client) =>
            {
                selectedClient.Id = client.Id;
                selectedClient.FirstName = client.FirstName;
                selectedClient.LastName = client.LastName;
                selectedClient.Phone = client.Phone;
                selectedClient.Email = client.Email;
            };

            await Navigation.PushAsync(page);
        }

            async void OnDeleteClient(object sender, System.EventArgs e)
        {
            var client = (sender as MenuItem).CommandParameter as Client;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {client.FullName}?", "Yes", "No"))
                _clients.Remove(client);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //search
        }

        //private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    GetSearchText(e.NewTextValue);
        //}
        async void OnPlusSignClicked(object sender, EventArgs e)
        {
            var addNew = new AddClient(new Client());
            await Navigation.PushAsync(addNew);
        }
    }
}