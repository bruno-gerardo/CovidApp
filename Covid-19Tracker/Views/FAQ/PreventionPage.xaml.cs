using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels.FAQ;
using Xamarin.Forms;

namespace Covid19Tracker.Views.FAQ
{
    public partial class PreventionPage : ContentPage
    {
        PreventionPageViewModel vm;

        public PreventionPage()
        {
            InitializeComponent();
            vm = new PreventionPageViewModel();
            BindingContext = vm;
        }
    }
}
