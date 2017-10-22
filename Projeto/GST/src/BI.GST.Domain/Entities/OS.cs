using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Entities
{
	public class OS
	{
		public int OsId { get; set; }

		public int FuncionarioId { get; set; }

		public string DataElaboracao { get; set; }

		public string DataRevisao { get; set; }

		public string EPIRecomendado { get; set; }

		public string Recomentacoes { get; set; }

		public bool Delete { get; set; }

		public virtual Funcionario Funcionario { get; set; }
	}
}
