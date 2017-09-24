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
    public class AgenteAcidenteViewModel
    {
        public int AgenteAcidenteId { get; set; }

        [Required]
        [DisplayName("Agente Acidente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Frequência")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Frequência")]
        public string Frequencia { get; set; }

        public virtual ClassificacaoEfeitoViewModel ClassificacaoEfeito { get; set; }

        [Required(ErrorMessage = "Prencher campo Tempo Exposição")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        [DisplayName("Tempo Exposição")]
        public string TempoExposicao { get; set; }

        [Required(ErrorMessage = "Prencher campo Fonte geradora")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string Fonte { get; set; }

        [Required(ErrorMessage = "Prencher campo Efeito")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
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
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Fundamentação")]
        public string Fundamentacao { get; set; }


        public bool Delete { get; set; }
    }

 }
