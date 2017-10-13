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
	public class OSService : IOSService
	{
		private readonly IOSRepository _oSRepository;

		public OSService(IOSRepository oSRepository)
		{
			_oSRepository = oSRepository;
		}


		public void Dispose()
		{
			_oSRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public IEnumerable<OS> ObterTodos()
		{
			return _oSRepository.ObterTodos();
		}

		public OS ObterPorId(int id)
		{
			return _oSRepository.ObterPorId(id);
		}

		public IEnumerable<OS> Find(Expression<Func<OS, bool>> predicate)
		{
			return _oSRepository.Find(predicate);
		}

		public void Adicionar(OS oS)
		{
			_oSRepository.Adicionar(oS);
		}

		public void Atualizar(OS oS)
		{
			_oSRepository.Atualizar(oS);
		}

		public void Excluir(int id)
		{
			_oSRepository.Excluir(id);
		}

		public IEnumerable<OS> ObterGrid(int page, string pesquisa)
		{
			return _oSRepository.ObterGrid(page, pesquisa);
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _oSRepository.ObterTotalRegistros(pesquisa);
		}
	}
}
