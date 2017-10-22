using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class TipoCursoViewModel
	{
		public int TipoCursoId { get; set; }

		[Required(ErrorMessage = "Prencher campo Nome")]
		[MaxLength(150, ErrorMessage = "Máximo de 150")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Prencher campo Meses de Validade")]
		[DisplayName("Meses de Validade")]
		public int MesesValidade { get; set; }

		[ScaffoldColumn(false)]
		public bool Delete { get; set; }
	}
}
