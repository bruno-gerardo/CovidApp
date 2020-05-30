using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchPageViewModel();
        }

    }
}
