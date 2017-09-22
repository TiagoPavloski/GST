using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IRepository;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Domain.Services
{
	public class UFService : IUFService
	{
		private readonly IUFRepository _uFRepository;

		public UFService(IUFRepository uFRepository)
		{
			_uFRepository = uFRepository;
		}

		public void Adicionar(UF uF)
		{
			_uFRepository.Adicionar(uF);
		}

		public void Atualizar(UF uF)
		{
			_uFRepository.Atualizar(uF);
		}

		public void Dispose()
		{
			_uFRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Excluir(int id)
		{
			_uFRepository.Excluir(id);
		}

		public IEnumerable<UF> Find(Expression<Func<UF, bool>> predicate)
		{
			return _uFRepository.Find(predicate);
		}

		public UF ObterPorId(int id)
		{
			return _uFRepository.ObterPorId(id);
		}

		public IEnumerable<UF> ObterTodos()
		{
			return _uFRepository.ObterTodos();
		}
	}
}
