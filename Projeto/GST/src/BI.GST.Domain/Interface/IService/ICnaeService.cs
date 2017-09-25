using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface ICnaeService : IDisposable
	{
		IEnumerable<Cnae> ObterTodos();

		Cnae ObterPorId(int id);

		IEnumerable<Cnae> Find(Expression<Func<Cnae, bool>> predicate);

		void Adicionar(Cnae cnae);

		void Atualizar(Cnae cnae);

		void Excluir(int id);
	}
}
