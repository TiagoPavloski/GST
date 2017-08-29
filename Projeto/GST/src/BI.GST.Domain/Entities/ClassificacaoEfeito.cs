using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class ClassificacaoEfeito
  {
    public int ClassificacaoEfeitoId { get; set; }

    public string Classificacao { get; set; }

    public bool Delete { get; set; }
  }
}
