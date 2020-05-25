using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isRefreshing;
        private bool isBusy;
        private string confirmed;
        private string todayCases;
        private string recovered;
        private string todayRecoverd;
        private string deaths;
        private string todayDeaths;
        private string updatedTime;
        private ObservableCollection<CountryCasesInfo> mostAffectedCountriesList;


        public string Deaths
        {
            get => deaths;
            set
            {
                deaths = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Deaths"));
            }
        }

        public string Recovered
        {
            get => recovered;
            set
            {
                recovered = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Recovered"));
            }
        }

        public string Confirmed
        {
            get => confirmed;
            set
            {
                confirmed = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Confirmed"));
            }
        }

        public string TodayCases
        {
            get => todayCases;
            set
            {
                todayCases = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TodayCases"));
            }
        }

        public string TodayDeaths
        {
            get => todayDeaths;
            set
            {
                todayDeaths = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TodayDeaths"));
            }
        }

        public string TodayRecovered
        {
            get => todayRecoverd;
            set
            {
                todayRecoverd = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TodayRecovered"));
            }
        }

        public string UpdatedTime
        {
            get => updatedTime;
            set
            {
                updatedTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UpdatedTime"));
            }
        }

        public ObservableCollection<CountryCasesInfo> MostAffectedCountriesList
        {
            get => mostAffectedCountriesList;
            set
            {
                mostAffectedCountriesList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MostAffectedCountriesList"));
            }
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }


        public HomePageViewModel()
        {
            
        }

        public async Task GlobalCasesInfoAsync()
        {
            //IsBusy = true;
            await GetData();
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await GetData();
            
            IsRefreshing = false;
        }

        public async Task GetData()
        {
            var globalCasesInfo = await Api.GetGlobalInfoAsync();
            var mostAffectedInfo = await Api.GetMostAffectedInfoAsync();
            MostAffectedCountriesList = new ObservableCollection<CountryCasesInfo>(mostAffectedInfo.Take(5).ToList());

            UpdatedTime = string.Format("Last Updated: {0}", globalCasesInfo.Updated.TransformLongToDateTime());
            Confirmed = globalCasesInfo.Cases.TransformNumberToString();
            TodayCases = string.Format("+{0}", globalCasesInfo.TodayCases.TransformNumberToString());
            Recovered = globalCasesInfo.Recovered.TransformNumberToString();
            Deaths = globalCasesInfo.Deaths.TransformNumberToString();
            TodayDeaths = string.Format("+{0}", globalCasesInfo.TodayDeaths.TransformNumberToString());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
