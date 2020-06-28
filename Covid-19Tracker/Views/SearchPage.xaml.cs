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
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            compareButton.GestureRecognizers.Add(tap);
        }

        async void Tap_Tapped(object sender, EventArgs e)
        {
            var selectedItems = vm.CountriesList.Where(c => c.IsSelectedToCompare).ToList();

            var obj1 = JsonConvert.SerializeObject(selectedItems.First());
            var obj2 = JsonConvert.SerializeObject(selectedItems.Last());

            //CountriesToCompareList.SelectedItems = null;
            await Shell.Current.GoToAsync($"compareCountriesPage?FirstCountryName={obj1}&SecondCountryName={obj2}");

            CountriesToCompareList.SelectedItems = null;
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                CountriesList.ItemsSource = vm.MostAffectedCountriesList;
                CountriesToCompareList.ItemsSource = vm.CountriesList;
            }
            else
            {
                CountriesList.ItemsSource = vm.MostAffectedCountriesList.Where(i => i.Country.ToLower().Contains(e.NewTextValue.ToLower()));
                CountriesToCompareList.ItemsSource = vm.CountriesList.Where(i => i.Country.ToLower().Contains(e.NewTextValue.ToLower()));
            }
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

        

        void CountriesToCompareList_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 2)
                vm.GoToCompareIsVisible = true;
            else
                vm.GoToCompareIsVisible = false;

            if (e.CurrentSelection.Count > 2)
            {
                CountriesToCompareList.SelectedItems.Remove(CountriesToCompareList.SelectedItems.LastOrDefault());
            }

            if(CountriesToCompareList.SelectedItems.Count != 0)
            {
                var teste = CountriesToCompareList.SelectedItems.Intersect(e.CurrentSelection);
               

                foreach(var item in teste)
                    ((CountryCasesInfo)item).IsSelectedToCompare = true;
            }

            var distinct = e.PreviousSelection.Except(CountriesToCompareList.SelectedItems);
            foreach (var item in distinct)
                ((CountryCasesInfo)item).IsSelectedToCompare = false;

        }
    }
}
