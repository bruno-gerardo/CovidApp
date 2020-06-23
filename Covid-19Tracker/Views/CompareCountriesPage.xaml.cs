using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class CompareCountriesPage : ContentPage
    {
        CompareCountriesPageViewModel vm;
        public CompareCountriesPage()
        {
            InitializeComponent();
            vm = new CompareCountriesPageViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.GetData();

        }
    }
}
