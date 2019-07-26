using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FarrierClientManager.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        public string DayNumber => Date.Day.ToString();
        public bool IsSelected { get; set; }
        public bool IsToday { get; set; }
        public SfCalendar Calendar { get; set; }
        public DateTime Date { get; set; }
        public Color SelectedTextColor { get; set; } = Color.Black;
        public Color SelectionColor { get; set; } = Color.Lavender;
    }
}
