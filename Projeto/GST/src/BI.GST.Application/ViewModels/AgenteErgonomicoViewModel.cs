using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AgenteErgonomicoViewModel
    {

        public int AgenteErgonomicoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [DisplayName("Nome agente")]
        public string Nome { get; set; }

        [DisplayName("Fonte geradora")]
        public string FonteGeradora { get; set; }

        [DisplayName("Orientação")]
        public string Orientacao { get; set; }

        public bool Delete { get; set; }
    }
}
