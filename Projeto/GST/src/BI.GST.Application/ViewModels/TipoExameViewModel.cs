using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BI.GST.Application.ViewModels
{
	public class TipoExameViewModel
	{
		public int TipoExameId { get; set; }

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
