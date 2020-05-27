using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Views;
using Xamarin.Forms;

namespace Covid_19Tracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        // Constants of shell defined routes
        public const string SearchPage = "//mainPage/searchPage";

        // Constants of shell non-defined routes


        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute("countryDetailsPage", typeof(CountryDetailsPage));
        }
    }
}
