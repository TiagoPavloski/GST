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
	public class EmpresasController : Controller
	{

		private readonly IEmpresaAppService _empresaAppService;
		private readonly IEnderecoAppService _enderecoAppService;
		private readonly ITelefoneAppService _telefoneAppService;
		//private readonly IFuncionarioAppService _funcionarioAppService;
		private readonly ICnaeAppService _cnaeAppService;
		private readonly ISetorAppService _setorAppService;
		private readonly IUFAppService _uFAppService;

		public EmpresasController(IEmpresaAppService empresaAppService, IEnderecoAppService enderecoAppService, ITelefoneAppService telefoneAppService/*, IFuncionarioAppService funcionarioAppService*/, ICnaeAppService cnaeAppService, ISetorAppService setorAppService, IUFAppService uFAppService)
		{
			_empresaAppService = empresaAppService;
			_enderecoAppService = enderecoAppService;
			_telefoneAppService = telefoneAppService;
			//_funcionarioAppService = funcionarioAppService;
			_cnaeAppService = cnaeAppService;
			_setorAppService = setorAppService;
			_uFAppService = uFAppService;
		}
		// GET: Empresas
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var empresaViewModel = _empresaAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Empresas";
			ViewBag.TotalRegistros = _empresaAppService.ObterTotalRegistros(pesquisa);

			return View(empresaViewModel);
		}

		// GET: Empresas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}
			return View(empresa);
		}

		public ActionResult LinhaTelefone()
		{
			var telefone = new TelefoneViewModel();
			return PartialView("_Telefone", telefone);
		}

		// GET: Empresas/Create
		public ActionResult Create()
		{
			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome");
			ViewBag.CnaeIdList = new MultiSelectList(_cnaeAppService.ObterTodos(), "CnaeId", "Descricao");
			ViewBag.SetorIdList = new MultiSelectList(_setorAppService.ObterTodos(), "SetorId", "Nome");

			var empresaViewModel = new EmpresaViewModel();
			return View(empresaViewModel);
		}

		// POST: Empresas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EmpresaViewModel empresaViewModel, List<TelefoneViewModel> telefoneViewModel, List<CnaeViewModel> cnaeSecundarioViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_empresaAppService.Adicionar(empresaViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um empresa com os mesmos dados')</SCRIPT>");
				}
				else
					return RedirectToAction("Index");
			}
			return View(empresaViewModel);
		}

		// GET: Empresas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}
			return View(empresa);
		}

		// POST: Empresas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EmpresaViewModel empresaViewModel)
		{
			//UF ID selecionado
			if (ModelState.IsValid)
			{
				if (!_empresaAppService.Atualizar(empresaViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Curso com os mesmos dados já cadastrada')</SCRIPT>");
				}
				else
					return RedirectToAction("Index");
			}
			return View(empresaViewModel);
		}

		// GET: Empresas/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresa = _empresaAppService.ObterPorId(id.Value);
			if (empresa == null)
			{
				return HttpNotFound();
			}
			return View(empresa);
		}

		// POST: Empresas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_empresaAppService.Excluir(id))
			{
				System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Erro')</SCRIPT>");
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
				_empresaAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
