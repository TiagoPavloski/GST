using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
	public interface IUsuarioAppService : IDisposable
	{
		IEnumerable<UsuarioViewModel> ObterTodos();

		UsuarioViewModel ObterPorId(int id);

		UsuarioViewModel Login(UsuarioViewModel usuario);

		bool Adicionar(UsuarioViewModel UsuarioViewModel);

		bool Atualizar(UsuarioViewModel UsuarioViewModel);

		bool Excluir(int id);

		IEnumerable<UsuarioViewModel> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);
	}
}
