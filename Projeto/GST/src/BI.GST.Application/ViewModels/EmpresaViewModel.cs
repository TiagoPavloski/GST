using System.Collections.Generic;

namespace BI.GST.Application.ViewModels
{
    public class EmpresaViewModel
    {
		public int EmpresaId { get; set; }

		public string NomeFantasia { get; set; }

		public string RazaoSocial { get; set; }

		public string CNPJ { get; set; }

		public string Email { get; set; }

		public int CnaeId { get; set; }

		public string Logo { get; set; }

		public bool Delete { get; set; }


		public virtual CnaeViewModel CnaePrincipal { get; set; }
		public virtual List<TelefoneViewModel> Telefones { get; set; }
		public virtual List<EnderecoViewModel> Enderecos { get; set; }
		public virtual List<FuncionarioViewModel> Responsaveis { get; set; }
		public virtual List<CnaeViewModel> CnaeSecundarios { get; set; }
		public virtual List<SetorViewModel> Setores { get; set; }
	}
}