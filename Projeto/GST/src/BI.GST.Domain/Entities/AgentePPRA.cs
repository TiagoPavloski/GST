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

    public virtual AgenteAmbiental AgenteAmbiental { get; set; }

    //public virtual PropagacaoAgente PropagacaoAgente { get; set; }  Não tem tabela disso ?????????????

    public bool Delete { get; set; }
  }
}
