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
    public class MeioPropagacoesController : Controller
    {
        private readonly IMeioPropagacaoAppService _meioPropagacaoAppService;

        public MeioPropagacoesController(IMeioPropagacaoAppService meioPropagacaoAppService)
        {
            _meioPropagacaoAppService = meioPropagacaoAppService;
        }

        // GET: meioPropagacaos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var meioPropagacaoViewModel = _meioPropagacaoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "meioPropagacaos";
            ViewBag.TotalRegistros = _meioPropagacaoAppService.ObterTotalRegistros(pesquisa);
            return View(meioPropagacaoViewModel);
        }

        // GET: meioPropagacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeioPropagacaoViewModel meioPropagacao = _meioPropagacaoAppService.ObterPorId(id.Value);
            if (meioPropagacao == null)
            {
                return HttpNotFound();
            }
            return View(meioPropagacao);
        }

        // GET: meioPropagacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: meioPropagacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeioPropagacaoViewModel meioPropagacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_meioPropagacaoAppService.Adicionar(meioPropagacaoViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um meioPropagacao com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(meioPropagacaoViewModel);
        }

        // GET: meioPropagacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var meioPropagacao = _meioPropagacaoAppService.ObterPorId(id.Value);
            if (meioPropagacao == null)
            {
                return HttpNotFound();
            }
            return View(meioPropagacao);
        }

        // POST: meioPropagacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MeioPropagacaoViewModel meioPropagacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_meioPropagacaoAppService.Atualizar(meioPropagacaoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonômico com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(meioPropagacaoViewModel);
        }

        // GET: meioPropagacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeioPropagacaoViewModel meioPropagacao = _meioPropagacaoAppService.ObterPorId(id.Value);
            if (meioPropagacao == null)
            {
                return HttpNotFound();
            }
            return View(meioPropagacao);
        }

        // POST: meioPropagacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_meioPropagacaoAppService.Excluir(id))
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
                _meioPropagacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
