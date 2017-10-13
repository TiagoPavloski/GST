using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IOSService : IDisposable
	{
		IEnumerable<OS> ObterTodos();

		OS ObterPorId(int id);

		IEnumerable<OS> Find(Expression<Func<OS, bool>> predicate);

		void Adicionar(OS os);

		void Atualizar(OS os);

		void Excluir(int id);

		IEnumerable<OS> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);
	}
}
