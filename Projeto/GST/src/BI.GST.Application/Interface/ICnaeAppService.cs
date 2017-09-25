using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface ICnaeAppService : IDisposable
	{
		IEnumerable<CnaeViewModel> ObterTodos();

		CnaeViewModel ObterPorId(int id);

		bool Adicionar(CnaeViewModel cnaeViewModel);

		bool Atualizar(CnaeViewModel cnaeViewModel);

		bool Excluir(int id);
	}
}
