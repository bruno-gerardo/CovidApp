using System;
namespace Covid19Tracker.Model
{
    public class GlobalCasesInfo
    {
        public long Updated { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int TodayRecovered { get; set; }
        public int Active { get; set; }
        public int Critical { get; set; }
        public int CasesPerOneMillion { get; set; }
        public double DeathsPerOneMillion { get; set; }

        public string GlobalRecoveredPercentage { get => string.Format("{0:0.00}%", (double)Recovered * 100 / Cases); }
        public string GlobalDeathsPercentage { get => string.Format("{0:0.00}%", (double)Deaths * 100 / Cases); }
    }
}
