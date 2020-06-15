using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.CustomRenderers;
using Covid19Tracker.Views;
using Xamarin.Forms;

namespace Covid_19Tracker
{
    public partial class AppShell : CustomShell
    {
        // Constants of shell defined routes
        public const string HomePage = "//mainPage/homePage";
        public const string SearchPage = "//mainPage/searchPage";

        // Constants of shell non-defined routes


        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            var cenas = ShellTabBar;
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute("countryDetailsPage", typeof(CountryDetailsPage));
        }
    }
}
