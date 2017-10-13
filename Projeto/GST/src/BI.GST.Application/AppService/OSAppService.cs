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
	public class OSAppService : BaseAppService, IOSAppService
	{
		private readonly IOSService _oSService;

		public OSAppService(IOSService oSService)
		{
			_oSService = oSService;
		}

		public bool Adicionar(OSViewModel oSViewModel)
		{
			var oS = Mapper.Map<OSViewModel, OS>(oSViewModel);

			BeginTransaction();
			_oSService.Adicionar(oS);
			Commit();
			return true;

		}

		public bool Atualizar(OSViewModel oSViewModel)
		{
			var oS = Mapper.Map<OSViewModel, OS>(oSViewModel);

			BeginTransaction();
			_oSService.Atualizar(oS);
			Commit();
			return true;

		}

		public void Dispose()
		{
			_oSService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _oSService.Find(e => e.OsId == id).Any();

			if (existente)
			{
				BeginTransaction();
				var oS = _oSService.ObterPorId(id);
				oS.Delete = true;
				_oSService.Atualizar(oS);
				Commit();
				return true;
			}
			return false;
		}

		public IEnumerable<OSViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<OS>, IEnumerable<OSViewModel>>(_oSService.ObterGrid(page, pesquisa));
		}

		public OSViewModel ObterPorId(int id)
		{
			return Mapper.Map<OS, OSViewModel>(_oSService.ObterPorId(id));
		}

		public IEnumerable<OSViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<OS>, IEnumerable<OSViewModel>>(_oSService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _oSService.ObterTotalRegistros(pesquisa);
		}
	}
}
