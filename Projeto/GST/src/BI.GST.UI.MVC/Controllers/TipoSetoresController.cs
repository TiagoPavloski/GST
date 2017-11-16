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
    public class TipoSetoresController : Controller
    {
        private readonly ITipoSetorAppService _tipoSetorAppService;

        public TipoSetoresController(ITipoSetorAppService tipoSetorAppService)
        {
            _tipoSetorAppService = tipoSetorAppService;
        }
        // GET: TipoSetores
        public ActionResult Index(string pesquisa, int page = 0)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            var tipoSetorViewModel = _tipoSetorAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "TipoSetors";
            ViewBag.TotalRegistros = _tipoSetorAppService.ObterTotalRegistros(pesquisa);
            return View(tipoSetorViewModel);
        }

        // GET: TipoSetores/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSetor = _tipoSetorAppService.ObterPorId(id.Value);
            if (tipoSetor == null)
            {
                return HttpNotFound();
            }
            return View(tipoSetor);
        }

        // GET: TipoSetores/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            return View();
        }

        // POST: TipoSetores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoSetorViewModel tipoSetorViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_tipoSetorAppService.Adicionar(tipoSetorViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Tipo Setor com os mesmos dados";
                }
                else
                    return RedirectToAction("Index");
            }
            return View(tipoSetorViewModel);
        }

        // GET: TipoSetores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSetor = _tipoSetorAppService.ObterPorId(id.Value);
            if (tipoSetor == null)
            {
                return HttpNotFound();
            }
            return View(tipoSetor);
        }

        // POST: TipoSetores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoSetorViewModel tipoSetorViewModel)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (ModelState.IsValid)
            {
                if (!_tipoSetorAppService.Atualizar(tipoSetorViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um tipo de Setor com os mesmos dados já cadastrada')</SCRIPT>";
                }
                else
                    return RedirectToAction("Index");
            }
            return View(tipoSetorViewModel);
        }

        // GET: TipoSetores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoSetor = _tipoSetorAppService.ObterPorId(id.Value);
            if (tipoSetor == null)
            {
                return HttpNotFound();
            }
            return View(tipoSetor);
        }

        // POST: TipoSetores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
   if (Session["usuario"] == null)
                return RedirectToAction("Login", "Usuarios");
            var response = _tipoSetorAppService.Excluir(id);
            if(response.Equals("")){
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Mensagem"] = response;
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tipoSetorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
