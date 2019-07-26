using FarrierClientManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientSearch : ContentPage
	{
        public ClientSearch()
        {
            InitializeComponent();
            ViewModel = new ClientSearchPageViewModel(new PageService());
        }

        public ClientSearchPageViewModel ViewModel
        {
            get => BindingContext as ClientSearchPageViewModel;
            set { BindingContext = value; }
        }
    }
}