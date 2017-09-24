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
    public class AgentePPRAViewModel
    {
        public int AgentePPRAId { get; set; }

        [Required]
        [DisplayName("Agente Ambiental")]
        public int AgenteAmbientalId { get; set; }

        [Required]
        [DisplayName("Meio de Propagação")]
        public int MeioPropagacaoId { get; set; }

        public virtual AgenteAmbiental AgenteAmbiental { get; set; }

        public virtual MeioPropagacao MeioPropagacao { get; set; }

    }
}
