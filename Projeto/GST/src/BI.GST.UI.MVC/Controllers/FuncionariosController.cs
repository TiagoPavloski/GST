using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BI.GST.Domain.Entities;
using BI.GST.Application.Interface;
using BI.GST.Application.ViewModels;
using System.Collections.Generic;

namespace BI.GST.UI.MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public FuncionariosController(IFuncionarioAppService funcionarioAppService, IEmpresaAppService empresaAppService)
        {
            _funcionarioAppService = funcionarioAppService;
            _empresaAppService = empresaAppService;
        }

        // GET: Funcionarios
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var funcionarioViewModel = _funcionarioAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Funcionarios";
            ViewBag.TotalRegistros = _funcionarioAppService.ObterTotalRegistros(pesquisa);

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionario = _funcionarioAppService.ObterPorId(id.Value);
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Funcionario = (List<SelectListItem>)TempData["ddlStatus_Funcionarios"];
            funcionario.StatusNome = ddlStatus_Funcionario.Where(e => e.Value.Trim().Equals(funcionario.Status.ToString())).First().Text;

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            List<SelectListItem> ddlStatus_Funcionario = new List<SelectListItem>();
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Funcionario.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_Funcionarios"] = ddlStatus_Funcionario;

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObterTodos(), "EmpresaID", "NomeFantasia");

            var funcionarioViewModel = new FuncionarioViewModel();
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel funcionarioViewModel, int[]ExameId, int[]VacinaId, int[]CursoId)
        {
            if (ModelState.IsValid)
            {
                if (!_funcionarioAppService.Adicionar(funcionarioViewModel, ExameId, VacinaId, CursoId))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um funcionario com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

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

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioViewModel funcionarioViewModel, int[] ExameId, int[] VacinaId, int[] CursoId)
        {
            if (!_funcionarioAppService.Atualizar(funcionarioViewModel, ExameId, VacinaId, CursoId))
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um funcionario com os mesmos dados já cadastrado')</SCRIPT>");
            }
            else
                return RedirectToAction("Index");
            //}
            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
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
                _funcionarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
