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
	public class CursoAppService : BaseAppService, ICursoAppService
	{
		private readonly ICursoService _cursoService;

		public CursoAppService(ICursoService cursoService)
		{
			_cursoService = cursoService;
		}
		public bool Adicionar(CursoViewModel cursoViewModel)
		{
			cursoViewModel.Renovado = false;
			var curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);

			var cursospRenovar = _cursoService.Find(e => (e.FuncionarioId == curso.FuncionarioId) && (e.TipoCursoId == curso.TipoCursoId) && (e.Renovado == false) && (e.Delete == false)).FirstOrDefault();

			BeginTransaction();
			if (cursospRenovar != null)
			{
				cursospRenovar.Renovado = true;
				_cursoService.Atualizar(cursospRenovar);
			}
			_cursoService.Adicionar(curso);
			Commit();
			return true;
		}

		public bool Atualizar(CursoViewModel cursoViewModel)
		{
			var curso = Mapper.Map<CursoViewModel, Curso>(cursoViewModel);

			var cursospRenovar = _cursoService.Find(e => (e.FuncionarioId == curso.FuncionarioId) && (e.TipoCursoId == curso.TipoCursoId) && (e.Renovado == false) && (e.Delete == false) && (e.CursoId != curso.CursoId)).FirstOrDefault();

			BeginTransaction();
			if (cursospRenovar != null)
			{
				cursospRenovar.Renovado = true;
				_cursoService.Atualizar(cursospRenovar);
			}
			_cursoService.Atualizar(curso);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_cursoService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _cursoService.Find(e => e.CursoId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var curso = _cursoService.ObterPorId(id);
				curso.Delete = true;
				_cursoService.Atualizar(curso);
				Commit();
				return true;
			}
			return false;
		}

		public IEnumerable<CursoViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoService.ObterGrid(page, pesquisa));
		}

		public CursoViewModel ObterPorId(int id)
		{
			return Mapper.Map<Curso, CursoViewModel>(_cursoService.ObterPorId(id));
		}

		public IEnumerable<CursoViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _cursoService.ObterTotalRegistros(pesquisa);
		}

		public IEnumerable<CursoViewModel> AlertaCursos()
		{
			var cursos = Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoViewModel>>(_cursoService.AlertaCursos());
			List<CursoViewModel> cursosVencidos = new List<CursoViewModel>();
			foreach (var item in cursos)
			{
				if (VerificaVencimento(item.Data, item.TipoCurso.MesesValidade))
				{
					cursosVencidos.Add(item);
				}
			}
			return cursosVencidos;
		}

		public bool VerificaVencimento(string data, int mesesValidade)
		{
			return !(Convert.ToDateTime(data).AddMonths(mesesValidade) > DateTime.Today);
		}
	}
}
