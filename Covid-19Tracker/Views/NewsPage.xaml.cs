﻿using System;
using System.Collections.Generic;
using System.Linq;
using Covid19Tracker.Helpers;
using Covid19Tracker.Model;
using Covid19Tracker.Services;
using Covid19Tracker.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19Tracker.Views
{
    public partial class NewsPage : ContentPage
    {
        NewsPageViewModel vm;
        public NewsPage()
        {
            InitializeComponent();
            vm = new NewsPageViewModel();
            BindingContext = vm;
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //var cenas = await Api.GetRSSFeedItemAsync();
        //    await vm.GetData();
        //}

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                NewsList.ItemsSource = vm.NewsList;
            else
                NewsList.ItemsSource = vm.NewsList.Where(i => i.title.RemoveDiacriticalMarks().ToLower().Contains(e.NewTextValue.RemoveDiacriticalMarks().ToLower()) ||
                                                              i.description.RemoveDiacriticalMarks().ToLower().Contains(e.NewTextValue.RemoveDiacriticalMarks().ToLower()) ||
                                                              i.author.RemoveDiacriticalMarks().ToLower().Contains(e.NewTextValue.RemoveDiacriticalMarks().ToLower()));
        }

        void SwipeItem_Invoked(object sender, EventArgs e)
        {

            var selectedItem = ((SwipeItem)sender).BindingContext as RssFeedItem;

            if (!vm.ToReadLaterList.Any(n => n.Equals(selectedItem)))
                vm.ToReadLaterList.Add(selectedItem);
            else
                vm.ToReadLaterList.Remove(selectedItem);
        }

        void NewsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is RssFeedItem selectedNews)
            {
                Browser.OpenAsync(selectedNews.link, BrowserLaunchMode.SystemPreferred);
            }

            ((CollectionView)sender).SelectedItem = null;


        }
    }
}
