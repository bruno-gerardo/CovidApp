using System;
using System.Collections.Generic;
using Covid19Tracker.Model;

namespace Covid19Tracker.ViewModels.FAQ
{
    public class SymptomsPageViewModel
    {
        public List<Symptoms> Symptoms { get; set; }

        public SymptomsPageViewModel()
        {
            Symptoms = new List<Symptoms>()
            {
                new Symptoms() { Symptom = "Tosse", Description = "Um dos sintomas mais comuns é a tosse seca", ImageLocation = "cough.png"},
                new Symptoms() { Symptom = "Febre", Description = "Outro sintoma muito comum é a febre alta", ImageLocation = "fever.png"},
                new Symptoms() { Symptom = "Cansaço", Description = "Pessoas infectadas com o coronavírus podem sentir cansaço acima do normal", ImageLocation = "tiredness.png"},
                new Symptoms() { Symptom = "Falta de ar", Description = "Em casos mais graves, pode haver falta de ar. Este sintoma requer atenção médica", ImageLocation = "difficulty_breathing.png"}
            };
        }
    }
}
