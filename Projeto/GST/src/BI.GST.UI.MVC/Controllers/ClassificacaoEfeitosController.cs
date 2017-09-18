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
    public class ClassificacaoEfeitosController : Controller
    {
        private readonly IClassificacaoEfeitoAppService _classificacaoEfeitoAppService;

        public ClassificacaoEfeitosController(IClassificacaoEfeitoAppService classificacaoEfeitoAppService)
        {
            _classificacaoEfeitoAppService = classificacaoEfeitoAppService;
        }

        // GET: classificacaoEfeitos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var classificacaoEfeitoViewModel = _classificacaoEfeitoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "classificacaoEfeitos";
            ViewBag.TotalRegistros = _classificacaoEfeitoAppService.ObterTotalRegistros(pesquisa);
            return View(classificacaoEfeitoViewModel);
        }

        // GET: classificacaoEfeitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassificacaoEfeitoViewModel classificacaoEfeito = _classificacaoEfeitoAppService.ObterPorId(id.Value);
            if (classificacaoEfeito == null)
            {
                return HttpNotFound();
            }
            return View(classificacaoEfeito);
        }

        // GET: classificacaoEfeitos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: classificacaoEfeitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_classificacaoEfeitoAppService.Adicionar(classificacaoEfeitoViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um classificacaoEfeito com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(classificacaoEfeitoViewModel);
        }

        // GET: classificacaoEfeitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classificacaoEfeito = _classificacaoEfeitoAppService.ObterPorId(id.Value);
            if (classificacaoEfeito == null)
            {
                return HttpNotFound();
            }
            return View(classificacaoEfeito);
        }

        // POST: classificacaoEfeitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassificacaoEfeitoViewModel classificacaoEfeitoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_classificacaoEfeitoAppService.Atualizar(classificacaoEfeitoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(classificacaoEfeitoViewModel);
        }

        // GET: classificacaoEfeitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassificacaoEfeitoViewModel classificacaoEfeito = _classificacaoEfeitoAppService.ObterPorId(id.Value);
            if (classificacaoEfeito == null)
            {
                return HttpNotFound();
            }
            return View(classificacaoEfeito);
        }

        // POST: classificacaoEfeitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_classificacaoEfeitoAppService.Excluir(id))
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
                _classificacaoEfeitoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
