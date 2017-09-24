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
    public class ClassificacaoEfeitoViewModel
    {
        public int ClassificacaoEfeitoId { get; set; }

        [Required(ErrorMessage = "Prencher campo Classificação")]
        [MaxLength(150, ErrorMessage = "Máximo de 150")]
        [DisplayName("Classificação")]
        public string Classificacao { get; set; }

        public bool Delete { get; set; }
    }
}