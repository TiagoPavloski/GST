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
	public class CBOService : ICBOService
	{
		private readonly ICBORepository _cboRepository;

		public CBOService(ICBORepository cboRepository)
		{
            _cboRepository = cboRepository;
		}


		public void Dispose()
		{
            _cboRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public IEnumerable<CBO> ObterTodos()
		{
			return _cboRepository.ObterTodos();
		}

		public CBO ObterPorId(int id)
		{
			return _cboRepository.ObterPorId(id);
		}

		public IEnumerable<CBO> Find(Expression<Func<CBO, bool>> predicate)
		{
			return _cboRepository.Find(predicate);
		}

		public void Adicionar(CBO cbo)
		{
            _cboRepository.Adicionar(cbo);
		}

		public void Atualizar(CBO cbo)
		{
            _cboRepository.Atualizar(cbo);
		}

		public void Excluir(int id)
		{
            _cboRepository.Excluir(id);
		}

		public IEnumerable<CBO> ObterGrid(int page, string pesquisa)
		{
			return _cboRepository.ObterGrid(page, pesquisa);
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _cboRepository.ObterTotalRegistros(pesquisa);
		}
	}
}
