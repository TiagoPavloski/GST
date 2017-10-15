using BI.GST.Domain.Entities;
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
	public class FuncionarioViewModel : PessoaViewModel
	{
		public int FuncionarioId { get; set; }

		public int Status { get; set; }

        [DisplayName("Status")]
        public string StatusNome { get; set; }

        ICollection<ExameViewModel> Exames { get; set; }

		ICollection<VacinaViewModel> Vacinas { get; set; }

		ICollection<CursoViewModel> Cursos { get; set; }

        [DisplayName("PIS")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string PIS { get; set; }

        [DisplayName("CLT")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string CLT { get; set; }

        [DisplayName("Série")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        public string Serie { get; set; }

		public virtual UFViewModel UF { get; set; }

		public bool Delete { get; set; }

		//ID Responsavel pela empresa
		public int? EmpresaId { get; set; }
		[ForeignKey("EmpresaId")]
		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
