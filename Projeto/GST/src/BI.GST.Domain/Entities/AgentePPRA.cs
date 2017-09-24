using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
  public class AgentePPRA
  {
    public int AgentePPRAId { get; set; }

    public int AgenteAmbientalId { get; set; }

    public int MeioPropagacaoId { get; set; }

    public virtual AgenteAmbiental AgenteAmbiental { get; set; }

    public virtual MeioPropagacao MeioPropagacao { get; set; }

    public bool Delete { get; set; }
  }
}
