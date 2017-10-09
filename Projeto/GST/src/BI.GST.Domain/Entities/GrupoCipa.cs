using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class GrupoCipa
    {
        public int GrupoCipaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Cnae> ListaCnae { get; set; }
    }
}
