using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IExameService : IDisposable
	{
		IEnumerable<Exame> ObterTodos();

		Exame ObterPorId(int id);

		IEnumerable<Exame> Find(Expression<Func<Exame, bool>> predicate);

		void Adicionar(Exame exame);

		void Atualizar(Exame exame);

		void Excluir(int id);

		IEnumerable<Exame> ObterGrid(int page, string pesquisa);

		int ObterTotalRegistros(string pesquisa);

		IEnumerable<Exame> AlertaExames();
	}
}
