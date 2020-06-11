using System;
using System.Collections.Generic;
using Covid19Tracker.Services;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class PortugalPage : ContentPage
    {
        public PortugalPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Api.GetPortugalCasesInfoAsync();
        }
    }
}
