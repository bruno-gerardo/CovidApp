using System;
using System.Collections.Generic;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Covid19Tracker.ViewModels;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class PortugalPage : ContentPage
    {
        PortugalPageViewModel vm;
        public PortugalPage()
        {
            InitializeComponent();
           
            vm = new PortugalPageViewModel();
            BindingContext = vm;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await vm.GetData();
        //}

        void NumericalAxis_LabelCreated(System.Object sender, ChartAxisLabelEventArgs e)
        {

            e.LabelContent = e.LabelContent.TransformNumericString();
        }

        private void ChartView_TrackballCreated(object sender, ChartTrackballCreatedEventArgs e)
        {
            scrollview.IsEnabled = false;

            foreach (var item in e.ChartPointsInfo)
            {
                {
                    var data = item.DataPoint as TimeSeriesData;
                    if (item.Series.Label.Equals("Confirmados"))
                        item.Label = item.Series.Label + " : " + data.confirmed.TransformNumberToString();
                    if (item.Series.Label.Equals("Recuperados"))
                        item.Label = item.Series.Label + " : " + data.recovered.TransformNumberToString();
                    if (item.Series.Label.Equals("Mortes"))
                        item.Label = item.Series.Label + " : " + data.deaths.TransformNumberToString();
                    if (Device.RuntimePlatform != Device.UWP)
                        item.LabelStyle.TextColor = item.Series.Color;
                    item.LabelStyle.FontAttributes = FontAttributes.Bold;
                    item.LabelStyle.BackgroundColor = Color.FromHex("#e3e5ee");
                }
            }
            scrollview.IsEnabled = true;
        }
    }
}
