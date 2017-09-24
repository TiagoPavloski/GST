using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class EUEnderecoTelefoneViewModel
	{
		public EUEnderecoTelefoneViewModel()
		{

		}
		public EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel;

		public IEnumerable<EmpresaUtilizadoraViewModel> empresaUtilizadoraViewModels;

		public EnderecoViewModel enderecoViewModel = new EnderecoViewModel();

		public IEnumerable<TelefoneViewModel> telefoneViewModel;

		public UFViewModel uFViewModel = new UFViewModel();
	}
}
