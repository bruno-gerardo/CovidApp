using System;
using System.ComponentModel;
using Covid19Tracker.Views.FAQ;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels.FAQ
{
    public class FaqPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TabItemCollection tabItems;

        public TabItemCollection TabItems
        {
            get { return tabItems; }
            set
            {
                tabItems = value;
                OnPropertyChanged("TabItems");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FaqPageViewModel()
        {
            SetTabItems();
        }

        internal void SetTabItems()
        {
            TabItems = new TabItemCollection();
            SymptomsPage page1 = new SymptomsPage();
            PreventionPage page2 = new PreventionPage();
            TabItems.Add(new SfTabItem
            {
                Content = page1.Content,
                Title = "Sintomas" ,
                TitleFontSize = 20,
                SelectionColor = Color.FromHex("#3F94B5"),
                TitleFontColor = Color.FromHex("#99A6C0"),
            });
            TabItems.Add(new SfTabItem
            {
                Content = page2.Content,
                Title = "Prevenção",
                TitleFontSize = 20,
                SelectionColor = Color.FromHex("#3F94B5"),
                TitleFontColor = Color.FromHex("#99A6C0"),
            });

        }
    }
}