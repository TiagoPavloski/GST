using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AgenteQuimicoViewModel
    {
       
        public int AgenteQuimicoId { get; set; }

        [DisplayName("Agente Químico")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Limite Tolerância")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Limite Tolerância")]
        public string LimiteTolerancia { get; set; }

        public virtual ICollection<MeioPropagacao> MeiosPropagacao { get; set; }

        [Required(ErrorMessage = "Prencher campo Frequência")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Frequência")]
        public string Frequencia { get; set; }

        public virtual ClassificacaoEfeitoViewModel ClassificacaoEfeito { get; set; }

        [Required(ErrorMessage = "Prencher campo Tempo Exposição")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Tempo Exposição")]
        public string TempoExposicao { get; set; }

        public virtual ICollection<MedicaoAgente> MedicoesAgente { get; set; }

        [Required(ErrorMessage = "Prencher campo Técnica")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Técnica")]
        public string Tecnica { get; set; }

        [Required(ErrorMessage = "Prencher campo Método")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Método")]
        public string Metodo { get; set; }

        [Required(ErrorMessage = "Prencher campo Fonte geradora")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string Fonte { get; set; }

        [Required(ErrorMessage = "Prencher campo EPI")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("EPI")]
        public string EPI { get; set; }

        [Required(ErrorMessage = "Prencher campo EPC")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("EPC")]
        public string EPC { get; set; }

        [Required(ErrorMessage = "Prencher campo Caracteristicas")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Caracteristicas")]
        public string Caracteristicas { get; set; }

        [Required(ErrorMessage = "Prencher campo Orientação")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        [Required(ErrorMessage = "Prencher campo Medidas Propostas")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Medidas Propostas")]
        public string MedidasPropostas { get; set; }

        [Required(ErrorMessage = "Prencher campo Medidas Existentes")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Medidas Existentes")]
        public string MedidasExistentes { get; set; }

        [Required(ErrorMessage = "Prencher campo Análise Qualitativa")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Análise Qualitativa")]
        public string AnaliseQualitativa { get; set; }

        [Required(ErrorMessage = "Prencher campo Efeitos Potências")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Efeitos Potências")]
        public string EfeitosPotenciais { get; set; }

        [Required(ErrorMessage = "Prencher campo Fundamentação")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Fundamentação")]
        public string Fundamentacao { get; set; }

        [Required(ErrorMessage = "Prencher campo Observação")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public bool Delete { get; set; }
    }
}
