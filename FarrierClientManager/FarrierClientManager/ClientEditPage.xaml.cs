using FarrierClientManager.Persistence;
using FarrierClientManager.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientEditPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        ClientViewModel client;

        public ClientEditPage (ClientViewModel selectedClient)
		{
			InitializeComponent();
            client = selectedClient;
            BindingContext = client;

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            client.FirstName = firstName.Text;
            client.LastName = lastName.Text;
            client.Address = address.Text;
            client.City = city.Text;
            client.Zip = zip.Text;
            client.PhoneNumber = phoneNumber.Text;

            await _connection.UpdateAsync(client);
            await Navigation.PopAsync();
        }
    }
}