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
	public class UFAppService : BaseAppService, IUFAppService
	{
		private readonly IUFService _uFService;

		public UFAppService(IUFService uFService)
		{
			_uFService = uFService;
		}
		public bool Adicionar(UFViewModel uFViewModel)
		{
			var UF = Mapper.Map<UFViewModel, UF>(uFViewModel);

			BeginTransaction();
			_uFService.Adicionar(UF);
			Commit();
			return true;
		}


		public bool Atualizar(UFViewModel uFViewModel)
		{
			var UF = Mapper.Map<UFViewModel, UF>(uFViewModel);

			BeginTransaction();
			_uFService.Atualizar(UF);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_uFService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _uFService.Find(e => e.UFId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var tipoUF = _uFService.ObterPorId(id);
				tipoUF.Delete = true;
				_uFService.Atualizar(tipoUF);
				Commit();
				return true;
			}
			return false;
		}
		public UFViewModel ObterPorId(int id)
		{
			return Mapper.Map<UF, UFViewModel>(_uFService.ObterPorId(id));
		}

		public IEnumerable<UFViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<UF>, IEnumerable<UFViewModel>>(_uFService.ObterTodos());
		}
	}
}
