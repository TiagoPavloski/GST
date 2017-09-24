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
    public class CronogramaDeAcoesViewModel
    {
        public int CronogramaDeAcoesId { get; set; }

        [Required]
        [DisplayName("PPRA")]
        public int PPRAId { get; set; }

        [Required(ErrorMessage = "Prencher campo Atividade")]
        [MaxLength(500, ErrorMessage = "Máximo de 500")]
        [DisplayName("Atividade")]
        public string Atividade { get; set; }

        public virtual PPRA PPRA { get; set; }
    }
}
