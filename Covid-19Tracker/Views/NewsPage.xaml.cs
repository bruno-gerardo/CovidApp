using System;
using System.Collections.Generic;
using Covid19Tracker.Services;
using Covid19Tracker.ViewModels;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class NewsPage : ContentPage
    {
        NewsPageViewModel vm;
        public NewsPage()
        {
            InitializeComponent();
            vm = new NewsPageViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //var cenas = await Api.GetRSSFeedItemAsync();
            await vm.GetData();
        }
    }
}
