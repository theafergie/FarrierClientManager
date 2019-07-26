using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarrierClientManager.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;
         
        public ICommand GetClientSearchCommand { get; private set; }
        public ICommand GetEquineSearchCommand { get; private set; }
        public ICommand GetNewInvoiceCommand { get; private set; }
        public ICommand GetPricingCommand { get; private set; }
        public ICommand GetInventoryPageCommand { get; private set; }
        public ICommand GetSchedulerPageCommand { get; private set; }

        public WelcomePageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            GetClientSearchCommand = new Command(GetClientSearch);
            GetEquineSearchCommand = new Command(GetEquineSearch);
            GetNewInvoiceCommand = new Command(GetNewInvoice);
            GetPricingCommand = new Command(GetPricing);
            GetInventoryPageCommand = new Command(GetInventory);
            GetSchedulerPageCommand = new Command(GetScheduler);
        }

        private async void GetScheduler(object obj)
        {
            await _pageService.PushAsync(new SchedulerPage());
        }

        private async void GetInventory(object obj)
        {
            await _pageService.PushAsync(new Inventory());
        }

        private async void GetPricing(object obj)
        {
            await _pageService.PushAsync(new Pricing());
        }

        private async void GetNewInvoice(object obj)
        {
            await _pageService.PushAsync(new NewInvoice());
        }

        private async void GetEquineSearch()
        {
            await _pageService.PushAsync(new EquineSearchPage());
        }

        private async void GetClientSearch()
        {
            await _pageService.PushAsync(new ClientSearch());
        }
    }
}
