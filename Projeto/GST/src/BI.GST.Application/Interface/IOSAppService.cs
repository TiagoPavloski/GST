using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface IOSAppService : IDisposable
	{
		IEnumerable<OSViewModel> ObterTodos();

		OSViewModel ObterPorId(int id);

		bool Adicionar(OSViewModel oSViewModel);

		bool Atualizar(OSViewModel oSViewModel);

		bool Excluir(int id);

		IEnumerable<OSViewModel> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);
	}
}
