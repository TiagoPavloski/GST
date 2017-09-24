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
    public class AgenteAcidentesController : Controller
    {
        private readonly IAgenteAcidenteAppService _agenteAcidenteAppService;

        public AgenteAcidentesController(IAgenteAcidenteAppService agenteAcidenteAppService)
        {
            _agenteAcidenteAppService = agenteAcidenteAppService;
        }

        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteAcidenteViewModel = _agenteAcidenteAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteAcidentes";
            ViewBag.TotalRegistros = _agenteAcidenteAppService.ObterTotalRegistros(pesquisa);
            return View(agenteAcidenteViewModel);
        }

        // GET: AgenteAcidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteAcidenteViewModel agenteAcidente = _agenteAcidenteAppService.ObterPorId(id.Value);
            if (agenteAcidente == null)
            {
                return HttpNotFound();
            }
            return View(agenteAcidente);
        }

        // GET: AgenteAcidentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: agenteAcidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteAcidenteViewModel agenteAcidenteViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteAcidenteAppService.Adicionar(agenteAcidenteViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Acidente com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteAcidenteViewModel);
        }

        // GET: AgenteAcidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteAcidente = _agenteAcidenteAppService.ObterPorId(id.Value);
            if (agenteAcidente == null)
            {
                return HttpNotFound();
            }
            return View(agenteAcidente);
        }

        // POST: AgenteAcidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteAcidenteViewModel agenteAcidenteViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteAcidenteAppService.Atualizar(agenteAcidenteViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agente de Acidente com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteAcidenteViewModel);
        }


        // GET: AgenteAcidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteAcidenteViewModel agenteAcidente = _agenteAcidenteAppService.ObterPorId(id.Value);
            if (agenteAcidente == null)
            {
                return HttpNotFound();
            }
            return View(agenteAcidente);
        }

        // POST: AgenteAcidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteAcidenteAppService.Excluir(id))
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
                _agenteAcidenteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
