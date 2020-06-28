using System;
using System.Collections.Generic;
using Covid19Tracker.Services;
using Covid19Tracker.ViewModels;
using Esri.ArcGISRuntime.Mapping;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class PortugalPage : ContentPage
    {
        PortugalPageViewModel vm;
        public PortugalPage()
        {
            InitializeComponent();
           
            vm = new PortugalPageViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.GetData();
        }
    }
}
