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
    public class AgenteBiologicoViewModel
    {
        public int AgenteBiologicoId { get; set; }

        [DisplayName("Agente Biológico")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Frequência")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Frequência")]
        public string Frequencia { get; set; }

        [Required(ErrorMessage = "Prencher campo Classificação Efeito")]
        public int ClassificacaoEfeitoId { get; set; }

        [ForeignKey("ClassificacaoEfeitoId")]
        public virtual ClassificacaoEfeitoViewModel ClassificacaoEfeito { get; set; }

        [Required(ErrorMessage = "Prencher campo Tempo Exposição")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Tempo Exposição")]
        public string TempoExposicao { get; set; }

        [Required(ErrorMessage = "Prencher campo Fonte geradora")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string FonteGeradora { get; set; }

        [Required(ErrorMessage = "Prencher campo Efeito")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Efeito")]
        public string Efeito { get; set; }

        [Required(ErrorMessage = "Prencher campo Orientação")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        [Required(ErrorMessage = "Prencher campo Medidas Propostas")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Medidas Propostas")]
        public string MedidasPropostas { get; set; }

        [Required(ErrorMessage = "Prencher campo Fundamentação")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Técnica Utilizada")]
        public string Tecnica { get; set; }

        [Required(ErrorMessage = "Prencher campo Fundamentação")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fundamentação Legal")]
        public string FundamentacaoLegal { get; set; }

        public bool Delete { get; set; }
    }
}
