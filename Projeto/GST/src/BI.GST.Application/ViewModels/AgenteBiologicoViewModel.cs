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

        [Required(ErrorMessage = "Prencher campo Nome")]
        [DisplayName("Nome Agente")]
        public string Nome { get; set; }

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

        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string FonteGeradora { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Efeito")]
        public string Efeito { get; set; }

        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        [DisplayName("Medidas Propostas")]
        public string MedidasPropostas { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Técnica Utilizada")]
        public string Tecnica { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fundamentação Legal")]
        public string FundamentacaoLegal { get; set; }

        public bool Delete { get; set; }
    }
}
