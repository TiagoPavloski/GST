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
	public class EnderecoViewModel
	{
		public int EnderecoId { get; set; }

		[Required]
		[DisplayName("Logradouro")]
		[MaxLength(100, ErrorMessage = "Máximo de 100")]
		public string Logradouro { get; set; }

		[Required]
		[MaxLength(15, ErrorMessage = "Máximo de 115")]
		public string Numero { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Máximo de 50")]
		public string Bairro { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Máximo de 50")]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "Selecione UF")]
		public int UFId { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Máximo de 50")]
		public string Pais { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Máximo de 8")]
		public string CEP { get; set; }

		[Required]
		[MaxLength(400, ErrorMessage = "Máximo de 400")]
		public string Complemento { get; set; }

		public bool Delete { get; set; }


		public virtual UFViewModel UF { get; set; }

		public int EmpresaId { get; set; }
		[ForeignKey("EmpresaId")]
		public virtual EmpresaViewModel EmpresaViewModel { get; set; }
	}
}
