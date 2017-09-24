using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
    public class MeioPropagacaoViewModel
    {
        public int MeioPropagacaoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Meio")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Meio")]
        public string Meio { get; set; }

        public bool Delete { get; set; }
    }
}
