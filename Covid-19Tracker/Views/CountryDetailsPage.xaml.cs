using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class CountryDetailsPage : ContentPage
    {
        public CountryDetailsPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        public ICommand BackCommand => new Command( async () => await Shell.Current.Navigation.PopAsync());
    }
}
