using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface ICBOService : IDisposable
	{
		IEnumerable<CBO> ObterTodos();

        CBO ObterPorId(int id);

		IEnumerable<CBO> Find(Expression<Func<CBO, bool>> predicate);

		void Adicionar(CBO cbo);

		void Atualizar(CBO cbo);

		void Excluir(int id);

		IEnumerable<CBO> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);
	}
}
