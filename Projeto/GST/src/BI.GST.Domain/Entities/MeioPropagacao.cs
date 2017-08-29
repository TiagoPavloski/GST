using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class MeioPropagacao
  {
    public int MeioPropagacaoId { get; set; }

    public string Meio { get; set; }

    public bool Delete { get; set; }
  }
}
