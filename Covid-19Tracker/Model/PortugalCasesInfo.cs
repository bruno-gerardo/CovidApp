using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Covid19Tracker.Helpers;
using Xamarin.Forms;

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
        #region To add?
        //TODO ADD
        public int lab { get; set; }
        public int suspeitos { get; set; }
        public int vigilancia { get; set; }
        public int n_confirmados { get; set; }
        #endregion
        public int cadeias_transmissao { get => confirmados - transmissao_importada; }
        public int transmissao_importada { get; set; }

        public List<TimeSeriesData> TimeSeries { get; set; }

        #region Sintomas
        public double sintomas_tosse { get; set; }
        public double sintomas_febre { get; set; }
        public double sintomas_dificuldade_respiratoria { get; set; }
        public double sintomas_cefaleia { get; set; }
        public double sintomas_dores_musculares { get; set; }
        public double sintomas_fraqueza_generalizada { get; set; }

        public double sintomas_tosse_per { get => sintomas_tosse * 100; }
        public double sintomas_febre_per { get => sintomas_febre * 100; }
        public double sintomas_dificuldade_respiratoria_per { get => sintomas_dificuldade_respiratoria * 100; }
        public double sintomas_cefaleia_per { get => sintomas_cefaleia * 100; }
        public double sintomas_dores_musculares_per { get => sintomas_dores_musculares * 100; }
        public double sintomas_fraqueza_generalizada_per { get => sintomas_fraqueza_generalizada * 100; }
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

        public GridLength RecoveredWidht { get => new GridLength((double)recuperados / confirmados, GridUnitType.Star); }
        public GridLength ActiveWidht { get => new GridLength((double)suspeitos / confirmados, GridUnitType.Star); }
        public GridLength DeathsWidht { get => new GridLength((double)obitos / confirmados, GridUnitType.Star); }


        #region String Spacings
        public string ConfirmadosStringSpacing  => confirmados.TransformNumberToSpacing();
        public string SuspeitosStringSpacing  => suspeitos.TransformNumberToSpacing();
        public string RecuperadosStringSpacing  => recuperados.TransformNumberToSpacing();
        public string ObitosStringSpacing  => obitos.TransformNumberToSpacing();
        #endregion

        public class ConfirmadoGenero
        {
            public string genero { get; set; }
            public int confirmados { get; set; }
        }

        public ObservableCollection<ConfirmadoGenero> ConfirmadosGenero => new ObservableCollection<ConfirmadoGenero>()
        {
            new ConfirmadoGenero
            {
                genero = "Masculino",
                confirmados = confirmados_m
            },
            new ConfirmadoGenero
            {
                genero = "Feminino",
                confirmados = confirmados_f
            }
        };

        public class ConfirmadosIdade
        {
            public string idade { get; set; }
            public int confirmados { get; set; }
        }

        public class ObitosIdade
        {
            public string idade { get; set; }
            public int obitos { get; set; }
        }

        public ObservableCollection<ConfirmadosIdade> ConfirmadosFaixaEtaria => new ObservableCollection<ConfirmadosIdade>()
        {
            new ConfirmadosIdade
            {
                idade = "0-9",
                confirmados = confirmados_0_9_total
            },
            new ConfirmadosIdade
            {
                idade = "10-19",
                confirmados = confirmados_10_19_total
            },
            new ConfirmadosIdade
            {
                idade = "20-29",
                confirmados = confirmados_20_29_total
            },
            new ConfirmadosIdade
            {
                idade = "30-39",
                confirmados = confirmados_30_39_total
            },
            new ConfirmadosIdade
            {
                idade = "40-49",
                confirmados = confirmados_40_49_total
            },
            new ConfirmadosIdade
            {
                idade = "50-59",
                confirmados = confirmados_50_59_total
            },
            new ConfirmadosIdade
            {
                idade = "60-69",
                confirmados = confirmados_60_69_total
            },
            new ConfirmadosIdade
            {
                idade = "70-79",
                confirmados = confirmados_70_79_total
            },
            new ConfirmadosIdade
            {
                idade = "80+",
                confirmados = confirmados_80_plus_total
            },
        };

        public ObservableCollection<ObitosIdade> ObitosFaixaEtaria => new ObservableCollection<ObitosIdade>()
        {
            new ObitosIdade
            {
                idade = "0-9",
                obitos = obitos_0_9_total
            },
            new ObitosIdade
            {
                idade = "10-19",
                obitos = obitos_10_19_total
            },
            new ObitosIdade
            {
                idade = "20-29",
                obitos = obitos_20_29_total
            },
            new ObitosIdade
            {
                idade = "30-39",
                obitos = obitos_30_39_total
            },
            new ObitosIdade
            {
                idade = "40-49",
                obitos = obitos_40_49_total
            },
            new ObitosIdade
            {
                idade = "50-59",
                obitos = obitos_50_59_total
            },
            new ObitosIdade
            {
                idade = "60-69",
                obitos = obitos_60_69_total
            },
            new ObitosIdade
            {
                idade = "70-79",
                obitos = obitos_70_79_total
            },
            new ObitosIdade
            {
                idade = "80+",
                obitos = obitos_80_plus_total
            },
        };

        public class Sintoma
        {
            public string sintoma { get; set; }
            public double percentagem { get; set; }
        }

        public ObservableCollection<Sintoma> Sintomas => new ObservableCollection<Sintoma>()
        {
            new Sintoma
            {
                sintoma = "Tosse",
                percentagem = sintomas_tosse_per
            },
            new Sintoma
            {
                sintoma = "Febre",
                percentagem = sintomas_febre_per
            },
            new Sintoma
            {
                sintoma = "Dificuldade Respiratória",
                percentagem = sintomas_dificuldade_respiratoria_per
            },
            new Sintoma
            {
                sintoma = "Cefaleia",
                percentagem = sintomas_cefaleia_per
            },
            new Sintoma
            {
                sintoma = "Dores Musculares",
                percentagem = sintomas_dores_musculares_per
            },
            new Sintoma
            {
                sintoma = "Fraqueza Generalizada",
                percentagem = sintomas_fraqueza_generalizada_per
            },
        };

        public class Regiao
        {
            public string regiao { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int confirmados { get; set; }
            public int recuperados { get; set; }
            public int obitos { get; set; }
            public string CCDR { get; set; }
            public string name { get; set; }
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
                    obitos = obitos_arsnorte,
                    name = "Norte"

                },
                new Regiao
                {
                    regiao = "Centro",
                    latitude = 41.45756,
                    longitude = -7.67865,
                    confirmados = confirmados_arscentro,
                    recuperados = recuperados_arscentro,
                    obitos = obitos_arscentro,
                    name = "Centro"

                },
                new Regiao
                {
                    regiao = "Lisboa e Vale do Tejo",
                    latitude = 39.16054,
                    longitude = -8.74521,
                    confirmados = confirmados_arslvt,
                    recuperados = recuperados_arslvt,
                    obitos = obitos_arslvt,
                    name = "RLVT"

                },
                new Regiao
                {
                    regiao = "Alentejo",
                    latitude = 38.39168,
                    longitude = -7.92234,
                    confirmados = confirmados_arsalentejo,
                    recuperados = recuperados_arsalentejo,
                    obitos = obitos_arsalentejo,
                    name = "Alentejo"

                },
                new Regiao
                {
                    regiao = "Algarve",
                    latitude = 37.24368,
                    longitude = -8.13171,
                    confirmados = confirmados_arsalgarve,
                    recuperados = recuperados_arsalgarve,
                    obitos = obitos_arsalgarve,
                    name = "Algarve"

                },
                new Regiao
                {
                    regiao = "Açores",
                    latitude = 38.58323,
                    longitude = -28.196631,
                    confirmados = confirmados_acores,
                    recuperados = recuperados_acores,
                    obitos = obitos_acores,
                    name = "Acores"

                },
                new Regiao
                {
                    regiao = "Madeira",
                    latitude = 32.75078,
                    longitude = -16.95118,
                    confirmados = confirmados_madeira,
                    recuperados = recuperados_madeira,
                    obitos = obitos_madeira,
                    name = "Madeira"

                }
        };
    }
}
