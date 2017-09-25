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
	public class CnaeService : ICnaeService
	{
		private readonly ICnaeRepository _cnaeRepository;

		public CnaeService(ICnaeRepository cnaeRepository)
		{
			_cnaeRepository = cnaeRepository;
		}

		public void Adicionar(Cnae cnae)
		{
			_cnaeRepository.Adicionar(cnae);
		}

		public void Atualizar(Cnae cnae)
		{
			_cnaeRepository.Atualizar(cnae);
		}

		public void Dispose()
		{
			_cnaeRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Excluir(int id)
		{
			_cnaeRepository.Excluir(id);
		}

		public IEnumerable<Cnae> Find(Expression<Func<Cnae, bool>> predicate)
		{
			return _cnaeRepository.Find(predicate);
		}

		public Cnae ObterPorId(int id)
		{
			return _cnaeRepository.ObterPorId(id);
		}

		public IEnumerable<Cnae> ObterTodos()
		{
			return _cnaeRepository.ObterTodos();
		}
	}
}
