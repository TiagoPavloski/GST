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
	public class ExameAppService : BaseAppService, IExameAppService
	{
		private readonly IExameService _exameService;

		public ExameAppService(IExameService exameService)
		{
			_exameService = exameService;
		}
		public bool Adicionar(ExameViewModel exameViewModel)
		{
			exameViewModel.Renovado = false;
			var exame = Mapper.Map<ExameViewModel, Exame>(exameViewModel);

			var examespRenovar = _exameService.Find(e => (e.FuncionarioId == exame.FuncionarioId) && (e.TipoExameId == exame.TipoExameId) && (e.Renovado == false) && (e.Delete == false)).FirstOrDefault();

			BeginTransaction();
			if (examespRenovar != null)
			{
				examespRenovar.Renovado = true;
				_exameService.Atualizar(examespRenovar);
			}
			_exameService.Adicionar(exame);
			Commit();
			return true;
		}


		public bool Atualizar(ExameViewModel exameViewModel)
		{
			var exame = Mapper.Map<ExameViewModel, Exame>(exameViewModel);

			var examespRenovar = _exameService.Find(e => (e.FuncionarioId == exame.FuncionarioId) && (e.TipoExameId == exame.TipoExameId) && (e.Renovado == false) && (e.Delete == false) && (e.ExameId != exame.ExameId)).FirstOrDefault();

			BeginTransaction();
			if (examespRenovar != null)
			{
				examespRenovar.Renovado = true;
				_exameService.Atualizar(examespRenovar);
			}
			_exameService.Atualizar(exame);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_exameService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _exameService.Find(e => e.ExameId == id).Any();
			if (existente)
			{
				BeginTransaction();
				var tipoExame = _exameService.ObterPorId(id);
				tipoExame.Delete = true;
				_exameService.Atualizar(tipoExame);
				Commit();
				return true;
			}
			return false;
		}

		public IEnumerable<ExameViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(_exameService.ObterGrid(page, pesquisa));
		}

		public ExameViewModel ObterPorId(int id)
		{
			return Mapper.Map<Exame, ExameViewModel>(_exameService.ObterPorId(id));
		}

		public IEnumerable<ExameViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(_exameService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _exameService.ObterTotalRegistros(pesquisa);
		}

		public List<ExameViewModel> AlertaExames()
		{
			var exame = Mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(_exameService.AlertaExames());
			List<ExameViewModel> examesVencidos = new List<ExameViewModel>();
			foreach (var item in exame)
			{
				if (VerificaVencimento(item.Data, item.TipoExame.MesesValidade))
				{
					examesVencidos.Add(item);
				}
			}
			return examesVencidos;
		}

		public bool VerificaVencimento(string data, int mesesValidade)
		{
			return !(Convert.ToDateTime(data).AddMonths(mesesValidade) > DateTime.Today);
		}
	}
}
