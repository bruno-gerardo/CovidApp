using System;
using System.Collections.Generic;
using Covid19Tracker.ViewModels.Popups;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Covid19Tracker.Views.Popups
{
    public partial class SavedToReadPopupPage : PopupPage
    {
        SavedToReadPopupPageViewModel vm;
        public SavedToReadPopupPage()
        {
            InitializeComponent();
            vm = new SavedToReadPopupPageViewModel();
            BindingContext = vm;
        }
    }
}
