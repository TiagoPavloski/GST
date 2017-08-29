using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class AgenteAmbiental
  {
    public int AgenteAmbientalId { get; set; }

    public string Nome { get; set; }

    public int Status { get; set; }

    public bool Delete { get; set; }
  }
}
