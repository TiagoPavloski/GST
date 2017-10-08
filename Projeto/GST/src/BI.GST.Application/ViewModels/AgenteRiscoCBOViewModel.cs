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
    public class AgenteRiscoCBOViewModel
    {
       
        public int AgenteRiscoCBOId { get; set; }

        [DisplayName("Agente Risco CBO")]
        [Required(ErrorMessage = "Prencher o nome do Agente Risco")]
        [MaxLength(45, ErrorMessage = "Máximo de 45 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }

        public string StatusNome { get; set; }

        public bool Delete { get; set; }
    }
}
