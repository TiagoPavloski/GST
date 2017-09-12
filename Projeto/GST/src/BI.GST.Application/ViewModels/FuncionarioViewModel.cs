using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
  public class FuncionarioViewModel : PessoaViewModel
  {
    public int FuncionarioId { get; set; }

    public int Status { get; set; }

    //public ICollection<ExameViewModel> Exames { get; set; }

    //public ICollection<VacinaViewModel> Vacinas { get; set; }

    //public ICollection<CursoViewModel> Cursos { get; set; }

    public string PIS { get; set; }

    public string CLT { get; set; }

    public string Serie { get; set; }

  //  public virtual UFViewModel UF { get; set; }

    public bool Delete { get; set; }
  }
}
