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
        private readonly IClassificacaoEfeitoAppService _classificacaoEfeitoAppService;

        public AgenteQuimicosController(IAgenteQuimicoAppService agenteQuimicoAppService, IClassificacaoEfeitoAppService clasificacaoEfeitoAppService)
        {
            _agenteQuimicoAppService = agenteQuimicoAppService;
            _classificacaoEfeitoAppService = clasificacaoEfeitoAppService;
        }

        // GET: agenteQuimicos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
            var agenteQuimicoViewModel = new AgenteQuimicoViewModel();
            return View(agenteQuimicoViewModel);
        }

        // POST: agenteQuimicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_agenteQuimicoAppService.Adicionar(agenteQuimicoViewModel))
                {
                    ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao");
                    TempData["Mensagem"] = "Atenção, há um Agente Quimico com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteQuimico com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteQuimicoViewModel);
        }

        // GET: agenteQuimicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteQuimicoViewModel = _agenteQuimicoAppService.ObterPorId(id.Value);
            if (agenteQuimicoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteQuimicoViewModel.ClassificacaoEfeitoId);
            return View(agenteQuimicoViewModel);
        }

        // POST: agenteQuimicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteQuimicoViewModel agenteQuimicoViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_agenteQuimicoAppService.Atualizar(agenteQuimicoViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Agente Químico com os mesmos dados já cadastrado";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.ClassificacaoEfeitoId = new SelectList(_classificacaoEfeitoAppService.ObterTodos(), "ClassificacaoEfeitoId", "Classificacao", agenteQuimicoViewModel.ClassificacaoEfeitoId);
            return View(agenteQuimicoViewModel);
        }

        // GET: agenteQuimicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

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
