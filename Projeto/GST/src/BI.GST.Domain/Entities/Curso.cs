using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class Curso
  {
    public int CursoId { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual TipoCurso TipoCurso { get; set; }

    public string Data { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
