using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class AgenteAmbientalViewModel
    {
        public int AgenteAmbientalId { get; set; }

        [Required(ErrorMessage = "Prencher campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100")]
        public string Nome { get; set; }
    }
}
