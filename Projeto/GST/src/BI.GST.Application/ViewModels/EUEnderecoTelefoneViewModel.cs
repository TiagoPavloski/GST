using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.ViewModels
{
	public class EUEnderecoTelefoneViewModel
	{
		EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel = new EmpresaUtilizadoraViewModel();

		EnderecoViewModel enderecoViewModel = new EnderecoViewModel();

		List<TelefoneViewModel> telefoneViewModel = new List<TelefoneViewModel>();

		UFViewModel uFViewModel = new UFViewModel();
	}
}
