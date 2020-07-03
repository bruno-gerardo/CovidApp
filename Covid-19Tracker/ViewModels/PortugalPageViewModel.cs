using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Xamarin.Forms;
using static Covid19Tracker.Model.PortugalCasesInfo;

namespace Covid19Tracker.ViewModels
{
    public class PortugalPageViewModel : BaseViewModel
    {
        private PortugalCasesInfo portugalInfo;

        public PortugalCasesInfo PortugalInfo
        {
            get => portugalInfo;
            set
            {
                portugalInfo = value;
                OnPropertyChanged("PortugalInfo");
            }
        }

        private bool confirmedChartIsVisible = true;
        public bool ConfirmedChartIsVisible
        {
            get => confirmedChartIsVisible;
            set
            {
                confirmedChartIsVisible = value;
                OnPropertyChanged("ConfirmedChartIsVisible");
                OnPropertyChanged("DeathsChartIsVisible");
            }
        }

        public bool DeathsChartIsVisible
        {
            get => !ConfirmedChartIsVisible;
        }


        public ICommand ChangeChartCommand => new Command(() => ChangeVisibility());

        private void ChangeVisibility()
        {
            ConfirmedChartIsVisible = !ConfirmedChartIsVisible;
        }

        public PortugalPageViewModel()
        {
        }

        public async Task GetData()
        {
            var portugalCases = await Api.GetPortugalCasesInfoAsync();
            var timeSeries = await Api.GetCountryTimeSeriesAsync("PRT");
            PortugalInfo = portugalCases;
            if (timeSeries != null)
            {
                timeSeries.result = timeSeries.result.Where(t => t.confirmed >= 100).ToList();
                PortugalInfo.TimeSeries = new List<TimeSeriesData>(timeSeries.result);
            }
            OnPropertyChanged("PortugalInfo");


        }
    }
}
