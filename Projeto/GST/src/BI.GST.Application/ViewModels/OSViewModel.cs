using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class OSViewModel
	{
		public int OsId { get; set; }

		public int FuncionarioId { get; set; }

		[Required(ErrorMessage = "Prencher campo Data Elaboração")]
		[MaxLength(10, ErrorMessage = "Máximo de 10")]
		[DisplayName("Data Elaboração")]
		public string DataElaboracao { get; set; }

		[Required(ErrorMessage = "Prencher campo Data Elaboração")]
		[MaxLength(10, ErrorMessage = "Máximo de 10")]
		[DisplayName("Data Elaboração")]
		public string DataRevisao { get; set; }

		[Required(ErrorMessage = "Prencher campo EPI Recomendado")]
		[MaxLength(500, ErrorMessage = "Máximo de 500")]
		[DisplayName("EPI Recomendados")]
		public string EPIRecomendado { get; set; }

		[Required(ErrorMessage = "Prencher campo Recomendações")]
		[MaxLength(500, ErrorMessage = "Máximo de 500")]
		[DisplayName("Recomendações")]
		public string Recomentacoes { get; set; }

		public bool Delete { get; set; }

		public virtual FuncionarioViewModel Funcionario { get; set; }
	}
}
