using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class AgenteErgonomico
  {
    public int AgenteErgonomicoId { get; set; }

    public string Nome { get; set; }

    public string FonteErgonomica { get; set; }

    public string Orientacao { get; set; }

    public bool Delete { get; set; }
  }
}
