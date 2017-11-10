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
	public class VacinaService : IVacinaService
	{
		private readonly IVacinaRepository _vacinaRepository;

		public VacinaService(IVacinaRepository vacinaRepository)
		{
			_vacinaRepository = vacinaRepository;
		}

		public void Adicionar(Vacina vacina)
		{
			_vacinaRepository.Adicionar(vacina);
		}

		public void Atualizar(Vacina vacina)
		{
			_vacinaRepository.Atualizar(vacina);
		}

		public void Dispose()
		{
			_vacinaRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Excluir(int id)
		{
			_vacinaRepository.Excluir(id);
		}

		public IEnumerable<Vacina> Find(Expression<Func<Vacina, bool>> predicate)
		{
			return _vacinaRepository.Find(predicate);
		}

		public IEnumerable<Vacina> ObterGrid(int page, string pesquisa)
		{
			return _vacinaRepository.ObterGrid(page, pesquisa);
		}

		public Vacina ObterPorId(int id)
		{
			return _vacinaRepository.ObterPorId(id);
		}

		public IEnumerable<Vacina> ObterTodos()
		{
			return _vacinaRepository.ObterTodos();
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _vacinaRepository.ObterTotalRegistros(pesquisa);
		}


		public IEnumerable<Vacina> AlertaVacinas()
		{
			return _vacinaRepository.AlertaVacinas();
		}
	}
}
