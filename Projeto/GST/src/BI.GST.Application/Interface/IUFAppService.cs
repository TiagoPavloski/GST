using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface IUFAppService : IDisposable
	{
		IEnumerable<UFViewModel> ObterTodos();

		UFViewModel ObterPorId(int id);

		bool Adicionar(UFViewModel uFViewModel);

		bool Atualizar(UFViewModel uFViewModel);

		bool Excluir(int id);
	}
}
