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
    public class SetoresController : Controller
    {
        private readonly ISetorAppService _setorAppService;

        public SetoresController(ISetorAppService setorAppService)
        {
            _setorAppService = setorAppService;
        }

        // GET: setors
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var setorViewModel = _setorAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "setors";
            ViewBag.TotalRegistros = _setorAppService.ObterTotalRegistros(pesquisa);
            return View(setorViewModel);
        }

        // GET: setors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorViewModel setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // GET: setors/Create
        public ActionResult Create(int? empresaId)
        {
            SetorViewModel setor = new SetorViewModel();
            EmpresaViewModel empresa = new EmpresaViewModel();
            setor.Empresas.Add(empresa);
            return View(setor);
        }

        // POST: setors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel setorViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_setorAppService.Adicionar(setorViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um setor com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(setorViewModel);
        }

        // GET: setors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: setors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorViewModel setorViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_setorAppService.Atualizar(setorViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(setorViewModel);
        }

        // GET: setors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SetorViewModel setor = _setorAppService.ObterPorId(id.Value);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: setors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_setorAppService.Excluir(id))
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
                _setorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
