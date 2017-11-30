using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AgenteQuimicoViewModel
    {
       
        public int AgenteQuimicoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [DisplayName("Nome agente")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Limite Tolerância")]
        public string LimiteTolerancia { get; set; }

        public virtual ICollection<MeioPropagacao> MeiosPropagacao { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Frequência")]
        public string Frequencia { get; set; }

        [Required(ErrorMessage = "Prencher campo Classificação Efeito")]
        public int ClassificacaoEfeitoId { get; set; }

        [ForeignKey("ClassificacaoEfeitoId")]
        public virtual ClassificacaoEfeitoViewModel ClassificacaoEfeito { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Tempo Exposição")]
        public string TempoExposicao { get; set; }

        public virtual ICollection<MedicaoAgente> MedicoesAgente { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Método")]
        public string Metodo { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string Fonte { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("EPI")]
        public string EPI { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("EPC")]
        public string EPC { get; set; }

        [DisplayName("Caracteristicas")]
        public string Caracteristicas { get; set; }

        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        [DisplayName("Medidas Propostas")]
        public string MedidasPropostas { get; set; }

        [DisplayName("Medidas Existentes")]
        public string MedidasExistentes { get; set; }

        [DisplayName("Análise Qualitativa")]
        public string AnaliseQualitativa { get; set; }

        [DisplayName("Efeitos Potências")]
        public string EfeitosPotenciais { get; set; }

        [DisplayName("Técnica Utilizada")]
        public string Tecnica { get; set; }

        [DisplayName("Fundamentação Legal")]
        public string FundamentacaoLegal { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public bool Delete { get; set; }
    }
}
