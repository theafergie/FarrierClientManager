using FarrierClientManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
		{
			InitializeComponent();
            ViewModel = new WelcomePageViewModel(new PageService());
		}

        public WelcomePageViewModel ViewModel
        {
            get => BindingContext as WelcomePageViewModel;
            set { BindingContext = value; }
        }
    }
}