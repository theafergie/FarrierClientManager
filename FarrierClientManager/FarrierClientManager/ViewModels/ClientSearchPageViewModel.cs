using FarrierClientManager.Persistence;
using SQLite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarrierClientManager.ViewModels
{
    public class ClientSearchPageViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;
        private ClientViewModel _selectedClient;
        private ObservableCollection<ClientViewModel> _clients;
        private SQLiteAsyncConnection _connection;
        public ICommand GetAddClientPageCommand { get; private set; } 
        public ICommand SelectClientCommand { get; private set; }
        public ClientViewModel SelectedClient
        {
            get => _selectedClient;
            set
            {
                SetValue(ref _selectedClient, value);
                SelectClientCommand.Execute(SelectedClient);
            }
        }

        public ObservableCollection<ClientViewModel> ClientList
        {
            get => _clients;
            set{ SetValue(ref _clients, value); }
        }

        public ClientSearchPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _ = LoadData();
            GetAddClientPageCommand = new Command(GetAddClient);
            SelectClientCommand = new Command<ClientViewModel>(SelectClient);
        }

        private async void GetAddClient(object obj)
        {
            await _pageService.PushAsync(new AddClient(new ClientViewModel()));
        }

        public async Task LoadData()
        {
            await _connection.CreateTableAsync<ClientViewModel>();
            var clients = await _connection.Table<ClientViewModel>().ToListAsync();
            _clients = new ObservableCollection<ClientViewModel>(clients);
            OnPropertyChanged("ClientList");
        }

        public void SelectClient(ClientViewModel client)
        {
            if(client == null)
            {
                return;
            }
            else
            {
                _pageService.PushAsync(new ClientDetail(client));
            }
            SelectedClient = null;
        }
    }
}
