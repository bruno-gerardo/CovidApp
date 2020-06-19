using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    public class NewsPageViewModel : BaseViewModel
    {
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        private ObservableCollection<RssFeedItem> newsList;
        private ObservableCollection<RssFeedItem> toReadLaterList = new ObservableCollection<RssFeedItem>();
        private bool isRefreshing;

        public ObservableCollection<RssFeedItem> NewsList
        {
            get => newsList;
            set
            {
                newsList = value;
                OnPropertyChanged("NewsList");
            }
        }

        public ObservableCollection<RssFeedItem> ToReadLaterList
        {
            get => toReadLaterList;
            set
            {
                toReadLaterList = value;
                OnPropertyChanged("ToReadLaterList");
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public NewsPageViewModel()
        {
            GetData();
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            var news = await Api.GetNewsData();



            NewsList = new ObservableCollection<RssFeedItem>(NewsList.Select(c => c).Concat(news.items.Select(x => x)).Distinct().OrderByDescending(x => x.pubDate
            ).ToList());


            IsRefreshing = false;
        }

        public async Task GetData()
        {
            IsBusy = true;
            try
            {
                var news = await Api.GetNewsData();
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
