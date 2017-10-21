
using System.Collections.Generic;

namespace BI.GST.Domain.Entities
{
    public class RiscoCBO
    {
        public int RiscoCBOId { get; set; }

        public string Nome { get; set; }

        public int AgenteRiscoCBOId { get; set; }

        public virtual AgenteRiscoCBO AgenteRiscoCBO { get; set; }

        public int AgenteCausadorCBOId { get; set; }

        public virtual AgenteCausadorCBO AgenteCausadorCBO { get; set; }

        public int FonteRiscoCBOId { get; set; }

        public virtual FonteRiscoCBO FonteRiscoCBO { get; set; }

        public string Consequencias { get; set; }

        public string MedidasPreventivas { get; set; }

        public virtual ICollection<CBO> CBOs { get; set; }

        public bool Delete { get; set; }
    }
}
