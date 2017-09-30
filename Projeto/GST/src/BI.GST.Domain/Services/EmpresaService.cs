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
	public class EmpresaService : IEmpresaService
	{
		private readonly IEmpresaRepository _empresaRepository;

		public EmpresaService(IEmpresaRepository empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}


		public void Dispose()
		{
			_empresaRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public IEnumerable<Empresa> ObterTodos()
		{
			return _empresaRepository.ObterTodos();
		}

		public Empresa ObterPorId(int id)
		{
			return _empresaRepository.ObterPorId(id);
		}

		public IEnumerable<Empresa> Find(Expression<Func<Empresa, bool>> predicate)
		{
			return _empresaRepository.Find(predicate);
		}

		public void Adicionar(Empresa empresa)
		{
			_empresaRepository.Adicionar(empresa);
		}

		public void Atualizar(Empresa empresa)
		{
			_empresaRepository.Atualizar(empresa);
		}

		public void Excluir(int id)
		{
			_empresaRepository.Excluir(id);
		}

		public IEnumerable<Empresa> ObterGrid(int page, string pesquisa)
		{
			return _empresaRepository.ObterGrid(page, pesquisa);
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _empresaRepository.ObterTotalRegistros(pesquisa);
		}
	}
}
