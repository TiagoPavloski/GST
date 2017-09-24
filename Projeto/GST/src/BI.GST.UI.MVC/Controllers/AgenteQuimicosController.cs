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
    public class AgenteQuimicosController : Controller
    {
        private readonly IAgenteQuimicoAppService _agenteQuimicoAppService;

        public AgenteQuimicosController(IAgenteQuimicoAppService agenteQuimicoAppService)
        {
            _agenteQuimicoAppService = agenteQuimicoAppService;
        }

        // GET: agenteQuimicos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteQuimicoViewModel = _agenteQuimicoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "agenteQuimicos";
            ViewBag.TotalRegistros = _agenteQuimicoAppService.ObterTotalRegistros(pesquisa);
            return View(agenteQuimicoViewModel);
        }

        // GET: agenteQuimicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteQuimicoViewModel agenteQuimico = _agenteQuimicoAppService.ObterPorId(id.Value);
            if (agenteQuimico == null)
            {
                return HttpNotFound();
            }
            return View(agenteQuimico);
        }

        // GET: agenteQuimicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: agenteQuimicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteQuimicoAppService.Adicionar(agenteQuimicoViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteQuimico com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteQuimicoViewModel);
        }

        // GET: agenteQuimicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteQuimico = _agenteQuimicoAppService.ObterPorId(id.Value);
            if (agenteQuimico == null)
            {
                return HttpNotFound();
            }
            return View(agenteQuimico);
        }

        // POST: agenteQuimicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteQuimicoAppService.Atualizar(agenteQuimicoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteQuimicoViewModel);
        }

        // GET: agenteQuimicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteQuimicoViewModel agenteQuimico = _agenteQuimicoAppService.ObterPorId(id.Value);
            if (agenteQuimico == null)
            {
                return HttpNotFound();
            }
            return View(agenteQuimico);
        }

        // POST: agenteQuimicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteQuimicoAppService.Excluir(id))
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
                _agenteQuimicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
