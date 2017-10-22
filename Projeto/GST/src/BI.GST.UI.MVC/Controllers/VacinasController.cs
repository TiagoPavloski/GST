using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Infra.Data.Context;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;

namespace BI.GST.UI.MVC.Controllers
{
	public class VacinasController : Controller
	{
		private readonly IVacinaAppService _vacinaAppService;
		private readonly ITipoVacinaAppService _tipoVacinaAppService;
		private readonly IFuncionarioAppService _funcionarioAppService;

		public VacinasController(IVacinaAppService vacinaAppService, ITipoVacinaAppService tipoVacinaAppService, IFuncionarioAppService funcionarioAppService)
		{
			_vacinaAppService = vacinaAppService;
			_tipoVacinaAppService = tipoVacinaAppService;
			_funcionarioAppService = funcionarioAppService;
		}

		// GET: Vacinas
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var vacinasViewModel = _vacinaAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Vacinas";
			ViewBag.TotalRegistros = _vacinaAppService.ObterTotalRegistros(pesquisa);

			#region DDL Status
			//List<SelectListItem> ddlStatus_Vacinas = new List<SelectListItem>();
			//ddlStatus_Vacinas.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
			//ddlStatus_Vacinas.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
			//TempData["ddlStatus_Vacinas"] = ddlStatus_Vacinas;

			//foreach (var item in vacinasViewModel)
			//{
			//    item.StatusNome = ddlStatus_Vacinas.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
			//}
			#endregion

			return View(vacinasViewModel);
		}

		// GET: Vacinas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var vacina = _vacinaAppService.ObterPorId(id.Value);
			if (vacina == null)
			{
				return HttpNotFound();
			}
			var ddlStatus_Vacinas = (List<SelectListItem>)TempData["ddlStatus_Vacinas"];
			//vacina.StatusNome = ddlStatus_Vacinas.Where(e => e.Value.Trim().Equals(vacina.Status.ToString())).First().Text;
			return View(vacina);
		}

		// GET: Vacinas/Create
		public ActionResult Create()
		{
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
			ViewBag.TipoVacinaId = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome");
			return View();
		}

		// POST: Vacinas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(VacinaViewModel vacinaViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_vacinaAppService.Adicionar(vacinaViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um Vacina com os mesmos dados";
				}
				else
					return RedirectToAction("Index");
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", vacinaViewModel.FuncionarioId);
			ViewBag.TipoVacinaId = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome", vacinaViewModel.TipoVacinaId);
			return View(vacinaViewModel);
		}

		// GET: Vacinas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var vacina = _vacinaAppService.ObterPorId(id.Value);
			if (vacina == null)
			{
				return HttpNotFound();
			}
			ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", vacina.FuncionarioId);
			ViewBag.TipoVacinaId = new SelectList(_tipoVacinaAppService.ObterTodos(), "TipoVacinaId", "Nome", vacina.TipoVacinaId);
			return View(vacina);
		}

		// POST: Vacinas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(VacinaViewModel vacinaViewModel)
		{

			if (ModelState.IsValid)
			{
				if (!_vacinaAppService.Atualizar(vacinaViewModel))
				{
					TempData["Mensagem"] = "Atenção, há um Vacina com os mesmos dados já cadastrada";
				}
				else
					return RedirectToAction("Index");
			}
			return View(vacinaViewModel);
		}

		// GET: Vacinas/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var vacina = _vacinaAppService.ObterPorId(id.Value);
			if (vacina == null)
			{
				return HttpNotFound();
			}
			var ddlStatus_Vacinas = (List<SelectListItem>)TempData["ddlStatus_Vacinas"];
			//vacina.StatusNome = ddlStatus_Vacinas.Where(e => e.Value.Trim().Equals(vacina.Status.ToString())).First().Text;
			return View(vacina);
		}

		// POST: Vacinas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_vacinaAppService.Excluir(id))
			{
				TempData["Mensagem"] = "Erro ao excluir";
				return null;
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_vacinaAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
