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
	public class TelefoneService : ITelefoneService
	{
		private readonly ITelefoneRepository _telefoneRepository;

		public TelefoneService(ITelefoneRepository telefoneRepository)
		{
			_telefoneRepository = telefoneRepository;
		}

		public void Adicionar(Telefone telefone)
		{
			_telefoneRepository.Adicionar(telefone);
		}

		public void Atualizar(Telefone telefone)
		{
			_telefoneRepository.Atualizar(telefone);
		}

		public void Dispose()
		{
			_telefoneRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Excluir(int id)
		{
			_telefoneRepository.Excluir(id);
		}

		public IEnumerable<Telefone> Find(Expression<Func<Telefone, bool>> predicate)
		{
			return _telefoneRepository.Find(predicate);
		}

		public Telefone ObterPorId(int id)
		{
			return _telefoneRepository.ObterPorId(id);
		}

		public IEnumerable<Telefone> ObterTodos()
		{
			return _telefoneRepository.ObterTodos();
		}
	}
}
