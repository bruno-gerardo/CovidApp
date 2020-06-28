using System;
using System.Threading.Tasks;
using Covid19Tracker.Model;
using RestSharp;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Text;

namespace Covid19Tracker.Services
{
    public class Api
    {
        private static RestClient _restClient = new RestClient("https://disease.sh/v2/"); // API Corona
        //private static RestClient _restClient = new RestClient("https://api.caw.sh/v2/"); // API Corona

        private static RestClient _restClientPortugal = new RestClient("https://covid19-api.vost.pt/Requests"); // API DSSG

        private static RestClient _restClientTimeSeries = new RestClient("https://covidapi.info/api/v1/country/"); // API TimeSeries

        private static string GetAll = "all";
        private static string GetCountries = "countries";
        private static string MostAffected = "countries?sort=cases";
        private static string TimeSeries = "/timeseries/2020-02-20/2020-06-20";

        private static string PortugalLastUpdate = "/get_last_update";


        public static async Task<GlobalCasesInfo> GetGlobalInfoAsync()
        {
            //try
            //{
                var request = new RestRequest(string.Format(GetAll), Method.GET);

                //request.AddHeader("Authorization", "Basic " + authHeaderValue);

                var response = await _restClient.ExecuteAsync<GlobalCasesInfo>(request);

                //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //    return new DashboardCheckupInfoPM()
                //    {
                //        Error = Error.NOT_AUTHORIZED(journeyId)
                //    };

                //return JsonConvert.DeserializeObject<GlobalCasesInfo>(response.Content);
                return response.Data;
            //}
            //catch(Exception e)
            //{

            //}
        }

        public static async Task<List<CountryCasesInfo>> GetMostAffectedInfoAsync()
        {
            var request = new RestRequest(string.Format(MostAffected), Method.GET);

            var response = await _restClient.ExecuteAsync<List<CountryCasesInfo>>(request);

            //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //    return new DashboardCheckupInfoPM()
            //    {
            //        Error = Error.NOT_AUTHORIZED(journeyId)
            //    };

            //return JsonConvert.DeserializeObject<List<CountryCasesInfo>>(response.Content);
            return response.Data;
        }

        public static async Task<List<CountryCasesInfo>> GetCountriesAsync()
        {
            var request = new RestRequest(string.Format(GetCountries), Method.GET);

            var response = await _restClient.ExecuteAsync<List<CountryCasesInfo>>(request);

            return response.Data;
        }

        public static async Task<TimeSeries> GetCountryTimeSeriesAsync(string countryISO3)
        {
            var request = new RestRequest(string.Format(string.Concat(countryISO3, TimeSeries)), Method.GET);

            var response = await _restClientTimeSeries.ExecuteAsync<TimeSeries>(request);

            return response.Data;
        }

        public static async Task<PortugalCasesInfo> GetPortugalCasesInfoAsync()
        {
            var request = new RestRequest(string.Format(PortugalLastUpdate), Method.GET);

            var response = await _restClientPortugal.ExecuteAsync<PortugalCasesInfo>(request);

            return response.Data;
        }

        public static async Task<NewsInfo> GetNewsData()
        {

            var link = "https://news.google.com/news?q=covid-19&hl=pt-PT&sort=date&gl=PT&num=100&ceid=PT:pt-150";

            var web = new HtmlWeb();


            var doc = await web.LoadFromWebAsync(link);

            var cenas = doc.DocumentNode.SelectSingleNode("//div[@class='lBwEZb BL5WZb xP6mwf']");

            var child = cenas.SelectNodes("//div[@class='NiLAwe y6IFtc R7GTQ keNKEd j7vNaf nID9nc']//article").ToList();

            var rssInfo = new NewsInfo()
            {
                items = new List<NewsItem>()
                {

                }
            };

            rssInfo.items.Clear();
            foreach (var item in child)
            {

                //TODO Order by pubdate
                var titulo = item.ChildNodes.FindFirst("h3").InnerText.Replace("&quot;","\"")
                                                                      .Replace("&amp;","&")
                                                                      .Replace("&#39;","'");
                var imagem = item.ParentNode.PreviousSibling.FirstChild.ChildNodes.FindFirst("img").ChildAttributes("src").First().Value;
                var srcImage = imagem.Replace("h100-w100", "h200-w200");
                var descri = item.ChildNodes.FindFirst("div").FirstChild.InnerText.Replace("&quot;", "\"")
                                                                                  .Replace("&amp;", "&")
                                                                                  .Replace("&#39;", "'");
                var author = item.ChildNodes.Last().FirstChild.ChildNodes.FindFirst("a").InnerText;
                var pubDate = item.ChildNodes.Last().FirstChild.ChildNodes.FindFirst("time").ChildAttributes("datetime").First().Value;
                string url = item.FirstChild.ChildAttributes("href").First().Value;
                //url = Regex.Match(url, @"(https?):\/\/(www\.)?[a-z0 - 9\.:].*?(?=[;\s])").ToString();
                url = string.Concat("https://news.google.pt",url.Substring(1));

                NewsItem rssitem = new NewsItem()
                {
                    title = titulo,
                    author = author,
                    description = descri,
                    thumbnail = srcImage,
                    pubDate = pubDate,
                    link = url
                };

                rssInfo.items.Add(rssitem);

            }

            rssInfo.items = (from item in rssInfo.items
                             orderby DateTime.Parse(item.pubDate) descending
                             select item).ToList();

            return rssInfo;
        }


    }
}
