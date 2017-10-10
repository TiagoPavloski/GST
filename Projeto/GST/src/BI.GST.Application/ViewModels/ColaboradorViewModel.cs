using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class ColaboradorViewModel
	{
		public int ColaboradorId { get; set; }

		public int EmpresaId { get; set; }

		public bool Delete { get; set; }

		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
