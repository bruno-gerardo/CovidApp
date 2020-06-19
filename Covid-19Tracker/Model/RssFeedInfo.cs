using System;
using System.Collections.Generic;
using Covid19Tracker.Helpers;
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
        public string pubDateFormatted { get => ExtensionMethods.TimeAgo(DateTime.Parse(pubDate)); }

        public override bool Equals(object obj)
        {
            return Equals(obj as RssFeedItem);
        }

        public bool Equals(RssFeedItem obj)
        {
            return obj != null && obj.title == this.title && obj.author == this.author && obj.description == this.description; 
        }

        public override int GetHashCode()
        {
            int hashCode = -1067488440;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            return hashCode;
        }
    }

    public class RssFeedInfo
    {
        [JsonProperty("items")]
        public List<RssFeedItem> items = new List<RssFeedItem>(); //{ get; set; }
    }
}
