using System;
using System.Collections.Generic;
using System.Linq;
using Covid_19Tracker;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Covid19Tracker.ViewModels;
using Newtonsoft.Json;
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

            TapGestureRecognizer tap = new TapGestureRecognizer();

            tap.Tapped += async (object sender, EventArgs e) =>
            {
                //await Shell.Current.GoToAsync("///searchPage");
                await Shell.Current.GoToAsync(AppShell.SearchPage);
                
            };

            WorldwideInfoStack.GestureRecognizers.Add(tap);

                

        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await vm.GlobalCasesInfoAsync();
        //}

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is CountryCasesInfo selectedCountry)
            {
                var countryName = selectedCountry;
                var obj = JsonConvert.SerializeObject(countryName);
                await Shell.Current.GoToAsync($"countryDetailsPage?CountryName={obj}");
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
