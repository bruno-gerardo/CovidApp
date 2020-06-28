using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.ViewModels
{
    public class NewsPageViewModel : BaseViewModel
    {
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        private ObservableCollection<NewsItem> newsList;
        private ObservableCollection<NewsItem> toReadLaterList = new ObservableCollection<NewsItem>();
        private bool isRefreshing;

        public ObservableCollection<NewsItem> NewsList
        {
            get => newsList;
            set
            {
                newsList = value;
                OnPropertyChanged("NewsList");
            }
        }

        public ObservableCollection<NewsItem> ToReadLaterList
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
            GetSavedNews();
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            var news = await Api.GetNewsData();



            NewsList = new ObservableCollection<NewsItem>(NewsList.Select(c => c).Concat(news.items.Select(x => x)).Distinct().OrderByDescending(x => x.pubDate
            ).ToList());


            IsRefreshing = false;
        }

        public async Task GetData()
        {
            IsBusy = true;
            try
            {
                var news = await Api.GetNewsData();
                NewsList = new ObservableCollection<NewsItem>(news.items);
            }
            catch { }
            finally
            {
                IsBusy = false;
            }
        }

        public void GetSavedNews()
        {
            var properties = Application.Current.Properties;

            if (properties.ContainsKey("savedNews"))
            {
                var savedNews = properties["savedNews"].ToString();
                var obj = JsonConvert.DeserializeObject<List<NewsItem>>(savedNews);

                ToReadLaterList = new ObservableCollection<NewsItem>(obj);
            }
        }

        public async void PostSavedNews()
        {
            var properties = Application.Current.Properties;
            var obj = JsonConvert.SerializeObject(ToReadLaterList);

            if (!properties.ContainsKey("savedNews"))
            {
                
                properties.Add("savedNews", obj);
                await Application.Current.SavePropertiesAsync();
            }
            else
            {
                properties.Remove("savedNews");
                properties.Add("savedNews", obj);
                await Application.Current.SavePropertiesAsync();
            }
        }


    }
}
