using System;
using System.Collections.Generic;
using Covid19Tracker.Model;

namespace Covid19Tracker.ViewModels.FAQ
{
    public class PreventionPageViewModel
    {
        public List<Preventions> Preventions { get; set; }

        public PreventionPageViewModel()
        {
            Preventions = new List<Preventions>()
            {
                new Preventions() { Prevention = "Lave as mãos", Description = "Lave as mãos por 20 segundos com água e sabão ou limpe-as com álcool em gel", ImageLocation = "wash_hands.png"},
                new Preventions() { Prevention = "Cubra o nariz e a boca", Description = "Quando espirrar ou tossir, cubra o nariz e a boca com um lenço ou o braço, perto do cotovelo", ImageLocation = "how_to_cough.png"},
                new Preventions() { Prevention = "Evite contato próximo", Description = "Evite contato próximo (1 metro de distância) com pessoas doentes", ImageLocation = "avoid_contact.png"},
                new Preventions() { Prevention = "Não toque no seu rosto", Description = "Evite tocar seus olhos, nariz e boca se suas mãos não estiverem higienizadas", ImageLocation = "do_not_touch_the_face.png"},
                new Preventions() { Prevention = "Fique em casa", Description = "Se tiver sintomas, fique em casa e evite contato com outras pessoas, inclusive os demais moradores da sua casa", ImageLocation = "stay_home.png"},
                new Preventions() { Prevention = "Use máscara, se necessário", Description = "Use máscara se estiver com tosse, espirros ou a cuidar de alguém com suspeita de covid-19", ImageLocation = "mask.png"},
            };
        }
    }
}