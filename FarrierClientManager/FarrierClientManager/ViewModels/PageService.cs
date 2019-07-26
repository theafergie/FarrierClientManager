using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FarrierClientManager.ViewModels
{
    public class PageService : IPageService
    {
        private SQLiteAsyncConnection _connection;

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task LoadData()
        {
            await _connection.CreateTableAsync<Client>();

        }
    }
}
