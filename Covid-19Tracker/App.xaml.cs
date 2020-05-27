using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Covid_19Tracker.Services;
//using Covid_19Tracker.Views;

[assembly: ExportFont("FabMDL2.ttf", Alias = "MyAwesomeCustomFont")]

namespace Covid_19Tracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
