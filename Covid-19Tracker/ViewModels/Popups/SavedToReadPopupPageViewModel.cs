using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels.Popups
{
    public class SavedToReadPopupPageViewModel : BaseViewModel
    {
        public SavedToReadPopupPageViewModel()
        {
            ExecuteClosePopUpCommand();
        }

        public Command ClosePopUpCommand { get; }

        private async void ExecuteClosePopUpCommand()
        {
            await Task.Delay(1350);
            if(PopupNavigation.Instance.PopupStack.Count != 0)
                await PopupNavigation.Instance.PopAsync(true);
        }
    }
}
