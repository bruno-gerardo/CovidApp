using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels.FAQ;
using Xamarin.Forms;

namespace Covid19Tracker.Views.FAQ
{
    public partial class SymptomsPage : ContentPage
    {
        SymptomsPageViewModel vm;

        public SymptomsPage()
        {
            InitializeComponent();

            vm = new SymptomsPageViewModel();
            BindingContext = vm;
        }
    }
}
