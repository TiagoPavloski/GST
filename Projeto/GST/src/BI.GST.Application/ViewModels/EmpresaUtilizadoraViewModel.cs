using System.Collections.Generic;

namespace BI.GST.Application.ViewModels
{
    public class EmpresaUtilizadoraViewModel
    {
        public EmpresaUtilizadoraViewModel()
        {
            //Telefones = new List<TelefoneViewModel>();
        }
        public int EmpresaUtilizadoraId { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public int EnderecoId { get; set; }

		public int UFId { get; set; }

		public string Email { get; set; }

        public string Senha { get; set; }

        public bool Delete { get; set; }

        public virtual EnderecoViewModel Endereco { get; set; }
		public virtual UFViewModel UF { get; set; }
		public virtual List<TelefoneViewModel> Telefones { get; set; }
    }
}
