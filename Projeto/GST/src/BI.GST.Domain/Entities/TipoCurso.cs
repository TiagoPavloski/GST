using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class TipoCurso
  {
    public int TipoCursoId { get; set; }

    public string Nome { get; set; }

    public string Validade { get; set; }

    public bool Delete { get; set; }
  }
}
