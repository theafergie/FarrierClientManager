using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FarrierClientManager
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTIzODczQDMxMzcyZTMyMmUzMG1nbFRWQXpKd1NRL2xKV1lzMFJUMlc1VTBpa1c0N2Mxby9TazBSMkNsZWs9");
            InitializeComponent();

            MainPage = new NavigationPage (new WelcomePage());
            
        }

        protected override void OnStart()
        {
            DependencyService.Get<Persistence.ISQLiteDb>().GetConnection();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
