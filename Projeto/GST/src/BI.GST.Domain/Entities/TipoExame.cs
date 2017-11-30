using System.Collections.Generic;

namespace BI.GST.Domain.Entities
{
	public class TipoExame
	{
		public int TipoExameId { get; set; }

		public string Nome { get; set; }

		public int MesesValidade { get; set; }

		public bool Delete { get; set; }

        public virtual ICollection<CBO> CBOs { get; set; }
    }
}
