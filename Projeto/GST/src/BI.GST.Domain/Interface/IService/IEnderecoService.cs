using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Interface.IService
{
	public interface IEnderecoService : IDisposable
	{
		IEnumerable<Endereco> ObterTodos();

		Endereco ObterPorId(int id);

		IEnumerable<Endereco> Find(Expression<Func<Endereco, bool>> predicate);

		void Adicionar(Endereco endereco);

		void Atualizar(Endereco endereco);

		void Excluir(int id);
	}
}
