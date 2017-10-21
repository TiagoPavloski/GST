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
    public class EPIsController : Controller
    {
        private readonly IEPIAppService _epiAppService;

        public EPIsController(IEPIAppService epiAppService)
        {
            _epiAppService = epiAppService;
        }

        // GET: EPIs
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var epiViewModel = _epiAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "EPIs";
            ViewBag.TotalRegistros = _epiAppService.ObterTotalRegistros(pesquisa);


            #region DDL Status
            List<SelectListItem> ddlStatusEPI = new List<SelectListItem>();
            ddlStatusEPI.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusEPI.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatusEPI"] = ddlStatusEPI;

            foreach (var item in epiViewModel)
            {
                item.StatusNome = ddlStatusEPI.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion
            return View(epiViewModel);
        }

        // GET: EPIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var epi = _epiAppService.ObterPorId(id.Value);
            if (epi == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatusEPI = new List<SelectListItem>();
            ddlStatusEPI.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusEPI.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatusEPI"] = ddlStatusEPI;

            var ddlStatus_EPI = (List<SelectListItem>)TempData["ddlStatusEPI"];
            epi.StatusNome = ddlStatus_EPI.Where(e => e.Value.Trim().Equals(epi.Status.ToString())).First().Text;

            return View(epi);
        }

        // GET: EPIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EPIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EPIViewModel epiViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_epiAppService.Adicionar(epiViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            List<SelectListItem> ddlStatus_EPI = new List<SelectListItem>();
            ddlStatus_EPI.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_EPI.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatusEPI"] = ddlStatus_EPI;

            epiViewModel.StatusNome = ddlStatus_EPI.Where(e => e.Value.Trim().Equals(epiViewModel.Status.ToString())).First().Text;

            return View(epiViewModel);
        }

        // GET: EPIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var epi = _epiAppService.ObterPorId(id.Value);
            if (epi == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus_EPI = new List<SelectListItem>();
            ddlStatus_EPI.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_EPI.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatusEPI"] = ddlStatus_EPI;

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatusEPI"];
            epi.StatusNome = ddlStatus_EPI.Where(e => e.Value.Trim().Equals(epi.Status.ToString())).First().Text;

            return View(epi);
        }

        // POST: EPIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EPIViewModel epiViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_epiAppService.Atualizar(epiViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Causador com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(epiViewModel);
        }

        // GET: EPIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var epi = _epiAppService.ObterPorId(id.Value);
            if (epi == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatusEPI = new List<SelectListItem>();
            ddlStatusEPI.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatusEPI.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatusEPI"] = ddlStatusEPI;

            var ddlStatus_EPI = (List<SelectListItem>)TempData["ddlStatusEPI"];
            epi.StatusNome = ddlStatus_EPI.Where(e => e.Value.Trim().Equals(epi.Status.ToString())).First().Text;
            return View(epi);
        }

        // POST: EPIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_epiAppService.Excluir(id))
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
                _epiAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
