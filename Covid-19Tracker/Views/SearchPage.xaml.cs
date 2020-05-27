using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            var tap = new TapGestureRecognizer();

            tap.Tapped += Tap_Tapped;

            cenas.GestureRecognizers.Add(tap);
        }



        private async void Tap_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("countryDetailsPage");
        }
    }
}
