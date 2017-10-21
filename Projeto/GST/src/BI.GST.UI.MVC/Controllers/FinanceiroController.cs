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
        private readonly IFinanceiroParcelaAppService _financeiroParcelaAppService;

        public FinanceiroController(IFinanceiroAppService financeiroAppService, IFinanceiroParcelaAppService financeiroParcelaAppService)
        {
            _financeiroAppService = financeiroAppService;
            _financeiroParcelaAppService = financeiroParcelaAppService;
        }


        public ActionResult Parcela()
        {
            var parcela = new FinanceiroParcelaViewModel();
            return PartialView("_FinanceiroParcela", parcela);
        }

        // GET: Financeiro
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var financeiroViewModel = _financeiroAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "Financeiro";
            ViewBag.TotalRegistros = _financeiroAppService.ObterTotalRegistros(pesquisa);


            #region DDL Status
            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Pendente", Value = "0" });
            ddlStatus.Add(new SelectListItem() { Text = "Quitado", Value = "1" });
            TempData["ddlStatus"] = ddlStatus;

            foreach (var item in financeiroViewModel)
            {
                item.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
                item.OperacaoStatus = ddlOperacao.Where(e => e.Value.Trim().Equals(item.Operacao.ToString())).First().Text;
            }
            #endregion

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

            #region DDL Status

            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Pendente", Value = "0" });
            ddlStatus.Add(new SelectListItem() { Text = "Quitado", Value = "1" });
            TempData["ddlStatus"] = ddlStatus;

            financeiro.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(financeiro.Status.ToString())).First().Text;
            financeiro.OperacaoStatus = ddlOperacao.Where(e => e.Value.Trim().Equals(financeiro.Operacao.ToString())).First().Text;
            #endregion

            return View(financeiro);
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            #region DDL Status
            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Pendente", Value = "0" });
            ddlStatus.Add(new SelectListItem() { Text = "Quitado", Value = "1" });
            TempData["ddlStatus"] = ddlStatus;
            #endregion

            var financeiroViewModel = new FinanceiroViewModel();
            return View(financeiroViewModel);
        }

        // POST: Financeiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> financeiroParcelaViewModel)
        {
            if (ModelState.IsValid)
            {
                financeiroViewModel.Status = "0";
                var result = _financeiroAppService.Adicionar(financeiroViewModel, financeiroParcelaViewModel);

                if (result != "")
                {
                    TempData["Mensagem"] = result;

                }
                else
                    return RedirectToAction("Index");

                #region DDL Status
                List<SelectListItem> ddlOperacao = new List<SelectListItem>();
                ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
                ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
                TempData["ddlOperacao"] = ddlOperacao;

                List<SelectListItem> ddlStatus = new List<SelectListItem>();
                ddlStatus.Add(new SelectListItem() { Text = "Pendente", Value = "0" });
                ddlStatus.Add(new SelectListItem() { Text = "Quitado", Value = "1" });
                TempData["ddlStatus"] = ddlStatus;

                financeiroViewModel.OperacaoStatus = ddlOperacao.Where(e => e.Value.Trim().Equals(financeiroViewModel.Operacao.ToString())).First().Text;
                financeiroViewModel.StatusNome = ddlStatus.Where(e => e.Value.Trim().Equals(financeiroViewModel.Status.ToString())).First().Text;
                #endregion

                financeiroViewModel.Parcelas = financeiroParcelaViewModel;
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

            #region ddlStatus
            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            var ddlOperacao2 = (List<SelectListItem>)TempData["ddlOperacao"];
            financeiro.OperacaoStatus = ddlOperacao2.Where(e => e.Value.Trim().Equals(financeiro.Operacao.ToString())).First().Text;
            #endregion

            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FinanceiroViewModel financeiroViewModel, List<FinanceiroParcelaViewModel> financeiroParcelaViewModel)
        {
            var result = _financeiroAppService.Atualizar(financeiroViewModel, financeiroParcelaViewModel);

            if (result != "")
            {
                TempData["Mensagem"] = result;

            }
            else
                return RedirectToAction("Index");

            #region ddlStatus
            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            financeiroViewModel.OperacaoStatus = ddlOperacao.Where(e => e.Value.Trim().Equals(financeiroViewModel.Operacao.ToString())).First().Text;
            #endregion

            financeiroViewModel.Parcelas = financeiroParcelaViewModel;
           
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

            List<SelectListItem> ddlOperacao = new List<SelectListItem>();
            ddlOperacao.Add(new SelectListItem() { Text = "A Pagar", Value = "0" });
            ddlOperacao.Add(new SelectListItem() { Text = "A Receber", Value = "1" });
            TempData["ddlOperacao"] = ddlOperacao;

            List<SelectListItem> ddlStatus = new List<SelectListItem>();
            ddlStatus.Add(new SelectListItem() { Text = "Pendente", Value = "0" });
            ddlStatus.Add(new SelectListItem() { Text = "Quitado", Value = "1" });
            TempData["ddlStatus"] = ddlStatus;

            financeiro.OperacaoStatus = ddlOperacao.Where(e => e.Value.Trim().Equals(financeiro.Operacao.ToString())).First().Text;
            financeiro.StatusNome = ddlOperacao.Where(e => e.Value.Trim().Equals(financeiro.Status.ToString())).First().Text;

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
