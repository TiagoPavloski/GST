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
	public class VacinaAppService : BaseAppService, IVacinaAppService
	{
		private readonly IVacinaService _vacinaService;

		public VacinaAppService(IVacinaService vacinaService)
		{
			_vacinaService = vacinaService;
		}
		public bool Adicionar(VacinaViewModel vacinaViewModel)
		{
			vacinaViewModel.Renovado = false;
			var vacina = Mapper.Map<VacinaViewModel, Vacina>(vacinaViewModel);

			var vacinaspRenovar = _vacinaService.Find(e => (e.FuncionarioId == vacina.FuncionarioId) && (e.TipoVacinaId == vacina.TipoVacinaId) && (e.Renovado == false) && (e.Delete == false)).FirstOrDefault();

			BeginTransaction();
			if (vacinaspRenovar != null)
			{
				vacinaspRenovar.Renovado = true;
				_vacinaService.Atualizar(vacinaspRenovar);
			}
			_vacinaService.Adicionar(vacina);
			Commit();
			return true;
		}


		public bool Atualizar(VacinaViewModel vacinaViewModel)
		{
			var vacina = Mapper.Map<VacinaViewModel, Vacina>(vacinaViewModel);

			var vacinaspRenovar = _vacinaService.Find(e => (e.FuncionarioId == vacina.FuncionarioId) && (e.TipoVacinaId == vacina.TipoVacinaId) && (e.Renovado == false) && (e.Delete == false) && (e.VacinaId != vacina.VacinaId)).FirstOrDefault();

			BeginTransaction();
			if (vacinaspRenovar != null)
			{
				vacinaspRenovar.Renovado = true;
				_vacinaService.Atualizar(vacinaspRenovar);
			}
			_vacinaService.Atualizar(vacina);
			Commit();
			return true;
		}


		public void Dispose()
		{
			_vacinaService.Dispose();
			GC.SuppressFinalize(this);
		}

		public bool Excluir(int id)
		{
			bool existente = _vacinaService.Find(e => e.VacinaId == id).Any();
			var vacina = _vacinaService.ObterPorId(id);

			var vacinapRenovar = _vacinaService.Find(e => (e.FuncionarioId == vacina.FuncionarioId) && (e.TipoVacinaId == vacina.TipoVacinaId) && (e.Renovado == true) && (e.Delete == false)).FirstOrDefault();
			vacinapRenovar.Renovado = false;

			if (existente)
			{
				BeginTransaction();
				vacina.Delete = true;
				_vacinaService.Atualizar(vacinapRenovar);
				_vacinaService.Atualizar(vacina);
				Commit();
				return true;
			}
			return false;
		}

		public IEnumerable<VacinaViewModel> ObterGrid(int page, string pesquisa)
		{
			return Mapper.Map<IEnumerable<Vacina>, IEnumerable<VacinaViewModel>>(_vacinaService.ObterGrid(page, pesquisa));
		}

		public VacinaViewModel ObterPorId(int id)
		{
			return Mapper.Map<Vacina, VacinaViewModel>(_vacinaService.ObterPorId(id));
		}

		public IEnumerable<VacinaViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<Vacina>, IEnumerable<VacinaViewModel>>(_vacinaService.ObterTodos());
		}

		public int ObterTotalRegistros(string pesquisa)
		{
			return _vacinaService.ObterTotalRegistros(pesquisa);
		}
	}
}
