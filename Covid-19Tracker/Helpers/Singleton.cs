using System;
using System.Collections.ObjectModel;
using Covid19Tracker.Model;

namespace Covid19Tracker.Helpers
{
    public sealed class Singleton
    {

        
        public ObservableCollection<CountryCasesInfo> CountryCases { get; set; }

        static Singleton()
        {
        }

        Singleton()
        {
        }

        public static Singleton Instance { get; } = new Singleton();
    }
}
