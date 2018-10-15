using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SlotLineTest.Views
{
    public partial class CourtDetails : ContentPage
    {
        public CourtDetails()
        {
            InitializeComponent();
        }

        void CourtName_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(courtName.Text))
                courtvalidation.IsVisible = true;
            else courtvalidation.IsVisible = false;
        }

        void BasePrice_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(basePrice.Text))
                pricevalidation.IsVisible = true;
            else pricevalidation.IsVisible = false;
        }
    }
}
