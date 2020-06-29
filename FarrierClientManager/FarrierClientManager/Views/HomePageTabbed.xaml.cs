using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageTabbed : TabbedPage
    {
        public HomePageTabbed ()
        {
            InitializeComponent();
        }
    }
}