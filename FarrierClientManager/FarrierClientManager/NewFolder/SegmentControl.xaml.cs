using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarrierClientManager.NewFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SegmentControl : ContentView
	{
		public SegmentControl()
		{
			InitializeComponent();

            ButtonOne_Clicked(this, null);
		}

        public string ButtonOneText
        {
            get => (string)GetValue(ButtonOneTextProperty);
            set { SetValue(ButtonOneTextProperty, value); }
        }

        public static readonly BindableProperty ButtonOneTextProperty = BindableProperty.Create(
            propertyName: "ButtonOneText", returnType: typeof(string), declaringType: typeof(SegmentControl), defaultValue: "", defaultBindingMode: BindingMode.TwoWay);

        public string ButtonTwoText
        {
            get => (string)GetValue(ButtonTwoTextProperty);
            set { SetValue(ButtonTwoTextProperty, value); }
        }

        public static readonly BindableProperty ButtonTwoTextProperty = BindableProperty.Create(
            propertyName: "ButtonTwoText", returnType: typeof(string), declaringType: typeof(SegmentControl), defaultValue: "", defaultBindingMode: BindingMode.TwoWay);

        public int SelectedSegment
        {
            get => (int)GetValue(SelectedSegmentProperty);
            set { SetValue(SelectedSegmentProperty, value); }
        }

        public static readonly BindableProperty SelectedSegmentProperty = BindableProperty.Create(
            propertyName: "SelectedSegment", returnType: typeof(int), declaringType: typeof(SegmentControl), defaultValue: 0, defaultBindingMode: BindingMode.TwoWay);

        public static void SelectedSegmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SegmentControl)bindable;
            control.SelectedSegment = (int)newValue;

            if(control.SelectedSegment == 0)
            {
                control.ButtonOne_Clicked(control, null);
            }
            else
            {
                control.ButtonTwo_Clicked(control, null);
            }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(Button), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        private void ButtonOne_Clicked(object sender, EventArgs e)
        {
            buttonOne.BackgroundColor = Color.SlateGray;
            buttonOne.TextColor = Color.White;
            buttonTwo.BackgroundColor = Color.White;
            buttonTwo.TextColor = Color.Black;
            SelectedSegment = 0;
        }

        private void ButtonTwo_Clicked(object sender, EventArgs e)
        {
            buttonOne.BackgroundColor = Color.White;
            buttonOne.TextColor = Color.Black;
            buttonTwo.BackgroundColor = Color.SlateGray;
            buttonTwo.TextColor = Color.White;
            SelectedSegment = 1;
        }
    }
}