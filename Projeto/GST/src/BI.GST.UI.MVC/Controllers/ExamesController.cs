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
    public class ExamesController : Controller
    {
        private readonly IExameAppService _exameAppService;
        private readonly ITipoExameAppService _tipoExameAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;

        public ExamesController(IExameAppService exameAppService, ITipoExameAppService tipoExameAppService, IFuncionarioAppService funcionarioAppService)
        {
            _exameAppService = exameAppService;
            _tipoExameAppService = tipoExameAppService;
            _funcionarioAppService = funcionarioAppService;
        }

        // GET: Exames
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var examesViewModel = _exameAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Exames";
            ViewBag.TotalRegistros = _exameAppService.ObterTotalRegistros(pesquisa);

            #region DDL Status
            List<SelectListItem> ddlStatus_Exames = new List<SelectListItem>();
            ddlStatus_Exames.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_Exames.Add(new SelectListItem() { Text = "Vencido", Value = "2" });
            TempData["ddlStatus_Exames"] = ddlStatus_Exames;

            foreach (var item in examesViewModel)
            {
                item.StatusNome = ddlStatus_Exames.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(examesViewModel);
        }

        // GET: Exames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exame = _exameAppService.ObterPorId(id.Value);
            if (exame == null)
            {
                return HttpNotFound();
            }
            var ddlStatus_Exames = (List<SelectListItem>)TempData["ddlStatus_Exames"];
            exame.StatusNome = ddlStatus_Exames.Where(e => e.Value.Trim().Equals(exame.Status.ToString())).First().Text;
            return View(exame);
        }

        // GET: Exames/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome");
            ViewBag.TipoExameId = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome");
            return View();
        }

        // POST: Exames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExameViewModel exameViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_exameAppService.Adicionar(exameViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Exame com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", exameViewModel.FuncionarioId);
            ViewBag.TipoExameId = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome", exameViewModel.TipoExameId);
            return View(exameViewModel);
        }

        // GET: Exames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exame = _exameAppService.ObterPorId(id.Value);
            if (exame == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioId = new SelectList(_funcionarioAppService.ObterTodos(), "FuncionarioId", "Nome", exame.FuncionarioId);
            ViewBag.TipoExameId = new SelectList(_tipoExameAppService.ObterTodos(), "TipoExameId", "Nome", exame.TipoExameId);
            return View(exame);
        }

        // POST: Exames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExameViewModel exameViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_exameAppService.Atualizar(exameViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Exame com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(exameViewModel);
        }

        // GET: Exames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exame = _exameAppService.ObterPorId(id.Value);
            if (exame == null)
            {
                return HttpNotFound();
            }
            var ddlStatus_Exames = (List<SelectListItem>)TempData["ddlStatus_Exames"];
            exame.StatusNome = ddlStatus_Exames.Where(e => e.Value.Trim().Equals(exame.Status.ToString())).First().Text;
            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_exameAppService.Excluir(id))
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
                _exameAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
