using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class TelefoneViewModel
	{
		public int TelefoneId { get; set; }

		public string Numero { get; set; }

		public bool Delete { get; set; }

		public int EmpresaUtilizadoraId { get; set; }
		[ForeignKey("EmpresaUtilizadoraId")]
		public virtual EmpresaUtilizadoraViewModel EmpresaUtilizadora { get; set; }
	}
}
