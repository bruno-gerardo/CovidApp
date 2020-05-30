using System;
using System.Windows.Input;
using Covid_19Tracker;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    public class SearchPageViewModel
    {
        public ICommand BackCommand => new Command(async () => await Shell.Current.GoToAsync(AppShell.HomePage, true));

        public SearchPageViewModel()
        {
        }
    }
}
