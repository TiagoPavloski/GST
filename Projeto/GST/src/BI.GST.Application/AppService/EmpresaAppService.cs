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
		private readonly ITelefoneService _telefoneService;
		private readonly IEnderecoService _enderecoService;
		private readonly IFuncionarioService _funcionarioService;

		public EmpresaAppService(IEmpresaService empresaService, ITelefoneService telefoneService, IEnderecoService enderecoService, IFuncionarioService funcionarioService)
		{
			_empresaService = empresaService;
			_telefoneService = telefoneService;
			_enderecoService = enderecoService;
			_funcionarioService = funcionarioService;
		}
		public bool Adicionar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId, int[] funcionarioId)
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

			foreach (var item in funcionarioId)
				empresa.Responsaveis.Add(new Funcionario { FuncionarioId = item });

			BeginTransaction();
			_empresaService.Adicionar(empresa);
			Commit();
			return true;
		}


		public bool Atualizar(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, int[] setorId, int[] cnaeSecundarioId, int[] funcionarioId)
		{
			empresaViewModel.Endereco.UFId = empresaViewModel.UFId;
			empresaViewModel.CnaePrincipal.CnaeId = empresaViewModel.CnaeId;

			var empresa = Mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel);

			foreach (var item in setorId)
				empresa.Setores.Add(new Setor { SetorId = item });

			foreach (var item in cnaeSecundarioId)
				empresa.CnaeSecundarios.Add(new Cnae { CnaeId = item });

			foreach (var item in funcionarioId)
				empresa.Responsaveis.Add(new Funcionario { FuncionarioId = item });

			foreach (var item in telefoneViewModel)
			{
				if (item.EmpresaId == null)
					item.EmpresaId = empresa.EmpresaId;
				empresa.Telefones.Add(Mapper.Map<TelefoneViewModel, Telefone>(item));
			}

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
			var empresa = _empresaService.ObterPorId(id);

			List<Telefone> telefones = new List<Telefone>();
			foreach (var item in empresa.Telefones)
			{
				item.Delete = true;
				telefones.Add(item);
			}
			empresa.Endereco.Delete = true;

			if (existente)
			{
				BeginTransaction();
				empresa.Delete = true;
				_empresaService.Atualizar(empresa);
				_enderecoService.Atualizar(empresa.Endereco);
				foreach (var item in telefones)
				{
					_telefoneService.Atualizar(item);
				}
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

		public bool AdicionarResponsavel(string CPF)
		{
			throw new NotImplementedException();
		}

		public bool DeletarResponsavel(int id)
		{
			throw new NotImplementedException();
		}
	}
}
