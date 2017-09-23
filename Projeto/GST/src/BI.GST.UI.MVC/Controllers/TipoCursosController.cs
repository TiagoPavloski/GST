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
    public class TipoCursosController : Controller
    {
        private readonly ITipoCursoAppService _tipoCursoAppService;

        public TipoCursosController(ITipoCursoAppService tipoCursoAppService)
        {
            _tipoCursoAppService = tipoCursoAppService;
        }
        // GET: TipoCursos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var tipoCursoViewModel = _tipoCursoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "TipoCursos";
            ViewBag.TotalRegistros = _tipoCursoAppService.ObterTotalRegistros(pesquisa);
            return View(tipoCursoViewModel);
        }

        // GET: TipoCursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoCurso = _tipoCursoAppService.ObterPorId(id.Value);
            if (tipoCurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoCurso);
        }

        // GET: TipoCursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCursoViewModel tipoCursoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_tipoCursoAppService.Adicionar(tipoCursoViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(tipoCursoViewModel);
        }

        // GET: TipoCursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoCurso = _tipoCursoAppService.ObterPorId(id.Value);
            if (tipoCurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoCurso);
        }

        // POST: TipoCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoCursoViewModel tipoCursoViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_tipoCursoAppService.Atualizar(tipoCursoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Curso com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(tipoCursoViewModel);
        }

        // GET: TipoCursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoCurso = _tipoCursoAppService.ObterPorId(id.Value);
            if (tipoCurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoCurso);
        }

        // POST: TipoCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_tipoCursoAppService.Excluir(id))
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
                _tipoCursoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
