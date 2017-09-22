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
	public class EnderecoService : IEnderecoService
	{
		private readonly IEnderecoRepository _enderecoRepository;

		public EnderecoService(IEnderecoRepository enderecoRepository)
		{
			_enderecoRepository = enderecoRepository;
		}

		public void Adicionar(Endereco endereco)
		{
			_enderecoRepository.Adicionar(endereco);
		}

		public void Atualizar(Endereco endereco)
		{
			_enderecoRepository.Atualizar(endereco);
		}

		public void Dispose()
		{
			_enderecoRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Excluir(int id)
		{
			_enderecoRepository.Excluir(id);
		}

		public IEnumerable<Endereco> Find(Expression<Func<Endereco, bool>> predicate)
		{
			return _enderecoRepository.Find(predicate);
		}

		public Endereco ObterPorId(int id)
		{
			return _enderecoRepository.ObterPorId(id);
		}

		public IEnumerable<Endereco> ObterTodos()
		{
			return _enderecoRepository.ObterTodos();
		}
	}
}
