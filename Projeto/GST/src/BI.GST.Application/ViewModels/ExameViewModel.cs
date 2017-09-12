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
    public class ExameViewModel
    {
        public int ExameId { get; set; }

        [Required]
        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }

        [Required]
        [DisplayName("Tipo Vacina")]
        public int TipoExameId { get; set; }

        [Required(ErrorMessage = "Prencher campo Data")]
        [MaxLength(150, ErrorMessage = "Máximo de 10")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Prencher campo Status")]
        public int Status { get; set; }
        public string StatusNome { get; set; }

        public bool Delete { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual TipoExame TipoExame { get; set; }
    }
}
