﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Covid19Tracker.Model;
using Covid19Tracker.Services;

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

        public PortugalPageViewModel()
        {
        }

        public async Task GetData()
        {
            var portugalCases = await Api.GetPortugalCasesInfoAsync();
            PortugalInfo = portugalCases;
        }
    }
}