using System;
using Xamarin.Forms;

namespace SlotLineTest
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty ArrowProperty =
            BindableProperty.Create(nameof(Arrow), typeof(string), typeof(CustomPicker), "arrow.png");

        public string Arrow
        {
            get { return (string)GetValue(ArrowProperty); }
            set { SetValue(ArrowProperty, value); }
        }
    }
}
