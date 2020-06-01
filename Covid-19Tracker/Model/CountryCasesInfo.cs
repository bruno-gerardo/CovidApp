using System.Collections.Generic;
using Covid19Tracker.Helpers;
using Newtonsoft.Json;

namespace Covid19Tracker.Model
{

    public class CountryInfo
    {
        [JsonProperty("_id")]
        public int? Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Flag { get; set; }
    }

    public class CountryCasesInfo
    {
        public long Updated { get; set; }
        public string Country { get; set; }
        public CountryInfo CountryInfo { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public int Critical { get; set; }
        public double CasesPerOneMillion { get; set; }
        public double DeathsPerOneMillion { get; set; }
        public int Tests { get; set; }
        public int TestsPerOneMillion { get; set; }
        public int Population { get; set; }
        public string Continent { get; set; }
        public double ActivePerOneMillion { get; set; }
        public double RecoveredPerOneMillion { get; set; }
        public double CriticalPerOneMillion { get; set; }
        public List<TimeSeriesData> TimeSeries { get; set; }

        public string CasesFormatted
        {
            get => Cases.TransformNumberToString();
        }

        public string DeathsFormatted
        {
            get => Deaths.TransformNumberToString();
        }

        public string RecoveredFormatted
        {
            get => Recovered.TransformNumberToString();
        }

    }
}