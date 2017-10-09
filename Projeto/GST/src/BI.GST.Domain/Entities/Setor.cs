using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
    public class Setor
    {
        public int SetorId { get; set; }

        public string Nome { get; set; }

        public virtual TipoSetor TipoSetor { get; set; }

        public string Descricao { get; set; }

        public int Status { get; set; }

        public virtual ICollection<AgenteQuimico> AgenteQuimicos { get; set; }

        public virtual ICollection<AgenteFisico> AgenteFisicos { get; set; }

        public virtual ICollection<AgenteAcidente> AgenteAcidentes { get; set; }

        public virtual ICollection<AgenteErgonomico> AgenteErgonomicos { get; set; }

        public virtual ICollection<AgenteBiologico> AgenteBiologicos { get; set; }

        public bool Delete { get; set; }

		public virtual ICollection<Empresa> Empresas { get; set; }
	}
}
