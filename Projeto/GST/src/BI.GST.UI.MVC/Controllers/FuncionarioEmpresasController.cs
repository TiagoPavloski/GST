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
    public class FuncionarioEmpresasController : Controller
    {
        private readonly IFuncionarioEmpresaAppService _funcionarioEmpresaAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly ICBOAppService _cboAppService;
        private readonly ISetorAppService _setorAppService;
        private readonly IEscalaAppService _escalaAppService;

        public FuncionarioEmpresasController(IFuncionarioEmpresaAppService funcionarioEmpresaAppService, IEmpresaAppService empresaAppService,
                                             IFuncionarioAppService funcionarioAppService, ICBOAppService cboAppService, ISetorAppService setorAppService,
                                             IEscalaAppService escalaAppService)
        {
            _funcionarioEmpresaAppService = funcionarioEmpresaAppService;
            _empresaAppService = empresaAppService;
            _funcionarioAppService = funcionarioAppService;
            _cboAppService = cboAppService;
            _setorAppService = setorAppService;
            _escalaAppService = escalaAppService;
        }
        // GET: FuncionarioEmpresas
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var funcionarioEmpresaViewModel = _funcionarioEmpresaAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "FuncionarioEmpresas";
            ViewBag.TotalRegistros = _funcionarioEmpresaAppService.ObterTotalRegistros(pesquisa);

            #region DDL Status
            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Vinculado à empresa", Value = "1" });
            ddlStatus.Add(new SelectListItem() { Text = "Desvinculado à empresa", Value = "2" });
            TempData["ddlStatus"] = ddlStatus;

            foreach (var item in funcionarioEmpresaViewModel)
            {
                item.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(funcionarioEmpresaViewModel);
        }

        // GET: FuncionarioEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioEmpresa = _funcionarioEmpresaAppService.ObterPorId(id.Value);
            if (funcionarioEmpresa == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Funcionario = (List<SelectListItem>)TempData["ddlStatus"];
            funcionarioEmpresa.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(funcionarioEmpresa.Status.ToString())).First().Text;

            return View(funcionarioEmpresa);
        }

        // GET: FuncionarioEmpresas/Create
        public ActionResult Create()
        {
            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Vinculado à empresa", Value = "1" });
            ddlStatus.Add(new SelectListItem() { Text = "Desvinculado à empresa", Value = "2" });
            TempData["ddlStatus"] = ddlStatus;

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
            ViewBag.CBOId = new SelectList(_cboAppService.ObterTodos(), "CBOId", "Nome");
            ViewBag.SetorId = new SelectList(_setorAppService.ObterTodos(), "SetorId", "Nome");
            ViewBag.EscalaId = new SelectList(_escalaAppService.ObterTodos(), "EscalaId", "Nome");

            var funcionarioEmpresaViewModel = new FuncionarioEmpresaViewModel();

            return View(funcionarioEmpresaViewModel);
        }

        // POST: FuncionarioEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_funcionarioEmpresaAppService.Adicionar(funcionarioEmpresaViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, ta fazendo bosta')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Vinculado à empresa", Value = "1" });
            ddlStatus.Add(new SelectListItem() { Text = "Desvinculado à empresa", Value = "2" });
            TempData["ddlStatus"] = ddlStatus;

            funcionarioEmpresaViewModel.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(funcionarioEmpresaViewModel.Status.ToString())).First().Text;

            return View(funcionarioEmpresaViewModel);
        }

        // GET: FuncionarioEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioEmpresa = _funcionarioAppService.ObterPorId(id.Value);
            if (funcionarioEmpresa == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Vinculado à empresa", Value = "1" });
            ddlStatus.Add(new SelectListItem() { Text = "Desvinculado à empresa", Value = "2" });
            TempData["ddlStatus"] = ddlStatus;

            funcionarioEmpresa.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(funcionarioEmpresa.Status.ToString())).First().Text;

            return View(funcionarioEmpresa);
        }

        // POST: FuncionarioEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioEmpresaViewModel funcionarioEmpresaViewModel)
        {
            if (!_funcionarioEmpresaAppService.Atualizar(funcionarioEmpresaViewModel))
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um funcionario com os mesmos dados já cadastrado')</SCRIPT>");
            }
            else
                return RedirectToAction("Index");

            return View(funcionarioEmpresaViewModel);
        }

        // GET: FuncionarioEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioEmpresa = _funcionarioEmpresaAppService.ObterPorId(id.Value);
            if (funcionarioEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioEmpresa);
        }

        // POST: FuncionarioEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_funcionarioEmpresaAppService.Excluir(id))
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
                _funcionarioEmpresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
