using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IEmpresaService : IDisposable
	{
		IEnumerable<Empresa> ObterTodos();

		Empresa ObterPorId(int id);

		IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate);

		void Adicionar(Empresa empresa);

		void Atualizar(Empresa empresa);

		void Excluir(int id);

		IEnumerable<Empresa> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);
	}
}
