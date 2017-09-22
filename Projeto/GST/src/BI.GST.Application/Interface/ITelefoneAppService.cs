using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface ITelefoneAppService : IDisposable
	{
		IEnumerable<TelefoneViewModel> ObterTodos();

		TelefoneViewModel ObterPorId(int id);

		bool Adicionar(TelefoneViewModel telefoneViewModel);

		bool Atualizar(TelefoneViewModel telefoneViewModel);

		bool Excluir(int id);
	}
}
