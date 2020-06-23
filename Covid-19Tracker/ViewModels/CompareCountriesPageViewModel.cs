using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    [QueryProperty("FirstCountry", "FirstCountryName")]
    [QueryProperty("SecondCountry", "SecondCountryName")]
    public class CompareCountriesPageViewModel : BaseViewModel
    {


        public string FirstCountryName { get; set; }
        public string FirstCountry
        {
            set
            {
                var obj = Uri.UnescapeDataString(value.Replace(":/", "://"));
                FirstCountryCases = JsonConvert.DeserializeObject<CountryCasesInfo>(obj);
                if (FirstCountryCases != null)
                {
                    FirstCountryInfo = FirstCountryCases.CountryInfo;
                    OnPropertyChanged("FirstCountryCases");
                    OnPropertyChanged("FirstCountryInfo");
                }
            }
        }

        public string SecondCountryName { get; set; }
        public string SecondCountry
        {
            set
            {
                var obj = Uri.UnescapeDataString(value.Replace(":/", "://"));
                SecondCountryCases = JsonConvert.DeserializeObject<CountryCasesInfo>(obj);
                if (SecondCountryCases != null)
                {
                    SecondCountryInfo = SecondCountryCases.CountryInfo;
                    OnPropertyChanged("SecondCountryCases");
                    OnPropertyChanged("SecondCountryInfo");
                }
            }
        }

        public CountryCasesInfo FirstCountryCases { get; set; }
        public CountryCasesInfo SecondCountryCases { get; set; }

        public GlobalCasesInfo GlobalCases { get; set; }


        public CountryInfo FirstCountryInfo { get; private set; }
        public CountryInfo SecondCountryInfo { get; private set; }

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
            TodayDate = DateTime.UtcNow.ToString("d/MM/yyyy");
            //var timeSeries = await Api.GetCountryTimeSeriesAsync(CountryInfo.Iso3);
            //if (timeSeries != null)
            //    CountryCases.TimeSeries = new List<TimeSeriesData>(timeSeries.result);
            OnPropertyChanged("FirstCountryCasesInfo");
            OnPropertyChanged("FirstCountryInfo");
            OnPropertyChanged("SecondCountryCasesInfo");
            OnPropertyChanged("SecondCountryInfo");
        }

        public CompareCountriesPageViewModel()
        {
        }
    }
}
