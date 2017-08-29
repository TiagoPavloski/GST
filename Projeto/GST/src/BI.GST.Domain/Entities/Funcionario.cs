using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Funcionario : Pessoa
  {
    public int FuncionarioId { get; set; }

    public int Status { get; set; }

    public ICollection<Exame> Exames { get; set; }

    public ICollection<Vacina> Vacinas { get; set; }

    public ICollection<Curso> Cursos { get; set; }

    public string PIS { get; set; }

    public string CLT { get; set; }

    public string Serie { get; set; }

    public virtual  UF UF { get; set; }

    public bool Delete { get; set; }
  }
}
