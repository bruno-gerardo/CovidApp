using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel vm;

        public HomePage()
        {
            InitializeComponent();

            vm = new HomePageViewModel();
            BindingContext = vm;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.GlobalCasesInfoAsync();
        }
    }
}
