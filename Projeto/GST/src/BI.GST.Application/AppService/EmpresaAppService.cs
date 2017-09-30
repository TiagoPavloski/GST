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
	public class EmpresaAppService : BaseAppService, IEmpresaAppService
	{
		private readonly IEmpresaService _empresaService;

		public EmpresaAppService(IEmpresaService empresaService)
		{
			_empresaService = empresaService;
		}
		public bool Adicionar(EmpresaViewModel empresaViewModel)
		{
			var Empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

			BeginTransaction();
			_empresaService.Adicionar(Empresa);
			Commit();
			return true;
		}


		public bool Atualizar(EmpresaViewModel empresaViewModel)
		{
			var Empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

			BeginTransaction();
			_empresaService.Atualizar(Empresa);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_empresaService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _empresaService.Find(e => e.EmpresaId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var tipoEmpresa = _empresaService.ObterPorId(id);
				tipoEmpresa.Delete = true;
				_empresaService.Atualizar(tipoEmpresa);
				Commit();
				return true;
			}
			return false;
		}

		public IEnumerable<EmpresaViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaViewModel>>(_empresaService.ObterGrid(page, pesquisa));
		}

		public EmpresaViewModel ObterPorId(int id)
		{
			return Mapper.Map<Empresa, EmpresaViewModel>(_empresaService.ObterPorId(id));
		}

		public IEnumerable<EmpresaViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaViewModel>>(_empresaService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _empresaService.ObterTotalRegistros(pesquisa);
		}
	}
}
