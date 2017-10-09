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
		public bool Adicionar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId)
		{
			empresaViewModel.Endereco.UFId = empresaViewModel.UFId;
			var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

			empresa.Endereco = Mapper.Map<EnderecoViewModel, Endereco>(empresaViewModel.Endereco);

			List<Telefone> telefones = new List<Telefone>();
			foreach (var item in telefoneViewModel)
				telefones.Add(Mapper.Map<TelefoneViewModel, Telefone>(item));

			empresa.Telefones = telefones;
			foreach (var item in setorId)
				empresa.Setores.Add(new Setor { SetorId = item });

			foreach (var item in cnaeSecundarioId)
				empresa.CnaeSecundarios.Add(new Cnae { CnaeId = item });

			BeginTransaction();
			_empresaService.Adicionar(empresa);
			Commit();
			return true;
		}


		public bool Atualizar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId)
		{
			empresaViewModel.Endereco.UFId = empresaViewModel.UFId;
			empresaViewModel.CnaePrincipal.CnaeId = empresaViewModel.CnaeId;

			var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

			foreach (var item in setorId)
				empresa.Setores.Add(new Setor { SetorId = item });

			foreach (var item in cnaeSecundarioId)
				empresa.CnaeSecundarios.Add(new Cnae { CnaeId = item });

			BeginTransaction();
			_empresaService.Atualizar(empresa);
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
