using System;
using System.Collections.Generic;
using System.Linq;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class SearchPage : ContentPage
    {
        SearchPageViewModel vm;
        public SearchPage()
        {
            InitializeComponent();
            vm = new SearchPageViewModel();
            BindingContext = vm;

            var lblTap = new TapGestureRecognizer();
            lblTap.Tapped += LblTap_Tapped;
            lblCompare.GestureRecognizers.Add(lblTap);
        }

        async void LblTap_Tapped(object sender, EventArgs e)
        {
            var lista = vm.MostAffectedCountriesList.Where(c => c.IsSelectedToCompare).ToList();

            var obj1 = JsonConvert.SerializeObject(lista[0]);
            var obj2 = JsonConvert.SerializeObject(lista[1]);

            await Shell.Current.GoToAsync($"compareCountriesPage?FirstCountryName={obj1}&SecondCountryName={obj2}");

        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CountriesList.ItemsSource = vm.MostAffectedCountriesList;
            else
                CountriesList.ItemsSource = vm.MostAffectedCountriesList.Where(i => i.Country.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        async void CountriesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is CountryCasesInfo selectedCountry)
            {
                var countryName = selectedCountry;
                var obj = JsonConvert.SerializeObject(countryName);
                obj.Replace(":/", "://");
                await Shell.Current.GoToAsync($"countryDetailsPage?CountryName={obj}");
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
