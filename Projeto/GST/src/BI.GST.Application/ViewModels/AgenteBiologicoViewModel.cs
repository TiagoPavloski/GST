using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AgenteBiologicoViewModel
    {
        public int AgenteBiologicoId { get; set; }

        [DisplayName("Agente Físico")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Fonte geradora")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [DisplayName("Fonte geradora")]
        public string FonteGeradora { get; set; }

        [Required(ErrorMessage = "Prencher campo Orientação")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        public bool Delete { get; set; }
    }
}
