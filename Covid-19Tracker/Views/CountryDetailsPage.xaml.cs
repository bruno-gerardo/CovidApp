using System;
using System.Collections.Generic;
using System.Windows.Input;
using Covid19Tracker.Model;
using Covid19Tracker.ViewModels;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class CountryDetailsPage : ContentPage
    {
        public CountryDetailsPage()
        {
            InitializeComponent();
            BindingContext = new CountryDetailsPageViewModel();

        }

        

    }
}
