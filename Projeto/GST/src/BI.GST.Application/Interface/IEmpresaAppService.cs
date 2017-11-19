using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface IEmpresaAppService : IDisposable
	{
		IEnumerable<EmpresaViewModel> ObterTodos();

		EmpresaViewModel ObterPorId(int id);

		bool Adicionar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId/*, int[] funcionarioId*/);

		bool Atualizar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId/*, int[] funcionarioId*/);

		bool Excluir(int id);

		IEnumerable<EmpresaViewModel> ObterGrid(int page, string pesquisa, int usuarioId);

		int ObterTotalRegistros(string pesquisa, int usuarioId);
	}
}
