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
    public partial class AddEquinePage : ContentPage
    {
        public event EventHandler<EquineViewModel> EquineAdded;
        public event EventHandler<EquineViewModel> EquineUpdated;

        private SQLiteAsyncConnection _connection;

        ClientViewModel client;

        public AddEquinePage(ClientViewModel selectedClient)
        {
            InitializeComponent();
            client = selectedClient;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        async void OnSave(object sender, EventArgs e)
        {
            EquineViewModel equine = new EquineViewModel
            {
                Name = Name.Text,
                Breed = Breed.Text,
                Color = Color.Text,
                ShoeSize = ShoeSize.Text,
                ShoeType = ShoeType.Text,
                OwnerId = client.Id
            };

            BindingContext = new EquineViewModel
            {
                Id = equine.Id,
                Name = equine.Name,
                Breed = equine.Breed,
                Color = equine.Color,
                ShoeSize = equine.ShoeSize,
                ShoeType = equine.ShoeType,
                Owner = equine.Owner,
                OwnerId = client.Id
            };

            if (equine.Id == 0)
            {
                await _connection.InsertAsync(equine);

                EquineAdded?.Invoke(this, equine);
            }
            else
            {
                await _connection.UpdateAsync(equine);
                EquineUpdated?.Invoke(this, equine);
            }

            await Navigation.PopAsync();
        }
    }
    /
}