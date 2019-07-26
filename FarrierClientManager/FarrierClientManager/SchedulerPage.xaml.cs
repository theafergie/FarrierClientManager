using FarrierClientManager.ViewModels;
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
	public partial class SchedulerPage : ContentPage
	{
		public SchedulerPage ()
		{
			InitializeComponent ();
            ViewModel = new SchedulerPageViewModel();
		}

        public SchedulerPageViewModel ViewModel
        {
            get => BindingContext as SchedulerPageViewModel;
            set { BindingContext = value; }
        }

    }
}