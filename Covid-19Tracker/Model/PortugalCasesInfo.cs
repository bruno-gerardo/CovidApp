using System;
using System.Collections.ObjectModel;

namespace Covid19Tracker.Model
{
    public class PortugalCasesInfo
    {
        public string data { get; set; }
        public string data_dados { get; set; }
        public int confirmados { get; set; }
        public int confirmados_novos { get; set; }
        public int recuperados { get; set; }
        public int obitos { get; set; }
        public int internados { get; set; }
        public int internados_uci { get; set; }
        public int lab { get; set; }
        public int suspeitos { get; set; }
        public int vigilancia { get; set; }
        public int n_confirmados { get; set; }
        public int cadeias_transmissao { get; set; }
        public int transmissao_importada { get; set; }
        

        #region Sintomas
        public double sintomas_tosse { get; set; }
        public double sintomas_febre { get; set; }
        public double sintomas_dificuldade_respiratoria { get; set; }
        public double sintomas_cefaleia { get; set; }
        public double sintomas_dores_musculares { get; set; }
        public double sintomas_fraqueza_generalizada { get; set; }
        #endregion

        #region Dados Regiao
        #region Confirmados Regiao
        public int confirmados_arsnorte { get; set; }
        public int confirmados_arscentro { get; set; }
        public int confirmados_arslvt { get; set; }
        public int confirmados_arsalentejo { get; set; }
        public int confirmados_arsalgarve { get; set; }
        public int confirmados_acores { get; set; }
        public int confirmados_madeira { get; set; }
        public int confirmados_estrangeiro { get; set; }
        #endregion
        #region Obitos Regiao
        public int obitos_arsnorte { get; set; }
        public int obitos_arscentro { get; set; }
        public int obitos_arslvt { get; set; }
        public int obitos_arsalentejo { get; set; }
        public int obitos_arsalgarve { get; set; }
        public int obitos_acores { get; set; }
        public int obitos_madeira { get; set; }
        public int obitos_estrangeiro { get; set; }
        #endregion
        #region Recuperados Regiao
        public int recuperados_arsnorte { get; set; }
        public int recuperados_arscentro { get; set; }
        public int recuperados_arslvt { get; set; }
        public int recuperados_arsalentejo { get; set; }
        public int recuperados_arsalgarve { get; set; }
        public int recuperados_acores { get; set; }
        public int recuperados_madeira { get; set; }
        public int recuperados_estrangeiro { get; set; }
        #endregion
        #endregion
        #region Idade e Genero
        #region Confirmados Idade
        public int confirmados_0_9_f { get; set; }
        public int confirmados_0_9_m { get; set; }
        public int confirmados_10_19_f { get; set; }
        public int confirmados_10_19_m { get; set; }
        public int confirmados_20_29_f { get; set; }
        public int confirmados_20_29_m { get; set; }
        public int confirmados_30_39_f { get; set; }
        public int confirmados_30_39_m { get; set; }
        public int confirmados_40_49_f { get; set; }
        public int confirmados_40_49_m { get; set; }
        public int confirmados_50_59_f { get; set; }
        public int confirmados_50_59_m { get; set; }
        public int confirmados_60_69_f { get; set; }
        public int confirmados_60_69_m { get; set; }
        public int confirmados_70_79_f { get; set; }
        public int confirmados_70_79_m { get; set; }
        public int confirmados_80_plus_f { get; set; }
        public int confirmados_80_plus_m { get; set; }
        #endregion
        #region Confirmados Genero
        public int confirmados_f { get; set; }
        public int confirmados_m { get; set; }
        #endregion
        #region Obitos Idade
        public int obitos_0_9_f { get; set; }
        public int obitos_0_9_m { get; set; }
        public int obitos_10_19_f { get; set; }
        public int obitos_10_19_m { get; set; }
        public int obitos_20_29_f { get; set; }
        public int obitos_20_29_m { get; set; }
        public int obitos_30_39_f { get; set; }
        public int obitos_30_39_m { get; set; }
        public int obitos_40_49_f { get; set; }
        public int obitos_40_49_m { get; set; }
        public int obitos_50_59_f { get; set; }
        public int obitos_50_59_m { get; set; }
        public int obitos_60_69_f { get; set; }
        public int obitos_60_69_m { get; set; }
        public int obitos_70_79_f { get; set; }
        public int obitos_70_79_m { get; set; }
        public int obitos_80_plus_f { get; set; }
        public int obitos_80_plus_m { get; set; }
        #endregion
        #region Obitos Genero
        public int obitos_f { get; set; }
        public int obitos_m { get; set; }
        #endregion
        #endregion

        #region Obitos Total Idade
        public int obitos_0_9_total { get => obitos_0_9_f + obitos_0_9_m; }
        public int obitos_10_19_total { get => obitos_10_19_f + obitos_10_19_m; }
        public int obitos_20_29_total { get => obitos_20_29_f + obitos_20_29_m; }
        public int obitos_30_39_total { get => obitos_30_39_f + obitos_30_39_m; }
        public int obitos_40_49_total { get => obitos_40_49_f + obitos_40_49_m; }
        public int obitos_50_59_total { get => obitos_50_59_f + obitos_50_59_m; }
        public int obitos_60_69_total { get => obitos_60_69_f + obitos_60_69_m; }
        public int obitos_70_79_total { get => obitos_70_79_f + obitos_70_79_m; }
        public int obitos_80_plus_total { get => obitos_80_plus_f + obitos_80_plus_m; }
        #endregion

        #region Confirmados Total Idade
        public int confirmados_0_9_total { get => confirmados_0_9_f + confirmados_0_9_m; }
        public int confirmados_10_19_total { get => confirmados_10_19_f + confirmados_10_19_m; }
        public int confirmados_20_29_total { get => confirmados_20_29_f + confirmados_20_29_m; }
        public int confirmados_30_39_total { get => confirmados_30_39_f + confirmados_30_39_m; }
        public int confirmados_40_49_total { get => confirmados_40_49_f + confirmados_40_49_m; }
        public int confirmados_50_59_total { get => confirmados_50_59_f + confirmados_50_59_m; }
        public int confirmados_60_69_total { get => confirmados_60_69_f + confirmados_60_69_m; }
        public int confirmados_70_79_total { get => confirmados_70_79_f + confirmados_70_79_m; }
        public int confirmados_80_plus_total { get => confirmados_80_plus_f + confirmados_80_plus_m; }
        #endregion

        public class Regiao
        {
            public string regiao { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int confirmados { get; set; }
            public int recuperados { get; set; }
            public int obitos { get; set; }
        }

        public ObservableCollection<Regiao> Regioes => new ObservableCollection<Regiao>()
        {
            new Regiao
                {
                    regiao = "Norte",
                    latitude = 41.45756,
                    longitude = -7.67865,
                    confirmados = confirmados_arsnorte,
                    recuperados = recuperados_arsnorte,
                    obitos = obitos_arsnorte

                },
                new Regiao
                {
                    regiao = "Centro",
                    latitude = 41.45756,
                    longitude = -7.67865,
                    confirmados = confirmados_arscentro,
                    recuperados = recuperados_arscentro,
                    obitos = obitos_arscentro

                },
                new Regiao
                {
                    regiao = "Lisboa e Vale do Tejo",
                    latitude = 39.16054,
                    longitude = -8.74521,
                    confirmados = confirmados_arslvt,
                    recuperados = recuperados_arslvt,
                    obitos = obitos_arslvt

                },
                new Regiao
                {
                    regiao = "Alentejo",
                    latitude = 38.39168,
                    longitude = -7.92234,
                    confirmados = confirmados_arsalentejo,
                    recuperados = recuperados_arsalentejo,
                    obitos = obitos_arsalentejo

                },
                new Regiao
                {
                    regiao = "Algarve",
                    latitude = 37.24368,
                    longitude = -8.13171,
                    confirmados = confirmados_arsalgarve,
                    recuperados = recuperados_arsalgarve,
                    obitos = obitos_arsalgarve

                },
                new Regiao
                {
                    regiao = "Açores",
                    latitude = 38.58323,
                    longitude = -28.196631,
                    confirmados = confirmados_acores,
                    recuperados = recuperados_acores,
                    obitos = obitos_acores

                },
                new Regiao
                {
                    regiao = "Madeira",
                    latitude = 32.75078,
                    longitude = -16.95118,
                    confirmados = confirmados_madeira,
                    recuperados = recuperados_madeira,
                    obitos = obitos_madeira

                }
        };
    }
}
