using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels.FAQ;
using Xamarin.Forms;

namespace Covid19Tracker.Views.FAQ
{
    public partial class FaqPage : ContentPage
    {
        FaqPageViewModel vm;
        public FaqPage()
        {
            InitializeComponent();

            vm = new FaqPageViewModel();
            BindingContext = vm;
        }
    }
}
