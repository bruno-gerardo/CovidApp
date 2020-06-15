using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    [QueryProperty("Country","CountryName")]
    public class CountryDetailsPageViewModel : BaseViewModel
    {


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
                    OnPropertyChanged("CountryCases");
                    OnPropertyChanged("CountryInfo");
                }
            }
        }
        
        public CountryCasesInfo CountryCases { get; set; }

        public GlobalCasesInfo GlobalCases { get; set; }


        public CountryInfo CountryInfo { get; private  set; }

        public ICommand BackCommand => new Command(async () => await Shell.Current.Navigation.PopAsync());

        private string todayDate;

        public string TodayDate
        {
            get => todayDate;

            set
            {
                todayDate = value;
                OnPropertyChanged("TodayDate");
            }
        }

        public async Task GetData()
        {
            GlobalCases = Singleton.Instance.GlobalCases;
            TodayDate = DateTime.UtcNow.ToString("d/M/yyyy");
            var timeSeries = await Api.GetCountryTimeSeriesAsync(CountryInfo.Iso3);
            if(timeSeries != null)
                CountryCases.TimeSeries = new List<TimeSeriesData>(timeSeries.result);
            OnPropertyChanged("CountryCases");
            OnPropertyChanged("GlobalCases");
        }
    }
}
