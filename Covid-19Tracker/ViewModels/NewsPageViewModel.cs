using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Covid19Tracker.Model;
using Covid19Tracker.Services;

namespace Covid19Tracker.ViewModels
{
    public class NewsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<RssFeedItem> newsList;

        public ObservableCollection<RssFeedItem> NewsList
        {
            get => newsList;
            set
            {
                newsList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewsList"));
            }
        }

        public NewsPageViewModel()
        {
        }

        public async Task GetData()
        {
            var news = await Api.GetTeste();
            NewsList = new ObservableCollection<RssFeedItem>(news.items);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
