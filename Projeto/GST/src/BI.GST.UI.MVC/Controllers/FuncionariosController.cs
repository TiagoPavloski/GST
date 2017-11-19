using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System.Collections.Generic;
using System;

namespace BI.GST.UI.MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ICBOAppService _cboAppService;
        private readonly ISetorAppService _setorAppService;
        private readonly IEscalaAppService _escalaAppService;
        private int usuarioId;

        public FuncionariosController(IFuncionarioAppService funcionarioAppService, IEmpresaAppService empresaAppService,
            ICBOAppService cboAppService, ISetorAppService setorAppService, IEscalaAppService escalaAppService)
        {
            _funcionarioAppService = funcionarioAppService;
            _empresaAppService = empresaAppService;
            _cboAppService = cboAppService;
            _setorAppService = setorAppService;
            _escalaAppService = escalaAppService;
        }

        public JsonResult Setores(int idEmpresa)
        {
            return Json(_empresaAppService.ObterPorId(idEmpresa).Setores, JsonRequestBehavior.AllowGet);
        }

        // GET: Funcionarios
        public ActionResult Index(string pesquisa, int page = 0)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            usuarioId = (int)Session["usuarioId"];
            var funcionarioViewModel = _funcionarioAppService.ObterGrid(pesquisa,page, usuarioId);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Funcionarios";
            ViewBag.TotalRegistros = _funcionarioAppService.ObterTotalRegistros(pesquisa, usuarioId);

            #region DDL Status
            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            foreach (var item in funcionarioViewModel)
            {
                item.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionario = _funcionarioAppService.ObterPorId(id.Value);
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            funcionario.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(funcionario.Status.ToString())).First().Text;

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            List<SelectListItem> muamba = new List<SelectListItem>();
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.CBOId = new SelectList(_cboAppService.ObterTodos(), "CBOId", "Nome");
            ViewBag.SetorId = muamba;
            ViewBag.EscalaId = new SelectList(_escalaAppService.ObterTodos(), "EscalaId", "Nome");

            var funcionarioViewModel = new FuncionarioViewModel();
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel funcionarioViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            usuarioId = (int)Session["usuarioId"];
            funcionarioViewModel.UsuarioId = usuarioId;
            if (ModelState.IsValid)
            {
                if (!_funcionarioAppService.Adicionar(funcionarioViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um funcionario com o mesmo CPF já cadastrado";
                }
                else
                    return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.CBOId = new SelectList(_cboAppService.ObterTodos(), "CBOId", "Nome");
            ViewBag.SetorId = new SelectList(null);
            ViewBag.EscalaId = new SelectList(_escalaAppService.ObterTodos(), "EscalaId", "Nome");

            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            funcionarioViewModel.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(funcionarioViewModel.Status.ToString())).First().Text;

            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionario = _funcionarioAppService.ObterPorId(id.Value);
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia", funcionario.EmpresaId);
            ViewBag.CBOId = new SelectList(_cboAppService.ObterTodos(), "CBOId", "Nome", funcionario.CBOId);
            ViewBag.SetorId = new SelectList(_setorAppService.ObterTodos(), "SetorId", "Nome", funcionario.SetorId);
            ViewBag.EscalaId = new SelectList(_escalaAppService.ObterTodos(), "EscalaId", "Nome", funcionario.EscalaId);

            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            funcionario.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(funcionario.Status.ToString())).First().Text;



            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioViewModel funcionarioViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaId", "NomeFantasia");
            ViewBag.CBOId = new SelectList(_cboAppService.ObterTodos(), "CBOId", "Nome");
            ViewBag.SetorId = new SelectList(_setorAppService.ObterTodos(), "SetorId", "Nome");
            ViewBag.EscalaId = new SelectList(_escalaAppService.ObterTodos(), "EscalaId", "Nome");

            if (!_funcionarioAppService.Atualizar(funcionarioViewModel))
            {
                TempData["Mensagem"] = "Atenção, há um funcionario com o mesmo CPF já cadastrado";
            }
            else
                return RedirectToAction("Index");
            //}
            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionario = _funcionarioAppService.ObterPorId(id.Value);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_funcionarioAppService.Excluir(id))
            {
                TempData["Mensagem"] = "Erro na operação, atualize a pagina";
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
                _funcionarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
