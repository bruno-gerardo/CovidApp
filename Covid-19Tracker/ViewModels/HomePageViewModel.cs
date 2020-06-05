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
using Covid19Tracker.Views;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        private bool isRefreshing;
        private bool isBusy;
        private string confirmed;
        private string todayCases;
        private string active;
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

        public string Active
        {
            get => active;
            set
            {
                active = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Active"));
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
            var mostAffectedInfo = await Api.GetCountriesAsync();
            Singleton.Instance.CountryCases = new ObservableCollection<CountryCasesInfo>(mostAffectedInfo);
            Singleton.Instance.GlobalCases = globalCasesInfo;

            var sortedList = mostAffectedInfo.OrderByDescending(c => c.Cases).ToList();
            MostAffectedCountriesList = new ObservableCollection<CountryCasesInfo>(sortedList.Take(5));

            foreach(var item in mostAffectedInfo)
            {
                var sortedCases = mostAffectedInfo.OrderByDescending(c => c.Cases).ToList();
                var index = sortedCases.IndexOf(item) +1;
                item.ConfirmedRankingPosition = index.ToString();
            }

            foreach (var item in mostAffectedInfo)
            {
                var sortedCases = mostAffectedInfo.OrderByDescending(c => c.Deaths).ToList();
                var index = sortedCases.IndexOf(item) + 1;
                item.DeathsRankingPosition = index.ToString();
            }

            foreach (var item in mostAffectedInfo)
            {
                var sortedCases = mostAffectedInfo.OrderByDescending(c => c.Recovered).ToList();
                var index = sortedCases.IndexOf(item) + 1;
                item.RecoveredRankingPosition = index.ToString();
            }

            foreach (var item in mostAffectedInfo)
            {
                var sortedCases = mostAffectedInfo.OrderByDescending(c => c.Active).ToList();
                var index = sortedCases.IndexOf(item) + 1;
                item.ActiveRankingPosition = index.ToString();
            }



            UpdatedTime = string.Format("Last Updated: {0}", globalCasesInfo.Updated.TransformLongToDateTime());
            Confirmed = globalCasesInfo.Cases.TransformNumberToString();
            Active = globalCasesInfo.Active.TransformNumberToString();
            TodayCases = string.Format("+{0}", globalCasesInfo.TodayCases.TransformNumberToString());
            TodayRecovered = string.Format("+{0}", globalCasesInfo.TodayRecovered.TransformNumberToString());
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
