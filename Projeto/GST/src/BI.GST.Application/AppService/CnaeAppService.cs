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
	public class CnaeAppService : BaseAppService, ICnaeAppService
	{

		private readonly ICnaeService _cnaeService;

		public CnaeAppService(ICnaeService cnaeService)
		{
			_cnaeService = cnaeService;
		}

		public bool Adicionar(CnaeViewModel cnaeViewModel)
		{
			var cronograma = Mapper.Map<CnaeViewModel, Cnae>(cnaeViewModel);

			BeginTransaction();
			_cnaeService.Adicionar(cronograma);
			Commit();
			return true;
		}

		public bool Atualizar(CnaeViewModel cnaeViewModel)
		{
			var cronograma = Mapper.Map<CnaeViewModel, Cnae>(cnaeViewModel);

			BeginTransaction();
			_cnaeService.Atualizar(cronograma);
			Commit();
			return true;
		}

		public void Dispose()
		{
			_cnaeService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _cnaeService.Find(e => e.CnaeId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var cronograma = _cnaeService.ObterPorId(id);
				cronograma.Delete = true;
				_cnaeService.Atualizar(cronograma);
				Commit();
				return true;
			}
			return false;
		}

		public CnaeViewModel ObterPorId(int id)
		{
			return Mapper.Map<Cnae, CnaeViewModel>(_cnaeService.ObterPorId(id));
		}

		public IEnumerable<CnaeViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_cnaeService.ObterTodos());
		}
	}
}
