using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class TelefoneViewModel
	{
		public int TelefoneId { get; set; }

		[DisplayName("Número")]
		public string Numero { get; set; }

		public bool Delete { get; set; }

		public int? UsuarioId { get; set; }
		[ForeignKey("UsuarioId")]
		public virtual UsuarioViewModel Usuario { get; set; }

		public int? EmpresaId { get; set; }
		[ForeignKey("EmpresaId")]
		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
