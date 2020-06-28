using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Covid_19Tracker.Services;
//using Covid_19Tracker.Views;



namespace Covid_19Tracker
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc1NTg0QDMxMzgyZTMxMmUzMElkR2tQV3BwTFhJMjN0TVdteEtLWXgxajdHb3JxZFZGY0h1aHgvc3ovb1E9");


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
