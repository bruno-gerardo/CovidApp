using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Covid19Tracker.Model
{
    public class TimeSeriesData
    {

        [JsonProperty("confirmed")]
        public int confirmed { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("recovered")]
        public int recovered { get; set; }

        public DateTime? DateInfo { get => DateTime.Parse(date); }
    }

    public class TimeSeries
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("result")]
        public List<TimeSeriesData> result { get; set; }
    }
}
