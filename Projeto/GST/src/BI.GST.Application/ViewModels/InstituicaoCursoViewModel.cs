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
    public class InstituicaoCursoViewModel
    {
       
        public int InstituicaoCursoId { get; set; }

        [DisplayName("Nome da instituição")]
        [Required(ErrorMessage = "Prencher o nome da instituição")]
        [MaxLength(55, ErrorMessage = "Máximo de 55 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Minha Empresa")]
        public bool InstituicaoCliente { get; set; }

        public bool Delete { get; set; }
    }
}
