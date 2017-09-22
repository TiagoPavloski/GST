using BI.GST.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface IEnderecoAppService : IDisposable
	{
		IEnumerable<EnderecoViewModel> ObterTodos();

		EnderecoViewModel ObterPorId(int id);

		bool Adicionar(EnderecoViewModel enderecoViewModel);

		bool Atualizar(EnderecoViewModel enderecoViewModel);

		bool Excluir(int id);
	}
}
