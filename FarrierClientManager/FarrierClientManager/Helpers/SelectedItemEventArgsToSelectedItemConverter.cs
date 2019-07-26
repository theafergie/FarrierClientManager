using FarrierClientManager.ViewModels;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace FarrierClientManager.Helpers
{
    public class SelectedItemEventArgsToSelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var buttonClicked = value as ClickedEventArgs;
            if(buttonClicked == null)
            {
                return Color.Pink;
            }
            if (buttonClicked.Equals(true))
            {
                return Color.Black;
            }
            return Color.Red;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
