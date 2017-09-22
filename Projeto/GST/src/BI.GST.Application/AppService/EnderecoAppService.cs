using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Interface.IService;
using BI.GST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
	public class EnderecoAppService : BaseAppService, IEnderecoAppService
	{
		private readonly IEnderecoService _enderecoService;

		public EnderecoAppService(IEnderecoService enderecoService)
		{
			_enderecoService = enderecoService;
		}
		public bool Adicionar(EnderecoViewModel enderecoViewModel)
		{
			var Endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

			BeginTransaction();
			_enderecoService.Adicionar(Endereco);
			Commit();
			return true;
		}


		public bool Atualizar(EnderecoViewModel enderecoViewModel)
		{
			var Endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

			BeginTransaction();
			_enderecoService.Atualizar(Endereco);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_enderecoService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _enderecoService.Find(e => e.EnderecoId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var tipoEndereco = _enderecoService.ObterPorId(id);
				tipoEndereco.Delete = true;
				_enderecoService.Atualizar(tipoEndereco);
				Commit();
				return true;
			}
			return false;
		}
		public EnderecoViewModel ObterPorId(int id)
		{
			return Mapper.Map<Endereco, EnderecoViewModel>(_enderecoService.ObterPorId(id));
		}

		public IEnumerable<EnderecoViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoService.ObterTodos());
		}
	}
}
