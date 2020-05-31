using System;
using System.Threading.Tasks;
using Covid19Tracker.Model;
using RestSharp;
using System.Collections.Generic;

namespace Covid19Tracker.Services
{
    public class Api
    {
        private static RestClient _restClient = new RestClient("https://disease.sh/v2/"); // API Corona

        private static string GetAll = "all";
        private static string GetCountries = "countries";
private static string MostAffected = "countries?sort=cases";

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
            request.RequestFormat = DataFormat.Json;

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
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteAsync<List<CountryCasesInfo>>(request);

            return response.Data;
        }
    }
}
