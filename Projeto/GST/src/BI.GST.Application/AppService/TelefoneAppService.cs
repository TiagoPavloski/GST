using AutoMapper;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using BI.GST.Domain.Entities;
using BI.GST.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
	public class TelefoneAppService : BaseAppService, ITelefoneAppService
	{
		private readonly ITelefoneService _telefoneService;

		public TelefoneAppService(ITelefoneService telefoneService)
		{
			_telefoneService = telefoneService;
		}
		public bool Adicionar(TelefoneViewModel telefoneViewModel)
		{
			var Telefone = Mapper.Map<TelefoneViewModel, Telefone>(telefoneViewModel);

			BeginTransaction();
			_telefoneService.Adicionar(Telefone);
			Commit();
			return true;
		}


		public bool Atualizar(TelefoneViewModel telefoneViewModel)
		{
			var Telefone = Mapper.Map<TelefoneViewModel, Telefone>(telefoneViewModel);

			BeginTransaction();
			_telefoneService.Atualizar(Telefone);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_telefoneService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _telefoneService.Find(e => e.TelefoneId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var tipoTelefone = _telefoneService.ObterPorId(id);
				tipoTelefone.Delete = true;
				_telefoneService.Atualizar(tipoTelefone);
				Commit();
				return true;
			}
			return false;
		}
		public TelefoneViewModel ObterPorId(int id)
		{
			return Mapper.Map<Telefone, TelefoneViewModel>(_telefoneService.ObterPorId(id));
		}

		public IEnumerable<TelefoneViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Telefone>, IEnumerable<TelefoneViewModel>>(_telefoneService.ObterTodos());
		}
	}
}
