using System.Collections.Generic;

namespace BI.GST.Application.ViewModels
{
    public class EmpresaUtilizadoraViewModel
    {
        public EmpresaUtilizadoraViewModel()
        {
            TelefonesViewModel = new List<TelefoneViewModel>();
        }
        public int EmpresaUtilizadoraId { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public int EnderecoId { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Delete { get; set; }

        public virtual EnderecoViewModel EnderecoViewModel { get; set; }
        public virtual ICollection<TelefoneViewModel> TelefonesViewModel { get; set; }
    }
}
