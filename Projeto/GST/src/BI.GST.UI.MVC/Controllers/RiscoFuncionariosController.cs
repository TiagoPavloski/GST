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
    public class RiscoFuncionariosController : Controller
    {
        private readonly IRiscoFuncionarioAppService _riscoFuncionarioAppService;

        public RiscoFuncionariosController(IRiscoFuncionarioAppService riscoFuncionarioAppService)
        {
            _riscoFuncionarioAppService = riscoFuncionarioAppService;
        }

        // GET: RiscoFuncionarios
        public ActionResult Index(string pesquisa, int page = 0)
        {
            var riscoFuncionarioViewModel = _riscoFuncionarioAppService.ObterGrid(page, pesquisa);
            ViewBag.PaginaAtual = page;
            ViewBag.Busca = "&pesquisa=" + pesquisa;
            ViewBag.Controller = "RiscoFuncionario";
            ViewBag.TotalRegistros = _riscoFuncionarioAppService.ObterTotalRegistros(pesquisa);

            return View(riscoFuncionarioViewModel);
        }

        // GET: RiscoFuncionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoFuncionario = _riscoFuncionarioAppService.ObterPorId(id.Value);
            if (riscoFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(riscoFuncionario);
        }

        // GET: RiscoFuncionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiscoFuncionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiscoFuncionarioViewModel riscoFuncionarioViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!_riscoFuncionarioAppService.Adicionar(riscoFuncionarioViewModel))
                {
                    TempData["Mensagem"] = "Atenção, há um Risco Funcionário com os mesmos dados";
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Risco Funcionário com os mesmos dados')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(riscoFuncionarioViewModel);
        }

        // GET: RiscoFuncionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoFuncionario = _riscoFuncionarioAppService.ObterPorId(id.Value);
            if (riscoFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(riscoFuncionario);
        }

        // POST: RiscoFuncionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RiscoFuncionarioViewModel riscoFuncionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_riscoFuncionarioAppService.Atualizar(riscoFuncionarioViewModel))
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT> alert('Atenção, há um Risco Funcionário com os mesmos dados já cadastrado')</SCRIPT>");
                }
                else
                    return RedirectToAction("Index");
            }
            return View(riscoFuncionarioViewModel);
        }

        // GET: RiscoFuncionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var riscoFuncionario = _riscoFuncionarioAppService.ObterPorId(id.Value);
            if (riscoFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(riscoFuncionario);
        }

        // POST: RiscoFuncionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_riscoFuncionarioAppService.Excluir(id))
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
                _riscoFuncionarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
