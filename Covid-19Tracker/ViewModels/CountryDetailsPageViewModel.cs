﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Covid19Tracker.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    [QueryProperty("Country","CountryName")]
    public class CountryDetailsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string CountryName { get; set; }
        public string Country
        {
            set
            {
                var obj = Uri.UnescapeDataString(value.Replace(":/","://"));
                CountryCases = JsonConvert.DeserializeObject<CountryCasesInfo>(obj);
                if(CountryCases != null)
                {
                    CountryInfo = CountryCases.CountryInfo;
                    PropertyChanged(this, new PropertyChangedEventArgs("CountryCases"));
                    PropertyChanged(this, new PropertyChangedEventArgs("CountryInfo"));
                }
            }
        }
        
        public CountryCasesInfo CountryCases { get; set; }


        public CountryInfo CountryInfo { get; private  set; }
        

        public ICommand BackCommand => new Command(async () => await Shell.Current.Navigation.PopAsync());


        public CountryDetailsPageViewModel()
        {
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}