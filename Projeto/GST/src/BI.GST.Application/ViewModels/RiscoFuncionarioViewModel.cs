using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class RiscoFuncionarioViewModel
    {
        public int RiscoFuncionarioId { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Consequências")]
        [MaxLength(150, ErrorMessage = "Máximo de 200")]
        [DisplayName("Consequências")]
        public string Consequencias { get; set; }

        [Required(ErrorMessage = "Prencher campo Medidas Prevêntivas")]
        [MaxLength(150, ErrorMessage = "Máximo de 200")]
        [DisplayName("Medidas Prevêntivas")]
        public string MedidasPreventivas { get; set; }

        public int AgenteRiscoCBOId { get; set; }

        public int AgenteCausadorCBOId { get; set; }

        public int FonteRiscoCBOId { get; set; }

        public virtual AgenteRiscoCBOViewModel AgenteRiscoCBO { get; set; }

        public virtual AgenteCausadorCBOViewModel AgenteCausadorCBO { get; set; }

        public virtual FonteRiscoCBOViewModel FonteRiscoCBO { get; set; }

        public bool Delete { get; set; }
    }
}

