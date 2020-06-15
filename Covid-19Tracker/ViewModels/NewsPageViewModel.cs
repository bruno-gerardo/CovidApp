using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Covid19Tracker.Model;
using Covid19Tracker.Services;

namespace Covid19Tracker.ViewModels
{
    public class NewsPageViewModel : BaseViewModel
    {
        private ObservableCollection<RssFeedItem> newsList;

        public ObservableCollection<RssFeedItem> NewsList
        {
            get => newsList;
            set
            {
                newsList = value;
                OnPropertyChanged("NewsList");
            }
        }

        public NewsPageViewModel()
        {
        }

        public async Task GetData()
        {
            IsBusy = true;
            try
            {
                var news = await Api.GetTeste();
                NewsList = new ObservableCollection<RssFeedItem>(news.items);
            }
            catch { }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
