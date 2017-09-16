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
    public class AgenteErgonomicosController : Controller
    {
        private readonly IAgenteErgonomicoAppService _agenteErgonomicoAppService;

        public AgenteErgonomicosController(IAgenteErgonomicoAppService agenteErgonomicoAppService)
        {
            _agenteErgonomicoAppService = agenteErgonomicoAppService;
        }

        // GET: AgenteErgonomicos
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteErgonomicoViewModel = _agenteErgonomicoAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "AgenteErgonomicos";
            ViewBag.TotalRegistros = _agenteErgonomicoAppService.ObterTotalRegistros(pesquisa);
            return View(agenteErgonomicoViewModel);
        }

        // GET: AgenteErgonomicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteErgonomicoViewModel agenteErgonomico = _agenteErgonomicoAppService.ObterPorId(id.Value);
            if (agenteErgonomico == null)
            {
                return HttpNotFound();
            }
            return View(agenteErgonomico);
        }

        // GET: AgenteErgonomicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenteErgonomicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteErgonomicoViewModel agenteErgonomicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteErgonomicoAppService.Adicionar(agenteErgonomicoViewModel))
                {
                    //TempData["Mensagem"] = "Atenção, há um Tipo Curso com os mesmos dados";
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um agenteErgonomico com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteErgonomicoViewModel);
        }

        // GET: AgenteErgonomicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteErgonomico = _agenteErgonomicoAppService.ObterPorId(id.Value);
            if (agenteErgonomico == null)
            {
                return HttpNotFound();
            }
            return View(agenteErgonomico);
        }

        // POST: AgenteErgonomicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AgenteErgonomicoViewModel agenteErgonomicoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteErgonomicoAppService.Atualizar(agenteErgonomicoViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipo de Curso com os mesmos dados já cadastrada')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteErgonomicoViewModel);
        }

        // GET: AgenteErgonomicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteErgonomicoViewModel agenteErgonomico = _agenteErgonomicoAppService.ObterPorId(id.Value);
            if (agenteErgonomico == null)
            {
                return HttpNotFound();
            }
            return View(agenteErgonomico);
        }

        // POST: AgenteErgonomicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteErgonomicoAppService.Excluir(id))
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
                _agenteErgonomicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
