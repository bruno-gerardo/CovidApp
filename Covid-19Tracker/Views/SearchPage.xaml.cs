﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(vm.MostAffectedCountriesList == null)
                await vm.GetData();
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CountriesList.ItemsSource = vm.MostAffectedCountriesList;
            else
                CountriesList.ItemsSource = vm.MostAffectedCountriesList.Where(i => i.Country.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        async void CountriesList_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
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
