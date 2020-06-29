using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace FarrierClientManager.ViewModels
{
    public class SchedulerPageViewModel : Behavior<ContentPage>
    {
        private readonly IPageService _pageService;

        SfCalendar calendar;
        List<DateTime> dates = new List<DateTime>();
        bool enableSelection = false;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            calendar = bindable.FindByName<SfCalendar>("calendar");
            calendar.SelectedDate = null;
            calendar.OnMonthCellLoaded += Calendar_OnMonthCellLoaded;
            calendar.SelectionChanged += Calendar_SelectionChanged;
        }

        private void Calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            this.enableSelection = true;
        }

        private void Calendar_OnMonthCellLoaded(object sender, MonthCellLoadedEventArgs e)
        {
            var dataTemplate = GetDayModelFor(e.Date, calendar);
            e.CellBindingContext = dataTemplate;
        }

        public CalendarViewModel GetDayModelFor(DateTime date, SfCalendar calendar)
        {
            var selectedDate = DateTime.Now;
            var today = date;
            //calendar.SelectedDate = date;
            if (calendar.SelectedDate != null)
            {
                //calendar.SelectedDate = selectedDate;
                selectedDate = (DateTime)calendar.SelectedDate;
            }

            var selected = false;
            if (calendar.SelectedDate != null && date.Month == selectedDate.Month &&
                                       date.Year == selectedDate.Year && date.Day == selectedDate.Day)
            {
                selected = true;
                dates.Add(selectedDate);
            }
            else if (this.enableSelection)
            {
               
                foreach (var item in this.dates)
                {
                    if (item.Month == date.Month &&
                                     item.Year == date.Year && item.Day == date.Day)
                    {
                        selected = true;
                        break;
                    }
                }
            }
            calendar.SelectedDates = dates;
            var calendarView = new CalendarViewModel()
            {
                Calendar = calendar,
                Date = date.Date,
                IsToday = date.Day == today.Day &&
                              date.Month == today.Month &&
                              date.Year == today.Year,
                IsSelected = selected,
            };

            if (selected)
            {
                calendarView.SelectedTextColor = Color.SpringGreen;
                calendarView.SelectionColor = Color.Tomato;
                
            }
            else
            {
                calendarView.SelectedTextColor = Color.Black;
                calendarView.SelectionColor = Color.Transparent;
            }

            return calendarView;
        }
        //public string ButtonText { get; set; }
        //public string ButtonTextColor { get; set; }
        //public string ButtonBorderColor { get; set; }
        //public string SelectionColor { get; set; }
        //public DateTime Date { get; set; }
        //public List<DateTime> SelectedDates { get; set; }
        //public ICommand GetOnMonthCellLoadedCommand { get; private set; }
        //public ICommand GetTappedCommand { get; private set; }
        //public ICommand GetButtonTappedCommand { get; private set; }
        //public SchedulerPageViewModel(IPageService pageService)
        //{
        //    _pageService = pageService;
        //    GetOnMonthCellLoadedCommand = new Command<MonthCellLoadedEventArgs>(MonthCellLoaded);
        //    GetTappedCommand = new Command<CalendarTappedEventArgs>(CellTapped);
        //    GetButtonTappedCommand = new Command<SelectedItemChangedEventArgs>(GetButtonTapped);
        //}

        //private void GetButtonTapped(SelectedItemChangedEventArgs obj)
        //{
        //    ButtonTextColor = "Green";
        //    SelectionColor = "Green";
        //}

        //private void CellTapped(CalendarTappedEventArgs obj)
        //{
        //    Date = obj.DateTime.Date;
        //    if (SelectedDates == null || SelectedDates.Count == 0)
        //    {
        //        SelectedDates = new List<DateTime>();
        //    }
        //    SelectedDates.Add(Date);
        //    //ButtonTextColor = "Black";
        //    //OnPropertyChanged("ButtonTextColor");
        //}

        //private void MonthCellLoaded(MonthCellLoadedEventArgs cell)
        //{
        //    ButtonText = cell.Date.Day.ToString();
        //    SelectionColor = "Transparent";
        //    if (cell.IsCurrentMonth)
        //    {
        //        ButtonTextColor = "Pink";
        //        ButtonBorderColor = "Pink";
        //    }
        //    else
        //    {
        //        ButtonTextColor = "Gray";
        //        ButtonBorderColor = "Gray";
        //    }
        //}
    }
}
