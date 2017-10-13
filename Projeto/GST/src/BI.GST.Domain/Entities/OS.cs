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

		public int FuncionarioEmpresaId { get; set; }

		public int ColaboradorId { get; set; }

		public string DataElaboracao { get; set; }

		public string DataRevisao { get; set; }

		public string EPIRecomendado { get; set; }

		public string Recomentacoes { get; set; }

		public int Status { get; set; }

		public bool Delete { get; set; }

		public virtual FuncionarioEmpresa FuncionarioEmpresa { get; set; }

		public virtual Colaborador Colaborador { get; set; }
	}
}
