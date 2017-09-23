using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface ITelefoneService : IDisposable
	{
		IEnumerable<Telefone> ObterTodos();

		Telefone ObterPorId(int id);

		IEnumerable<Telefone> Find(Expression<Func<Telefone, bool>> predicate);

		void Adicionar(Telefone telefone);

		void Atualizar(Telefone telefone);

		void Excluir(int id);
	}
}
