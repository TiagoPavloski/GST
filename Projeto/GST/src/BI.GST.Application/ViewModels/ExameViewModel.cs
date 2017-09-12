using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
  public class ExameViewModel
  {
    public int ExameId { get; set; }

    [Required(ErrorMessage = "Prencher campo Funcionario")]
    public virtual Funcionario Funcionario { get; set; }

    [Required(ErrorMessage = "Prencher campo TipoExame")]
    public virtual TipoExame TipoExame { get; set; }

    [Required(ErrorMessage = "Prencher campo Data")]
    [MaxLength(150, ErrorMessage = "Máximo de 10")]
    public string Data { get; set; }

    [Required(ErrorMessage = "Prencher campo Status")]
    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
