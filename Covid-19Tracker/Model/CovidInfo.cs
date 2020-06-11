using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Covid19Tracker.Model
{
    public class CovidInfo
    {
        public List<Symptoms> Symptoms { get; set; }
        public List<Preventions> Preventions { get; set; }
    }

    public class Symptoms
    {
        public string Symptom { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }
        public ImageSource Image { get => ImageSource.FromFile(string.Format("CovidIcons/Symptoms/{0}", ImageLocation)); }
    }

    public class Preventions
    {
        public string Prevention { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }
        public ImageSource Image { get => ImageSource.FromFile(string.Format("CovidIcons/Prevention/{0}",ImageLocation)); }
    }
}
