using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class AgenteBiologico
    {
        public int AgenteBiologicoId { get; set; }

        public string Nome { get; set; }

        public string FonteGeradora { get; set; }

        public string Orientacao { get; set; }

        public bool Delete { get; set; }

        public virtual ICollection<Setor> Setores { get; set; }
    }
}
