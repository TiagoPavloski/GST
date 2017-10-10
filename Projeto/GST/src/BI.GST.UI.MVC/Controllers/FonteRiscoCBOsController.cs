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
    public class FonteRiscoCBOsController : Controller
    {
        private readonly IFonteRiscoCBOAppService _fonteRiscoCBOAppService;

        public FonteRiscoCBOsController(IFonteRiscoCBOAppService fonteRiscoCBOAppService)
        {
            _fonteRiscoCBOAppService = fonteRiscoCBOAppService;
        }

        // GET: FonteRiscoCBOs
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var fonteRiscoViewModel = _fonteRiscoCBOAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "fonteRiscoCBOs";
            ViewBag.TotalRegistros = _fonteRiscoCBOAppService.ObterTotalRegistros(pesquisa);


            #region DDL Status
            List<SelectListItem> ddlStatus_FonteRisco = new List<SelectListItem>();
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_FonteRisco"] = ddlStatus_FonteRisco;

            foreach (var item in fonteRiscoViewModel)
            {
                item.StatusNome = ddlStatus_FonteRisco.Where(e => e.Value.Trim().Equals(item.Status.ToString())).First().Text;
            }
            #endregion

            return View(fonteRiscoViewModel);
        }

        // GET: FonteRiscoCBOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fonteRiscoCBO = _fonteRiscoCBOAppService.ObterPorId(id.Value);
            if (fonteRiscoCBO == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_fonteRisco = (List<SelectListItem>)TempData["ddlStatus_FonteRisco"];
            fonteRiscoCBO.StatusNome = ddlStatus_fonteRisco.Where(e => e.Value.Trim().Equals(fonteRiscoCBO.Status.ToString())).First().Text;

            return View(fonteRiscoCBO);
        }

        // GET: FonteRiscoCBOs/Create
        public ActionResult Create()
        {
            List<SelectListItem> ddlStatus_FonteRisco = new List<SelectListItem>();
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_FonteRisco"] = ddlStatus_FonteRisco;

           return View();
        }

        // POST: FonteRiscoCBOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FonteRiscoCBOViewModel fonteRiscoCBOViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_fonteRiscoCBOAppService.Adicionar(fonteRiscoCBOViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há uma fonte de risco com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }

            List<SelectListItem> ddlStatus_FonteRisco = new List<SelectListItem>();
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_FonteRisco"] = ddlStatus_FonteRisco;

            fonteRiscoCBOViewModel.StatusNome = ddlStatus_FonteRisco.Where(e => e.Value.Trim().Equals(fonteRiscoCBOViewModel.Status.ToString())).First().Text;

            return View(fonteRiscoCBOViewModel);
        }

        // GET: FonteRiscoCBOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fonteRisco = _fonteRiscoCBOAppService.ObterPorId(id.Value);
            if (fonteRisco == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ddlStatus_FonteRisco = new List<SelectListItem>();
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Ativo", Value = "1" });
            ddlStatus_FonteRisco.Add(new SelectListItem() { Text = "Desativado", Value = "2" });
            TempData["ddlStatus_FonteRisco"] = ddlStatus_FonteRisco;

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_FonteRisco"];
            fonteRisco.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(fonteRisco.Status.ToString())).First().Text;

            return View(fonteRisco);
        }

        // POST: FonteRiscoCBOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FonteRiscoCBOViewModel fonteRiscoCBOViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_fonteRiscoCBOAppService.Atualizar(fonteRiscoCBOViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há uma fonte de risco com o mesmo nome!')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(fonteRiscoCBOViewModel);
        }

        // GET: FonteRiscoCBOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fonteRisco = _fonteRiscoCBOAppService.ObterPorId(id.Value);
            if (fonteRisco == null)
            {
                return HttpNotFound();
            }

            var ddlStatus_Riscos = (List<SelectListItem>)TempData["ddlStatus_FonteRisco"];
            fonteRisco.StatusNome = ddlStatus_Riscos.Where(e => e.Value.Trim().Equals(fonteRisco.Status.ToString())).First().Text;
            return View(fonteRisco);
        }

        // POST: FonteRiscoCBOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_fonteRiscoCBOAppService.Excluir(id))
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
                _fonteRiscoCBOAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
