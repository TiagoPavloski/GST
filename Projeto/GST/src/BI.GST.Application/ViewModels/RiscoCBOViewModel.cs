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
    public class RiscoCBOViewModel
    {
        public int RiscoCBOId { get; set; }

        [Required]
        [DisplayName("Agente fonte do risco da Função")]
        public int FonteRiscoCBOId { get; set; }

        [Required]
        [DisplayName("Agente causador do risco da Função")]
        public int AgenteCausadorCBOId { get; set; }

        [Required]
        [DisplayName("Agente de risco da Função")]
        public int AgenteRiscoCBOId { get; set; }

        [Required(ErrorMessage = "Prencher as consequências")]
        [DisplayName("Consequências")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        public string Consequencias { get; set; }

        [Required(ErrorMessage = "Prencher as medidas preventivas")]
        [DisplayName("Medidas Preventivas")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        public string MedidasPreventivas { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }

        public string StatusNome { get; set; }

        public bool Delete { get; set; }


        public virtual FonteRiscoCBO FonteRiscoCBO { get; set; }
        public virtual AgenteCausadorCBO AgenteCausadorCBO { get; set; }
        public virtual AgenteRiscoCBO AgenteRiscoCBO { get; set; }

    }
}
