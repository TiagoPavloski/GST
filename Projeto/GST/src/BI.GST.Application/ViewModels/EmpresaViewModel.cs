using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.GST.Application.ViewModels
{
	public class EmpresaViewModel
	{
		public EmpresaViewModel()
		{
			Telefones = new List<TelefoneViewModel>();
			CnaeSecundarios = new List<CnaeViewModel>();
			Setores = new List<SetorViewModel>();
			Responsaveis = new List<FuncionarioViewModel>();
		}
		public int EmpresaId { get; set; }

		[Required]
		[DisplayName("Nome Fantasia")]
		[MaxLength(150, ErrorMessage = "Máximo de 150")]
		public string NomeFantasia { get; set; }

		[Required]
		[DisplayName("Razao Social")]
		[MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
		public string RazaoSocial { get; set; }

		[Required]
		[MaxLength(150, ErrorMessage = "Máximo de 20 caracteres")]
		public string CNPJ { get; set; }


		[Required]
		[MaxLength(150, ErrorMessage = "Máximo de 30 caracteres")]
		[RegularExpression(@"b[A-Z0-9._%-]+@[A-Z0-9.-]+.[A-Z]{2,4}b", ErrorMessage = "E-mail em formato inválido.")]
		public string Email { get; set; }

		public int CnaeId { get; set; }

		public int EnderecoId { get; set; }

		public int UFId { get; set; }

		public string Logo { get; set; }

		public bool Delete { get; set; }

		[ForeignKey("CnaeId")]
		public virtual CnaeViewModel CnaePrincipal { get; set; }
		public virtual EnderecoViewModel Endereco { get; set; }
		[ForeignKey("UFId")]
		public virtual UFViewModel UF { get; set; }
		public virtual List<TelefoneViewModel> Telefones { get; set; }
		public virtual List<CnaeViewModel> CnaeSecundarios { get; set; }
		public virtual List<SetorViewModel> Setores { get; set; }
		public virtual ICollection<FuncionarioViewModel> Responsaveis { get; set; }
	}
}