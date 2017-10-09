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
	public class UsuarioAppService : BaseAppService, IUsuarioAppService
	{
		private readonly IUsuarioService _UsuarioService;

		public UsuarioAppService(IUsuarioService UsuarioService)
		{
			_UsuarioService = UsuarioService;
		}
		public bool Adicionar(UsuarioViewModel usuarioViewModel)
		{
			var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
			var duplicado = _UsuarioService.Find(e => e.Nome == usuario.Nome).Any();
			if (duplicado)
			{
				return false;
			}
			else
			{
				BeginTransaction();
				_UsuarioService.Adicionar(usuario);
				Commit();
				return true;
			}
		}

		public bool Atualizar(UsuarioViewModel UsuarioViewModel)
		{
			var usuario = Mapper.Map<UsuarioViewModel, Usuario>(UsuarioViewModel);

			var duplicado = _UsuarioService.Find(e => e.Nome == usuario.Nome && e.UsuarioId != usuario.UsuarioId).Any();

			if (duplicado)
			{
				return false;
			}
			else
			{
				BeginTransaction();
				_UsuarioService.Atualizar(usuario);
				Commit();
				return true;
			}

		}

		public void Dispose()
		{
			_UsuarioService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _UsuarioService.Find(e => e.UsuarioId == id).Any();

			if (existente)
			{
				BeginTransaction();
				var usuario = _UsuarioService.ObterPorId(id);
				usuario.Delete = true;
				_UsuarioService.Atualizar(usuario);
				Commit();
				return true;
			}
			return false;
		}

		public UsuarioViewModel Login(UsuarioViewModel usuario)
		{
			var retorno = _UsuarioService.Find(x => (x.Email == usuario.Email) && (x.Senha == usuario.Senha) && (x.Delete == false)).FirstOrDefault();

			if (retorno != null)
				return Mapper.Map<Usuario, UsuarioViewModel>(retorno);
			else
				return usuario;
		}

		public IEnumerable<UsuarioViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioService.ObterGrid(page, pesquisa));
		}

		public UsuarioViewModel ObterPorId(int id)
		{
			return Mapper.Map<Usuario, UsuarioViewModel>(_UsuarioService.ObterPorId(id));
		}

		public IEnumerable<UsuarioViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _UsuarioService.ObterTotalRegistros(pesquisa);
		}
	}
}
