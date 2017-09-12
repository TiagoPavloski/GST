using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
  public class VacinaViewModel
  {
    public int VacinaId { get; set; }

    [Required(ErrorMessage = "Prencher campo Funcionario")]
    public virtual Funcionario Funcionario { get; set; }

    [Required(ErrorMessage = "Prencher campo TipoVacina")]
    public virtual TipoVacina TipoVacina { get; set; }

    [Required(ErrorMessage = "Prencher campo Data")]
    [MaxLength(150, ErrorMessage = "Máximo de 10")]
    public string Data { get; set; }

    [Required(ErrorMessage = "Prencher campo Status")]
    public int Status { get; set; }

    [ScaffoldColumn(false)]
    public bool Delete { get; set; }
  }
}
