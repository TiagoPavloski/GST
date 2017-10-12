using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BI.GST.Application.ViewModels
{
	public class ColaboradorViewModel : PessoaViewModel
    {
		public int ColaboradorId { get; set; }

        [Required(ErrorMessage = "Selecionar Empresa")]
        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }

		public bool Delete { get; set; }

		public virtual EmpresaViewModel Empresa { get; set; }
	}
}
