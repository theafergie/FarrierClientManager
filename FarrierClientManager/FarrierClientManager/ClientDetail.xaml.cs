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

        public ClientDetail(Client client)
		{
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            InitializeComponent();

            BindingContext = new Client
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Email = client.Email,
            };

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
