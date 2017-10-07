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
    public class EmpresaUtilizadorasController : Controller
    {
		private readonly IEmpresaUtilizadoraAppService _empresaUtilizadoraAppService;
		private readonly IEnderecoAppService _enderecoViewModelAppService;
		private readonly ITelefoneAppService _funcionarioAppService;
		private readonly IUFAppService _uFAppService;

		public EmpresaUtilizadorasController(IEmpresaUtilizadoraAppService empresaUtilizadoraAppService, IEnderecoAppService enderecoViewModelAppService, ITelefoneAppService funcionarioAppService, IUFAppService uFAppService)
		{
			_empresaUtilizadoraAppService = empresaUtilizadoraAppService;
			_enderecoViewModelAppService = enderecoViewModelAppService;
			_funcionarioAppService = funcionarioAppService;
			_uFAppService = uFAppService;
		}

		// GET: EmpresaUtilizadoras
		public ActionResult Index(string pesquisa, int page = 0)
        {
			var empresaUtilizadoraViewModel = _empresaUtilizadoraAppService.ObterGrid(page, pesquisa);
			ViewBag.PaginaAtual = page;
			ViewBag.Busca = "&pesquisa=" + pesquisa;
			ViewBag.Controller = "Cursos";
			ViewBag.TotalRegistros = _empresaUtilizadoraAppService.ObterTotalRegistros(pesquisa);

			return View(empresaUtilizadoraViewModel);
		}

        // GET: EmpresaUtilizadoras/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresaUtilizadora = _empresaUtilizadoraAppService.ObterPorId(id.Value);
			if (empresaUtilizadora == null)
			{
				return HttpNotFound();
			}
			return View(empresaUtilizadora);
		}

        // GET: EmpresaUtilizadoras/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(_enderecoViewModelAppService.ObterTodos(), "EnderecoId", "Logradouro");
			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome");
			return View();
        }

        // POST: EmpresaUtilizadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel)
        {
			if (ModelState.IsValid)
			{
				if (!_empresaUtilizadoraAppService.Adicionar(empresaUtilizadoraViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um empresaUtilizadora com os mesmos dados')</SCRIPT>");
				}
				else
					return RedirectToAction("Index");
			}
			ViewBag.EnderecoId = new SelectList(_enderecoViewModelAppService.ObterTodos(), "EnderecoId", "Logradouro", empresaUtilizadoraViewModel.EnderecoId);
			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome", empresaUtilizadoraViewModel.Endereco.UFId);
			return View(empresaUtilizadoraViewModel);
        }

        // GET: EmpresaUtilizadoras/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresaUtilizadora = _empresaUtilizadoraAppService.ObterPorId(id.Value);
			if (empresaUtilizadora == null)
			{
				return HttpNotFound();
			}
			ViewBag.EnderecoId = new SelectList(_enderecoViewModelAppService.ObterTodos(), "EnderecoId", "Logradouro", empresaUtilizadora.EnderecoId);
			ViewBag.UFId = new SelectList(_uFAppService.ObterTodos(), "UFId", "Nome", empresaUtilizadora.Endereco.UFId);
			return View(empresaUtilizadora);
		}

        // POST: EmpresaUtilizadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaUtilizadoraViewModel empresaUtilizadoraViewModel)
        {
			if (ModelState.IsValid)
			{
				if (!_empresaUtilizadoraAppService.Atualizar(empresaUtilizadoraViewModel))
				{
					System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Curso com os mesmos dados já cadastrada')</SCRIPT>");
				}
				else
					return RedirectToAction("Index");
			}
			return View(empresaUtilizadoraViewModel);
		}

        // GET: EmpresaUtilizadoras/Delete/5
        public ActionResult Delete(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var empresaUtilizadora = _empresaUtilizadoraAppService.ObterPorId(id.Value);
			if (empresaUtilizadora == null)
			{
				return HttpNotFound();
			}
			return View(empresaUtilizadora);
		}

        // POST: EmpresaUtilizadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			if (!_empresaUtilizadoraAppService.Excluir(id))
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
				_empresaUtilizadoraAppService.Dispose();
			}
			base.Dispose(disposing);
		}
    }
}
