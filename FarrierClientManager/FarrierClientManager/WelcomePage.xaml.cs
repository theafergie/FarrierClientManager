using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewInvoice());
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pricing());
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inventory());
        }

        async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientSearch());
        }
    }
}