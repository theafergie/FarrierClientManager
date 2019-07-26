using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarrierClientManager.ViewModels
{
    public class ClientDetailViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;
        private ClientViewModel _selectedClient;
        public ICommand GetSelectedClientDetailCommand { get; private set; }
        public ICommand GetEquineListCommand { get; private set; }

        public ClientDetailViewModel(IPageService pageService, ClientViewModel selectedClient)
        {
            _pageService = pageService;
            _selectedClient = selectedClient;

            GetSelectedClientDetailCommand = new Command<ClientViewModel>(GetClientDetails);
            GetEquineListCommand = new Command<ClientViewModel>(GetEquineList);
        }

        private async void GetEquineList(ClientViewModel client)
        {
            await _pageService.PushAsync(new EquineListPage(client));
        }

        private void GetClientDetails(ClientViewModel client)
        {
            
        }
    }
}
