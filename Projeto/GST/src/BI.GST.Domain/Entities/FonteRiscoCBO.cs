using System.Collections.Generic;

namespace BI.GST.Domain.Entities
{
  public class FonteRiscoCBO
  {
        public int FonteRiscoCBOId { get; set; }

        public string Nome { get; set; }

        public int Status { get; set; }

        public bool Delete { get; set; }

        public virtual ICollection<RiscoFuncionario> RiscosFuncionario { get; set; }

      }
}