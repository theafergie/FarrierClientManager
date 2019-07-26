using FarrierClientManager.Persistence;
using FarrierClientManager.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EquineListPage : ContentPage
	{
        private ObservableCollection<EquineViewModel> _equines;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        ClientViewModel myClient;

        public EquineListPage(ClientViewModel client)
        {
            myClient = client;
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            //ViewModel = new EquineListPageViewModel();

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
            await _connection.CreateTableAsync<EquineViewModel>();
            var equine = await _connection.Table<EquineViewModel>().ToListAsync();
            _equines = new ObservableCollection<EquineViewModel>(equine);
            //equineList.ItemsSource = _equines;
            equineList.ItemsSource = _equines.Where(x => x.OwnerId == myClient.Id);
            OnPropertyChanged("Name");
        }

        private async void OnPlusSignClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEquinePage(myClient));
        }

        //public EquineListPageViewModel ViewModel
        //{
        //    get => BindingContext as EquineListPageViewModel;
        //    set { BindingContext = value; }
        //}
    }
}