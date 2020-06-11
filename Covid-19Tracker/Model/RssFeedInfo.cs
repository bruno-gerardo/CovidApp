using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Covid19Tracker.Model
{
    public class RssFeedItem
    {
        public string title { get; set; }
        public string pubDate { get; set; }
        public string link { get; set; }
        public string guid { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }

    public class RssFeedInfo
    {
        [JsonProperty("items")]
        public List<RssFeedItem> items = new List<RssFeedItem>(); //{ get; set; }
    }
}
