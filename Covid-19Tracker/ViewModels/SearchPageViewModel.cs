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

        private bool countriesListIsVisible = true;
        private bool countriesToCompareIsVisible = false;
        private bool goToCompareIsVisible = false;
        private ObservableCollection<CountryCasesInfo> mostAffectedCountriesList;
        private ObservableCollection<CountryCasesInfo> countriesList;


        public ObservableCollection<CountryCasesInfo> MostAffectedCountriesList
        {
            get => mostAffectedCountriesList;
            set
            {
                mostAffectedCountriesList = value;
                OnPropertyChanged("MostAffectedCountriesList");
            }
        }

        public ObservableCollection<CountryCasesInfo> CountriesList
        {
            get => countriesList;
            set
            {
                countriesList = value;
                OnPropertyChanged("CountriesList");
            }
        }

        public bool CountriesListIsVisible
        {
            get => countriesListIsVisible;
            set
            {
                countriesListIsVisible = value;
                OnPropertyChanged("CountriesListIsVisible");
            }
        }

        public bool CountriesToCompareIsVisible
        {
            get => countriesToCompareIsVisible;
            set
            {
                countriesToCompareIsVisible = value;
                OnPropertyChanged("CountriesToCompareIsVisible");
            }
        }

        public bool GoToCompareIsVisible
        {
            get => goToCompareIsVisible;
            set
            {
                goToCompareIsVisible = value;
                OnPropertyChanged("GoToCompareIsVisible");
            }
        }

        public SearchPageViewModel()
        {
            MostAffectedCountriesList = new ObservableCollection<CountryCasesInfo>(Singleton.Instance.CountryCases);

            CountriesList = new ObservableCollection<CountryCasesInfo>(mostAffectedCountriesList);
        }

        public ICommand ChangeVisibilityCommand => new Command(() => ChangeVisibility());

        private void ChangeVisibility()
        {
            CountriesListIsVisible = !CountriesListIsVisible;
            CountriesToCompareIsVisible = !CountriesToCompareIsVisible;
        }
    }
}