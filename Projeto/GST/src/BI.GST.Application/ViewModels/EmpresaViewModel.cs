using System.Collections.Generic;
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
			//CnaePrincipal = new CnaeViewModel();
		}
		public int EmpresaId { get; set; }

		public string NomeFantasia { get; set; }

		public string RazaoSocial { get; set; }

		public string CNPJ { get; set; }

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