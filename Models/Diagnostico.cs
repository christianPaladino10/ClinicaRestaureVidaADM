using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProfissional { get; set; }

        [DisplayName("Respiratório")]
        [DataType(DataType.MultilineText)]
        public string Respiratorio { get; set; }

        [DataType(DataType.MultilineText)]
        public string Emocional { get; set; }

        [DisplayName("Ortopédico")]
        [DataType(DataType.MultilineText)]
        public string Ortopedico { get; set; }

        [DisplayName("Digestório")]
        [DataType(DataType.MultilineText)]
        public string Digestorio { get; set; }

        [DisplayName("Menstrual/Reprodutor")]
        [DataType(DataType.MultilineText)]
        public string MestrualReprodutor { get; set; }

        [DataType(DataType.MultilineText)]
        public string Cardiovascular { get; set; }

        [DisplayName("Observações")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        [DataType(DataType.MultilineText)]
        public string Tratamentos { get; set; }

        [DisplayName("Horário do Café")]
        public string HorarioCafe { get; set; }

        [DisplayName("Horário do Almoço")]
        public string HorarioAlmoco { get; set; }

        [DisplayName("Horário do Café da Tarde")]
        public string HorarioCafeTarde { get; set; }

        [DisplayName("Horário do Jantar")]
        public string HorarioJantar { get; set; }
        public bool Tatoo { get; set; }

        [DisplayName("Quantidade de Tatoo")]
        public int? QtdTatoo { get; set; }

        [DisplayName("Tempo de Tatoo")]
        public string QntTempoTatoo { get; set; }

        [DisplayName("Região de Tatoo")]
        public string RegiaoTatoo { get; set; }
        public bool Esporte { get; set; }

        [DisplayName("Qual Esporte")]
        public string QualEsporte { get; set; }

        [DisplayName("Profissional do Esporte")]
        public bool ProfissionalEsporte { get; set; }

        [DisplayName("Frequencia da prática de Esporte")]
        public string FrequenciaEsporte { get; set; }
        public bool Medicamento { get; set; }

        [DisplayName("Quantidade de Medicamento")]
        public int? QtdMedicamento { get; set; }

        [DisplayName("Tempo de Medicamento")]
        public string QntTempoMedicamento { get; set; }

        [DisplayName("Nome do Remédio")]
        public string NomeRemedio { get; set; }

        [DisplayName("Objetivo do Remédio")]
        public string ObjetivoRemedio { get; set; }
        public bool Cirurgia { get; set; }

        [DisplayName("Quantidade de Cirurgia")]
        public int? QtdCirurgia { get; set; }

        [DisplayName("Tempo de Cirurgia")]
        public string QntTempoCirurgia { get; set; }

        [DisplayName("Região da Cirurgia")]
        public string RegiaoCirurgia { get; set; }
        public bool Transplantado { get; set; }

        [DisplayName("Quantidade de Tempo Transplantado")]
        public string QntTempoTransplantado { get; set; }

        [DisplayName("Orgão Transplantado")]
        public string OrgaoTransplantado { get; set; }

        [DisplayName("Alérgico")]
        public bool Alergico { get; set; }

        [DisplayName("Item Alérgico")]
        public string ItemAlergico { get; set; }

        [DisplayName("Observações Alérgicas")]
        public string ObservacoesAlergicas { get; set; }

        [DisplayName("Bebida Alcoolica")]
        public bool BebidaAlcoolica { get; set; }

        [DisplayName("Nome da Bebida")]
        public string NomeBebida { get; set; }

        [DisplayName("Quanto Tempo de Bebida")]
        public string QntTempoBebida { get; set; }

        [DisplayName("Frequencia Bebida")]
        public string FrequenciaBebida { get; set; }

        [DisplayName("Marca-Passo")]
        public bool MarcaPasso { get; set; }

        [DisplayName("Quanto Tempo de Marca-Passo")]
        public string QntTempoMarcaPasso { get; set; }

        [DisplayName("Observação Marca-Passo")]
        public string ObservacaoMarcaPasso { get; set; }

        [DisplayName("Prótese/Silicone")]
        public bool ProteseSilicone { get; set; }

        [DisplayName("Quantidade de Prótese")]
        public int? QtdProtese { get; set; }

        [DisplayName("Quanto Tempo de Prótese")]
        public string QntTempoProtese { get; set; }

        [DisplayName("Região do Prótese")]
        public string RegiaoProtese { get; set; }

        [DisplayName("Animal de Estimação")]
        public bool AnimalEstimacao { get; set; }

        [DisplayName("Quantidade de Animal de Estimação")]
        public int? QtdAnimalEstimacao { get; set; }

        [DisplayName("Raça do Animal de Estimação")]
        public string Raca { get; set; }

        [DisplayName("Nome do Animal de Estimação")]
        public string NomeAnimal { get; set; }

        [DisplayName("Idade do Animal de Estimação")]
        public string IdadeAnimal { get; set; }

        [DisplayName("Histórico Doença Familiar")]
        [DataType(DataType.MultilineText)]
        public string HistoricoDoencaFamiliar { get; set; }

        [DisplayName("Observação Geral")]
        [DataType(DataType.MultilineText)]
        public string ObservacaoGeral { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}