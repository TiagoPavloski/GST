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
    public class AgenteAmbientalController : Controller
    {
        private readonly IAgenteAmbientalAppService _agenteAmbientalAppService;

        public AgenteAmbientalController(IAgenteAmbientalAppService agenteAmbientalAppService)
        {
            _agenteAmbientalAppService = agenteAmbientalAppService;
        }

        // GET: AgenteAmbiental
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var agenteAmbientalViewModel = _agenteAmbientalAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "AgenteAmbiental";
            ViewBag.TotalRegistros = _agenteAmbientalAppService.ObterTotalRegistros(pesquisa);

            return View(agenteAmbientalViewModel);
        }

        // GET: AgenteAmbiental/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteAmbiental = _agenteAmbientalAppService.ObterPorId(id.Value);
            if (agenteAmbiental == null)
            {
                return HttpNotFound();
            }
            return View(agenteAmbiental);
        }

        // GET: AgenteAmbiental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenteAmbiental/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenteAmbientalViewModel agenteAmbientalViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_agenteAmbientalAppService.Adicionar(agenteAmbientalViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Agente Ambiental com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um tipoCurso com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteAmbientalViewModel);
        }

        // GET: AgenteAmbiental/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteAmbiental = _agenteAmbientalAppService.ObterPorId(id.Value);
            if (agenteAmbiental == null)
            {
                return HttpNotFound();
            }
            return View(agenteAmbiental);
        }

        // POST: AgenteAmbiental/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgenteAmbientalViewModel agenteAmbientalViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_agenteAmbientalAppService.Atualizar(agenteAmbientalViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Agente Ambiental com os mesmos dados já cadastrado')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(agenteAmbientalViewModel);
        }

        // GET: AgenteAmbiental/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteAmbiental = _agenteAmbientalAppService.ObterPorId(id.Value);
            if (agenteAmbiental == null)
            {
                return HttpNotFound();
            }
            return View(agenteAmbiental);
        }

        // POST: AgenteAmbiental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_agenteAmbientalAppService.Excluir(id))
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
                _agenteAmbientalAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
