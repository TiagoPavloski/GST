using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IUFService : IDisposable
	{
		IEnumerable<UF> ObterTodos();

		UF ObterPorId(int id);

		IEnumerable<UF> Find(Expression<Func<UF, bool>> predicate);

		void Adicionar(UF uF);

		void Atualizar(UF uF);

		void Excluir(int id);
	}
}
