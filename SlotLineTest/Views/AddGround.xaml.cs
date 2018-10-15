using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SlotLineTest.Views
{
    public partial class AddGround : ContentPage
    {
        public List<string> GroundImages = new List<string>();
        public AddGround()
        {
            InitializeComponent();
            GroundImages.Add("pic1");
              GroundImages.Add("pic2");
                   GroundImages.Add("pic3");
            groundImages.ItemsSource = GroundImages;
        }

        void GroundName_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(groundName.Text))
                groundvalidation.IsVisible = true;
            else groundvalidation.IsVisible = false;
        }

        void Location_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(location.Text))
                locationvalidation.IsVisible = true;
            else locationvalidation.IsVisible = false;
        }

        void BusinessName_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(businessname.Text))
                businessvalidation.IsVisible = true;
            else businessvalidation.IsVisible = false;
        }

        void Building_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(building.Text))
                buildingvalidation.IsVisible = true;
            else buildingvalidation.IsVisible = false;
        }

        void StreetAddress_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(street.Text))
                streetvalidation.IsVisible = true;
            else streetvalidation.IsVisible = false;
        }

        void City_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(city.Text))
                cityvalidation.IsVisible = true;
            else cityvalidation.IsVisible = false;
        }

        void State_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(state.Text))
                statevalidation.IsVisible = true;
            else statevalidation.IsVisible = false;
        }

         void Pin_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pin.Text))
                pinvalidation.IsVisible = true;
            else pinvalidation.IsVisible = false;
        }

        void Phone_OnTextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(phone.Text))
                phonevalidation.IsVisible = true;
            else phonevalidation.IsVisible = false;
        }
    }
}
