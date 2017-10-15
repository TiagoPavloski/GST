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
	public class OSController : Controller
	{
		private readonly IOSAppService _oSAppService;
		//private readonly IColaboradorAppService _colaboradorAppService;
		//private readonly IFuncionarioEmpresaAppService _funcionarioEmpresaAppService;

		public OSController(IOSAppService oSAppService/*, IColaboradorAppService colaboradorAppService, IFuncionarioEmpresaAppService funcionarioEmpresaAppService*/)
		{
			_oSAppService = oSAppService;
			//_colaboradorAppService = colaboradorAppService;
			//_funcionarioEmpresaAppService = funcionarioEmpresaAppService;
		}
		// GET: OS
		public ActionResult Index(string pesquisa, int page = 0)
		{
			var tipoCursoViewModel = _oSAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "OS";
			ViewBag.TotalRegistros = _oSAppService.ObterTotalRegistros(pesquisa);
			return View(tipoCursoViewModel);

			//var oSs = db.OSs.Include(o => o.Colaborador).Include(o => o.FuncionarioEmpresa);
		}

		// GET: OS/Create
		public ActionResult Create()
		{
			//ViewBag.ColaboradorId = new SelectList(_colaboradorAppService.ObterTodos(), "ColaboradorId", "Nome");
			//ViewBag.FuncionarioEmpresaId = new SelectList(_funcionarioEmpresaAppService.ObterTodos(), "FuncionarioEmpresaId", "HoraEntrada");
			return View();
		}

		// POST: OS/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(OSViewModel oSViewModel)
		{
			if (ModelState.IsValid)
			{
				if (!_oSAppService.Adicionar(oSViewModel))
				{
					TempData["Mensagem"] = "Erro";
				}
				else
					return RedirectToAction("Index");
			}
			//ViewBag.ColaboradorId = new SelectList(_colaboradorAppService.Colaboradores, "ColaboradorId", "Nome", oS.ColaboradorId);
			//ViewBag.FuncionarioEmpresaId = new SelectList(_funcionarioEmpresaAppService.FuncionariosEmpresas, "FuncionarioEmpresaId", "HoraEntrada", oS.FuncionarioEmpresaId);
			return View(oSViewModel);
		}

		// GET: OS/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var oS = _oSAppService.ObterPorId(id.Value);
			if (oS == null)
			{
				return HttpNotFound();
			}
			//ViewBag.ColaboradorId = new SelectList(_colaboradorAppService.Colaboradores, "ColaboradorId", "Nome", oS.ColaboradorId);
			//ViewBag.FuncionarioEmpresaId = new SelectList(_funcionarioEmpresaAppService.FuncionariosEmpresas, "FuncionarioEmpresaId", "HoraEntrada", oS.FuncionarioEmpresaId);
			return View(oS);
		}

		// POST: OS/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(OSViewModel oS)
		{
			if (ModelState.IsValid)
			{
				if (!_oSAppService.Atualizar(oS))
				{
					TempData["Mensagem"] = "Erro";
				}
				else
					return RedirectToAction("Index");
			}
			//ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "ColaboradorId", "Nome", oS.ColaboradorId);
			//ViewBag.FuncionarioEmpresaId = new SelectList(db.FuncionariosEmpresas, "FuncionarioEmpresaId", "HoraEntrada", oS.FuncionarioEmpresaId);
			return View(oS);
		}

		// GET: OS/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var oS = _oSAppService.ObterPorId(id.Value);
			if (oS == null)
			{
				return HttpNotFound();
			}
			return View(oS);
		}

		// POST: OS/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			if (!_oSAppService.Excluir(id))
			{
				TempData["Mensagem"] = "Erro";
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
				_oSAppService.Dispose();
			}
			base.Dispose(disposing);
		}


		// GET: OS/Edit/5
		//public ActionResult Gerar(int? id)
		//{
		//	//if (id == null)
		//	//{
		//	//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	//}
		//	//var oS = _oSAppService.ObterPorId(id.Value);
		//	//if (oS == null)
		//	//{
		//	//	return HttpNotFound();
		//	//}

		//	var oS = new OS();
		//	oS.Recomentacoes = "Recomendações";
		//	oS.DataElaboracao = "DataElaboração";

		//	var pdfResult = new PdfResult(oS, "Gerar");
		//	pdfResult.ViewBag.Title = "Teste Titulo";
		//	return pdfResult;
		//}
	}
}
