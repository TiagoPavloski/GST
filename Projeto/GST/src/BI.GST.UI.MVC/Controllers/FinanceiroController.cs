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
    public class FinanceiroController : Controller
    {
        private readonly IFinanceiroAppService _financeiroAppService;

        public FinanceiroController(IFinanceiroAppService financeiroAppService)
        {
            _financeiroAppService = financeiroAppService;
        }

        // GET: Financeiro
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var financeiroViewModel = _financeiroAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Financeiro";
            ViewBag.TotalRegistros = _financeiroAppService.ObterTotalRegistros(pesquisa);

            return View(financeiroViewModel);
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var financeiro = _financeiroAppService.ObterContasPorId(id.Value);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FinanceiroViewModel financeiroViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_financeiroAppService.Adicionar(financeiroViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um título financeiro com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(financeiroViewModel);
        }

        // GET: Financeiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var financeiro = _financeiroAppService.ObterContasPorId(id.Value);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FinanceiroViewModel financeiroViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_financeiroAppService.Atualizar(financeiroViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um título Financeiro com os mesmos dados já cadastrado')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(financeiroViewModel);
        }

        // GET: Financeiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var financeiro = _financeiroAppService.ObterContasPorId(id.Value);
            if (financeiro == null)
            {
                return HttpNotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_financeiroAppService.Excluir(id))
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
                _financeiroAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
