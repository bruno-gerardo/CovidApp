using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid_19Tracker;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public ICommand BackCommand => new Command(async () => await Shell.Current.GoToAsync(AppShell.HomePage, true));

        private ObservableCollection<CountryCasesInfo> mostAffectedCountriesList;

        public ObservableCollection<CountryCasesInfo> MostAffectedCountriesList
        {
            get => mostAffectedCountriesList;
            set
            {
                mostAffectedCountriesList = value;
                OnPropertyChanged("MostAffectedCountriesList");
            }
        }

        public SearchPageViewModel()
        {
            mostAffectedCountriesList = Singleton.Instance.CountryCases;
        }
    }
}